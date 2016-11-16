using DispCore.Models;
using DispCore.Utils;
using System;
using System.Collections.Generic;

namespace DispCore.Services
{
	public class SessionManager
	{
		private System.Collections.Generic.Dictionary<long, MySipSession> dicSidIdx;

		private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<MySipSession>> dicUidIdx;

		private MyObservableCollection<MySipSession> sessions;

		public MyObservableCollection<MySipSession> Sessions
		{
			get
			{
				return this.sessions;
			}
		}

		public SessionManager()
		{
			this.dicSidIdx = new System.Collections.Generic.Dictionary<long, MySipSession>();
			this.dicUidIdx = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<MySipSession>>();
			this.sessions = new MyObservableCollection<MySipSession>();
		}

		public void AddSession(long sessionId, MySipSession session)
		{
			try
			{
				this.sessions.Add(session);
				this.dicSidIdx.Add(sessionId, session);
				if (!this.dicUidIdx.ContainsKey(session.RemotePartyUri))
				{
					System.Collections.Generic.List<MySipSession> sessionList = new System.Collections.Generic.List<MySipSession>();
					sessionList.Add(session);
					this.dicUidIdx.Add(session.RemotePartyUri, sessionList);
				}
				else
				{
					this.dicUidIdx[session.RemotePartyUri].Add(session);
				}
			}
			catch (System.Exception e_74)
			{
			}
		}

		public void DelSession(MySipSession session)
		{
			try
			{
				if (this.sessions.Contains(session))
				{
					this.sessions.Remove(session);
				}
				this.dicSidIdx.Remove(session.Id);
				if (this.dicUidIdx.ContainsKey(session.RemotePartyUri))
				{
					this.dicSidIdx.Remove(session.Id);
					this.dicUidIdx[session.RemotePartyUri].Remove(session);
				}
			}
			catch (System.Exception e_7D)
			{
			}
		}

		public MySipSession FindSession(long sessionId)
		{
			MySipSession result;
			if (this.dicSidIdx.ContainsKey(sessionId))
			{
				result = this.dicSidIdx[sessionId];
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
