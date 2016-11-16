using DispCore.Events;
using DispCore.Events.Sip;
using DispCore.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DispCore.Services.Impl
{
	public class StatusService : IStatusService, IService
	{
		private ServiceManager manager;

		private System.Collections.Generic.Dictionary<long, MySubscriptionSession> termSubSessions;

		private System.Collections.Generic.Dictionary<long, MySubscriptionSession> grpSubSessions;

		private MySubscriptionSession subReg;

		private MySubscriptionSession subWinfo;

		private MySubscriptionSession subMwi;

		private MyPublicationSession pubPres;

		private string Identity;

		public event System.EventHandler<StatusEventArgs> onStatusEvent;

		public string defaultIdentity
		{
			get
			{
				return this.Identity;
			}
			set
			{
				this.Identity = value;
			}
		}

		public StatusService(ServiceManager manager)
		{
			this.manager = manager;
		}

		public bool Start()
		{
			this.termSubSessions = new System.Collections.Generic.Dictionary<long, MySubscriptionSession>();
			this.grpSubSessions = new System.Collections.Generic.Dictionary<long, MySubscriptionSession>();
			this.manager.ContactService.onContactEvent += new System.EventHandler<ContactEventArgs>(this.OnContactEvent);
			this.manager.StackService.onSubscriptionEvent += new System.EventHandler<SubscriptionEventArgs>(this.OnSubscriptionEvent);
			return true;
		}

		public bool Stop()
		{
			this.manager.ContactService.onContactEvent -= new System.EventHandler<ContactEventArgs>(this.OnContactEvent);
			this.manager.StackService.onSubscriptionEvent -= new System.EventHandler<SubscriptionEventArgs>(this.OnSubscriptionEvent);
			this.UnSubscribeAll();
			System.Threading.Thread.Sleep(1000);
			this.termSubSessions.Clear();
			this.grpSubSessions.Clear();
			return true;
		}

		public void DoPostRegistrationOp()
		{
			if (this.manager.AccessNetworkService.IsRegistered)
			{
				this.Identity = this.manager.StackService.SipStack.SelfPreferences.impu;
			}
		}

		private bool SubscribeToRegInfo()
		{
			if (this.subReg == null)
			{
				this.subReg = new MySubscriptionSession(this.manager.StackService.SipStack, this.Identity, MySubscriptionSession.EVENT_PACKAGE_TYPE.REG);
			}
			else
			{
				this.subReg.ToUri = this.Identity;
				this.subReg.FromUri = this.Identity;
				this.subReg.SigCompId = this.manager.StackService.SipStack.SigCompId;
			}
			return this.subReg.Subscribe();
		}

		private bool SubscribeToMWI()
		{
			if (this.subMwi == null)
			{
				this.subMwi = new MySubscriptionSession(this.manager.StackService.SipStack, this.Identity, MySubscriptionSession.EVENT_PACKAGE_TYPE.MESSAGE_SUMMARY);
			}
			else
			{
				this.subMwi.ToUri = this.Identity;
				this.subMwi.FromUri = this.Identity;
				this.subMwi.SigCompId = this.manager.StackService.SipStack.SigCompId;
			}
			return this.subMwi.Subscribe();
		}

		private bool SubscribeToWinfo()
		{
			if (this.subWinfo == null)
			{
				this.subWinfo = new MySubscriptionSession(this.manager.StackService.SipStack, this.Identity, MySubscriptionSession.EVENT_PACKAGE_TYPE.WINFO);
			}
			else
			{
				this.subWinfo.ToUri = this.Identity;
				this.subWinfo.FromUri = this.Identity;
				this.subWinfo.SigCompId = this.manager.StackService.SipStack.SigCompId;
			}
			return this.subWinfo.Subscribe();
		}

		private bool PublishPresence()
		{
			return false;
		}

		public MySubscriptionSession FindSubcribSenssion(long iSessionId)
		{
			MySubscriptionSession result;
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.termSubSessions)
			{
				MySubscriptionSession senssionReturn = senssionPair.Value;
				if (senssionReturn.Id == iSessionId)
				{
					result = senssionReturn;
					return result;
				}
			}
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.grpSubSessions)
			{
				MySubscriptionSession senssionReturn = senssionPair.Value;
				if (senssionReturn.Id == iSessionId)
				{
					result = senssionReturn;
					return result;
				}
			}
			result = null;
			return result;
		}

		public System.Collections.Generic.List<MySubscriptionSession> FindSubcribSenssion(string strName)
		{
			System.Collections.Generic.List<MySubscriptionSession> senssionReturn = new System.Collections.Generic.List<MySubscriptionSession>();
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.termSubSessions)
			{
				MySubscriptionSession senssiontem = senssionPair.Value;
				if (senssiontem.ToUri == strName)
				{
					senssionReturn.Add(senssiontem);
				}
			}
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.grpSubSessions)
			{
				MySubscriptionSession senssiontem = senssionPair.Value;
				if (senssiontem.ToUri == strName)
				{
					senssionReturn.Add(senssiontem);
				}
			}
			return senssionReturn;
		}

		private void OnContactEvent(object sender, ContactEventArgs e)
		{
			object oGroup = e.GetExtra("group");
			object oPerson = e.GetExtra("contact");
			if (oPerson is Group)
			{
				oGroup = (oPerson as Group);
			}
			switch (e.Type)
			{
			case ContactEventTypes.CONTACT_ADDED:
			case ContactEventTypes.CAMERA_ADDED:
				if (oPerson != null)
				{
					if (oPerson is System.Collections.Generic.List<Person>)
					{
						System.Collections.Generic.List<Person> lP = oPerson as System.Collections.Generic.List<Person>;
						foreach (Person p in lP)
						{
							if (p.Uri != null && !(p.Uri == ""))
							{
								this.SubscribeTermStatus(p);
							}
						}
					}
					else
					{
						Person p = oPerson as Person;
						if (p != null && p.Uri != null && !(p.Uri == ""))
						{
							this.SubscribeTermStatus(p);
						}
					}
				}
				break;
			case ContactEventTypes.CONTACT_REMOVED:
				if (oPerson != null)
				{
					if (oPerson is System.Collections.Generic.List<Person>)
					{
						System.Collections.Generic.List<Person> lP = oPerson as System.Collections.Generic.List<Person>;
						foreach (Person p in lP)
						{
							this.UnSubscribeTermStatus(p);
						}
					}
					else
					{
						Person p = oPerson as Person;
						this.UnSubscribeTermStatus(p);
					}
				}
				break;
			case ContactEventTypes.GROUP_ADDED:
				if (oGroup != null)
				{
					Group g = oGroup as Group;
					if (g.Uri != null && !(g.Uri == ""))
					{
						this.SubscribeGroupStatus(g);
						this.SubscribeGroupMemberShip(g);
					}
				}
				break;
			case ContactEventTypes.GROUP_REMOVED:
				if (oGroup != null)
				{
					Group gg = oGroup as Group;
					this.UnSubscribeGroupStatus(gg);
				}
				break;
			}
		}

		private void OnSubscriptionEvent(object sender, SubscriptionEventArgs e)
		{
			if (null != e)
			{
				MySubscriptionSession session = this.FindSubcribSenssion(e.SessionId);
				SubscriptionEventTypes type = e.Type;
				if (type != SubscriptionEventTypes.SUBSCRIPTION_OK)
				{
					if (type != SubscriptionEventTypes.UNSUBSCRIPTION_OK)
					{
						if (type != SubscriptionEventTypes.INCOMING_NOTIFY)
						{
						}
					}
					else
					{
						session.IsConnected = false;
					}
				}
				else
				{
					session.IsConnected = true;
				}
			}
		}

		public bool SubscribeTermStatus(Person p)
		{
			MySubscriptionSession session = new MySubscriptionSession(this.manager.StackService.SipStack, p.UDN, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_REG_SUB);
			session.FromUri = this.Identity;
			this.grpSubSessions.Add(session.Id, session);
			MySubscriptionSession session2 = new MySubscriptionSession(this.manager.StackService.SipStack, p.UDN, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_UECALL_SUB);
			session2.FromUri = this.Identity;
			this.grpSubSessions.Add(session2.Id, session2);
			return session.Subscribe() & session2.Subscribe();
		}

		public bool SubscribeTermStatus(string strUDN)
		{
			MySubscriptionSession session = new MySubscriptionSession(this.manager.StackService.SipStack, strUDN, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_REG_SUB);
			session.FromUri = this.Identity;
			this.grpSubSessions.Add(session.Id, session);
			MySubscriptionSession session2 = new MySubscriptionSession(this.manager.StackService.SipStack, strUDN, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_UECALL_SUB);
			session2.FromUri = this.Identity;
			this.grpSubSessions.Add(session2.Id, session2);
			return session.Subscribe() & session2.Subscribe();
		}

		public bool SubscribeGroupStatus(Group g)
		{
			MySubscriptionSession session = new MySubscriptionSession(this.manager.StackService.SipStack, g.Uri, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_GRCALL_SUB);
			session.FromUri = this.Identity;
			this.grpSubSessions.Add(session.Id, session);
			return session.Subscribe();
		}

		public bool SubscribeGroupMemberShip(Group g)
		{
			MySubscriptionSession session = new MySubscriptionSession(this.manager.StackService.SipStack, g.Uri, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_MEMBRELATION_SUB);
			session.FromUri = this.Identity;
			this.grpSubSessions.Add(session.Id, session);
			string strUheader = string.Format("pttsubscribe;utype={0}", 2);
			return session.Subscribe(strUheader);
		}

		public bool SubscribeUserMemberShip(Person p)
		{
			MySubscriptionSession session = new MySubscriptionSession(this.manager.StackService.SipStack, p.Uri, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_MEMBRELATION_SUB);
			session.FromUri = this.Identity;
			this.grpSubSessions.Add(session.Id, session);
			string strUheader = string.Format("pttsubscribe;utype={0}", 1);
			return session.Subscribe(strUheader);
		}

		public bool UnSubscribeTermStatus(Person p)
		{
			System.Collections.Generic.List<MySubscriptionSession> sessions = this.FindSubcribSenssion(p.Name);
			foreach (MySubscriptionSession session in sessions)
			{
				session.UnSubscribe();
			}
			this.RemoveSubSension(p.UDN);
			return true;
		}

		public bool UnSubscribeGroupStatus(Group g)
		{
			System.Collections.Generic.List<MySubscriptionSession> sessions = this.FindSubcribSenssion(g.Name);
			foreach (MySubscriptionSession session in sessions)
			{
				session.UnSubscribe();
			}
			this.RemoveSubSension(g.GDN);
			return true;
		}

		public void UnSubscribeAll()
		{
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.termSubSessions)
			{
				MySubscriptionSession senssionReturn = senssionPair.Value;
				if (senssionReturn != null)
				{
					senssionReturn.UnSubscribe();
				}
			}
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.grpSubSessions)
			{
				MySubscriptionSession senssionReturn = senssionPair.Value;
				if (senssionReturn != null)
				{
					senssionReturn.UnSubscribe();
				}
			}
		}

		public void RemoveSubSension(string strKey)
		{
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.termSubSessions)
			{
				MySubscriptionSession senssionReturn = senssionPair.Value;
				if (senssionReturn.ToUri == strKey)
				{
					this.termSubSessions.Remove(senssionReturn.Id);
				}
			}
			foreach (System.Collections.Generic.KeyValuePair<long, MySubscriptionSession> senssionPair in this.grpSubSessions)
			{
				MySubscriptionSession senssionReturn = senssionPair.Value;
				if (senssionReturn.ToUri == strKey)
				{
					this.termSubSessions.Remove(senssionReturn.Id);
				}
			}
		}

		public bool IsContactSubscribed(string uri)
		{
			return false;
		}

		public bool KillTerm(string termUri)
		{
			return true;
		}

		public bool StunTerm(string termUri)
		{
			return true;
		}

		public bool ReviveTerm(string termUri)
		{
			return true;
		}
	}
}
