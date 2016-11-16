using DispCore.Events;
using DispCore.Models;
using DispCore.Models.Rls.resource_lists;
using DispCore.Types;
using DispCore.Types.Trunk;
using DispCore.Utils;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DispCore.Services.Impl
{
	public class ContactService : IContactService, IService
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(StackService));

		private ContactItem addressBook;

		private ContactItem addressBookTemp;

		private ServiceManager serviceManager;

		private MySubscriptionSession subContact;

		public event System.EventHandler<ContactEventArgs> onContactEvent;

		public ContactItem AddressBook
		{
			get
			{
				return this.addressBook;
			}
		}

		public ContactItem AddressBookTemp
		{
			get
			{
				return this.addressBookTemp;
			}
		}

		public ContactService(ServiceManager manager)
		{
			this.serviceManager = manager;
		}

		public bool Start()
		{
			this.addressBook = new Group("", "ROOT", "", false, null);
			this.addressBookTemp = new Group("", "ROOT", "", false, null);
			this.serviceManager.AccessNetworkService.onAccessNetworkEvent += new System.EventHandler<AccessNetworkEventArgs>(this.OnAccessNetworkEvent);
			this.serviceManager.StackService.onAddressListEvent += new System.EventHandler<AddressListEventArgs>(this.OnAddressListEvent);
			return true;
		}

		public bool Stop()
		{
			this.serviceManager.AccessNetworkService.onAccessNetworkEvent -= new System.EventHandler<AccessNetworkEventArgs>(this.OnAccessNetworkEvent);
			this.serviceManager.StackService.onAddressListEvent -= new System.EventHandler<AddressListEventArgs>(this.OnAddressListEvent);
			this.UnSubscribeAll();
			return true;
		}

		public void OnAddressListEvent(object sender, AddressListEventArgs e)
		{
		}

		public void OnAccessNetworkEvent(object sender, AccessNetworkEventArgs e)
		{
			AccessNetworkEventTypes type = e.Type;
			if (type == AccessNetworkEventTypes.ANET_LOGIN)
			{
				ANStatus status = e.Status;
				if (status == ANStatus.INSERVICE)
				{
					new System.Threading.Thread(new System.Threading.ThreadStart(delegate
					{
						if (this.serviceManager.ConfigurationService.ContactsCfg.ContactStorageType.ToLower().Equals("remote"))
						{
							this.GetRemoteContactsAsync();
						}
						else
						{
							this.LoadLocalContacts();
						}
					})).Start();
				}
			}
		}

		public bool GetRemoteContactsSync()
		{
			return true;
		}

		public bool GetRemoteContactsAsync()
		{
			string strRemoteContactType = this.serviceManager.ConfigurationService.ContactsCfg.RemoteContactType;
			bool result;
			if (strRemoteContactType == "XCAP")
			{
				result = this.DownloadContactByXcap();
			}
			else
			{
				result = (strRemoteContactType == "SUBSCRIBE" && this.GetRemoteContactsBySub());
			}
			return result;
		}

		public bool DownloadContactByXcap()
		{
			if (this.serviceManager.StackService.XcapPrepare())
			{
				this.serviceManager.StackService.DownloadDocuments();
			}
			return true;
		}

		public bool DownloadContactByMessage()
		{
			return true;
		}

		public bool GetRemoteContactsBySub()
		{
			string strToUri = this.serviceManager.ConfigurationService.IdentityCfg.Impu;
			if (this.subContact == null)
			{
				this.subContact = new MySubscriptionSession(this.serviceManager.StackService.SipStack, strToUri, MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_MEMBRELATION_SUB);
			}
			else
			{
				this.subContact.ToUri = strToUri;
				this.subContact.FromUri = strToUri;
			}
			string strUheader = string.Format("pttsubscribe;utype={0}", 3);
			return this.subContact.Subscribe(strUheader);
		}

		public void UnSubscribeAll()
		{
			if (this.subContact != null)
			{
				this.subContact.UnSubscribe();
			}
		}

		public bool LoadLocalContacts()
		{
			Group groupCamera = new Group("888888888", "Camera", "sip:888888888@test.com", true, this.addressBook);
			groupCamera.GrpType = TrunkGroupTypes.TGT_CAMERA;
			Camera camera = new Camera("18899990001", "一号摄像头", "sip:18899990001@test.com", true, groupCamera);
			Camera camera2 = new Camera("18899990002", "二号摄像头", "sip:18899990002@test.com", true, groupCamera);
			this.AddPerson2Group(groupCamera, camera);
			this.AddPerson2Group(groupCamera, camera2);
			this.AddGroup(groupCamera, this.addressBook);
			return true;
		}

		public ContactItem FindItem(string key, ContactType contactType)
		{
			key = UriUtils.GetUserName(key);
			return this.FindItem(key, contactType, this.addressBook);
		}

		public ContactItem FindItem(string key, ContactType contactType, ContactItem ItemHolder)
		{
			ContactItem result;
			if (contactType == ContactType.Person || contactType == ContactType.Any)
			{
				foreach (object o in ItemHolder.Children)
				{
					if (o is Person)
					{
						Person p = o as Person;
						if (p.UDN.Equals(key, System.StringComparison.InvariantCultureIgnoreCase))
						{
							result = p;
							return result;
						}
					}
					else if (o is Group)
					{
						ContactItem itemPs = this.FindItem(key, ContactType.Person, o as Group);
						if (itemPs != null)
						{
							result = itemPs;
							return result;
						}
					}
				}
			}
			if (contactType == ContactType.Group || contactType == ContactType.Any)
			{
				foreach (object o in ItemHolder.Children)
				{
					if (!(o is Person))
					{
						if (o is Group)
						{
							Group g = o as Group;
							if (g.GDN.Equals(key, System.StringComparison.InvariantCultureIgnoreCase))
							{
								result = g;
								return result;
							}
							ContactItem itemPs = this.FindItem(key, ContactType.Group, g);
							if (itemPs != null)
							{
								result = itemPs;
								return result;
							}
						}
					}
				}
			}
			result = null;
			return result;
		}

		public bool AddFavorite(ContactItem item)
		{
			return true;
		}

		public bool AddGroup(Group group, ContactItem parent)
		{
			bool result;
			if (group == null || parent == null)
			{
				result = false;
			}
			else if (this.FindItem(group.GDN, ContactType.Group) != null)
			{
				result = false;
			}
			else
			{
				lock (parent)
				{
					parent.Children.Add(group);
					group.Parent = parent;
				}
				ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.GROUP_ADDED);
				eargs.AddExtra("group", group);
				eargs.AddExtra("parent", parent);
				EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
				result = true;
			}
			return result;
		}

		public bool DeleteGroup(Group parent, Group group)
		{
			bool result;
			if (parent == null || null == group)
			{
				result = false;
			}
			else
			{
				foreach (ContactItem contact in parent.Children)
				{
					if (contact == group)
					{
						parent.Children.Remove(contact);
						ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.GROUP_REMOVED);
						eargs.AddExtra("group", group);
						EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
						result = true;
						return result;
					}
					if (contact is Group && contact.Children.Count > 0)
					{
						if (this.DeleteGroup(contact as Group, group))
						{
							result = true;
							return result;
						}
					}
				}
				result = false;
			}
			return result;
		}

		public bool UpdatePersonInfo(Person person)
		{
			ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.CONTACT_UPDATED);
			eargs.AddExtra("contact", person);
			EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
			return true;
		}

		public bool UpdateGroupInfo(Group group)
		{
			return true;
		}

		public bool AddPerson2Group(Group group, Person person)
		{
			bool result;
			if (group == null || null == person)
			{
				result = false;
			}
			else
			{
				group.Children.Add(person);
				person.Parent = group;
				ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.CONTACT_ADDED);
				eargs.AddExtra("parent", group);
				eargs.AddExtra("contact", person);
				EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
				result = true;
			}
			return result;
		}

		public bool AddPerson2Group(Group group, Camera person)
		{
			bool result;
			if (group == null || null == person)
			{
				result = false;
			}
			else
			{
				group.Children.Add(person);
				person.Parent = group;
				ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.CAMERA_ADDED);
				eargs.AddExtra("parent", group);
				eargs.AddExtra("contact", person);
				EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
				result = true;
			}
			return result;
		}

		public bool AddPerson2Group(Group group, System.Collections.Generic.List<Person> persons)
		{
			bool result;
			if (group == null || null == persons)
			{
				result = false;
			}
			else
			{
				string strDPSUser = UriUtils.GetUserName(this.serviceManager.ConfigurationService.IdentityCfg.Impi);
				foreach (Person person in persons)
				{
					string strPersonName = UriUtils.GetUserName(person.Uri);
					if (!strDPSUser.Equals(person.UDN, System.StringComparison.InvariantCultureIgnoreCase) && !strDPSUser.Equals(strPersonName, System.StringComparison.InvariantCultureIgnoreCase))
					{
						group.Children.Add(person);
						person.Parent = group;
					}
				}
				ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.CONTACT_ADDED);
				eargs.AddExtra("parent", group);
				eargs.AddExtra("contact", persons);
				EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
				result = true;
			}
			return result;
		}

		public bool DelPersonInGroup(Group group, Person person)
		{
			ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.CONTACT_REMOVED);
			eargs.AddExtra("parent", group);
			eargs.AddExtra("contact", person);
			EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
			return true;
		}

		public bool DelPersonInGroup(Group group, System.Collections.Generic.List<Person> persons)
		{
			ContactEventArgs eargs = new ContactEventArgs(ContactEventTypes.CONTACT_REMOVED);
			eargs.AddExtra("parent", group);
			eargs.AddExtra("contact", persons);
			EventHandlerTrigger.TriggerEvent<ContactEventArgs>(this.onContactEvent, this, eargs);
			return true;
		}

		public bool CreateGroup(bool isTempGrp, string groupName, int priority, int maxPeriod, System.Collections.Generic.List<ContactItem> userList, string strGroupGDN)
		{
			Group group = new Group(groupName, groupName, strGroupGDN, false, null);
			if (isTempGrp)
			{
				group.GrpType = TrunkGroupTypes.TGT_NEW_TEMP;
			}
			else
			{
				group.GrpType = TrunkGroupTypes.TGT_NEW_DGNA;
			}
			System.Collections.Generic.List<string> userIdList = new System.Collections.Generic.List<string>();
			foreach (ContactItem contact in userList)
			{
				userIdList.Add(contact.Name);
				group.Children.Add(contact);
			}
			if (this.serviceManager.ServiceRealizeService.CreateGroup(isTempGrp, groupName, priority, maxPeriod, userIdList, strGroupGDN))
			{
				this.AddGroup(group, this.addressBook);
			}
			else
			{
				MessageBox.Show("License受限");
			}
			return true;
		}

		public bool CreateDelGroup(bool bCreate, string strGroupGDN, string groupName, int priority, System.Collections.Generic.List<string> userList)
		{
			bool result;
			if (bCreate)
			{
				ContactItem item = this.FindItem(strGroupGDN, ContactType.Group);
				Group group = null;
				if (item == null)
				{
					group = new Group(groupName, groupName, strGroupGDN, false, null);
				}
				else
				{
					group = (item as Group);
				}
				group.GrpType = TrunkGroupTypes.TGT_NEW_TEMP;
				foreach (string contact in userList)
				{
					ContactItem itemp = this.FindItem(contact, ContactType.Person);
					if (itemp != null)
					{
						group.Children.Add(itemp as Person);
					}
				}
				this.AddGroup(group, this.addressBook);
			}
			else
			{
				ContactItem item = this.FindItem(strGroupGDN, ContactType.Group);
				Group group = null;
				if (item == null)
				{
					result = true;
					return result;
				}
				group = (item as Group);
				if (group.GrpType != TrunkGroupTypes.TGT_NEW_TEMP)
				{
					result = true;
					return result;
				}
				foreach (string contact in userList)
				{
					ContactItem itemp = this.FindItem(contact, ContactType.Person);
					if (itemp != null)
					{
						group.Children.Remove(itemp);
					}
				}
				if (group.Children.Count == 0)
				{
					this.addressBook.Children.Remove(group);
				}
			}
			result = true;
			return result;
		}

		public bool CreateGroup(string name, string displayName)
		{
			Group group = new Group(name, displayName, name, false, null);
			bool result;
			if (this.serviceManager.StackService.AddGroup(group))
			{
				this.AddGroup(group, this.addressBook);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool DeleteGroup(Group group)
		{
			this.DeleteGroup((Group)group.Parent, group);
			return true;
		}

		public bool CreatePerson(string uri, string name, Group group)
		{
			Person person = new Person(name, name, uri, false, null);
			bool result;
			if (this.serviceManager.StackService.AddPerson(person, group.Name))
			{
				this.AddPerson2Group(group, person);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool DeletePerson(Person person)
		{
			bool result;
			if (person.Parent == null || !(person.Parent is Group))
			{
				result = false;
			}
			else
			{
				if (this.serviceManager.StackService.DeletePerson(person, (person.Parent as Group).Name))
				{
					this.DelPersonInGroup(person.Parent as Group, person);
				}
				result = true;
			}
			return result;
		}

		public void ParseDPlussGURelation(byte[] p)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				using (System.IO.MemoryStream stream = new System.IO.MemoryStream(p))
				{
					doc.Load(stream);
					XmlElement root = doc.DocumentElement;
					XmlNodeList listNode = doc.GetElementsByTagName("membership");
					foreach (XmlNode node in listNode)
					{
						if (node != null)
						{
							string strName = node.Name;
							string strValue = node.Value;
							XmlAttributeCollection nAtrCol = node.Attributes;
							XmlNode nodeutype = nAtrCol.GetNamedItem("utype");
							string strutypeValue = nodeutype.Value;
							if (strutypeValue != null && !(strutypeValue == string.Empty))
							{
								int iUtype = int.Parse(strutypeValue);
								XmlNodeList nodeMembList = node.ChildNodes;
								foreach (XmlNode nodeMemb in nodeMembList)
								{
									XmlAttributeCollection nAtrColMemb = nodeMemb.Attributes;
									switch (iUtype)
									{
									case 1:
									case 4:
										if (nAtrColMemb != null)
										{
											XmlNode nodeMembName = nAtrColMemb.GetNamedItem("name");
											XmlNode nodeMembNum = nAtrColMemb.GetNamedItem("number");
											XmlNode nodeMembudn = nAtrColMemb.GetNamedItem("udn");
											if (nodeMembName != null && nodeMembudn != null)
											{
												string strUeName = nodeMembName.Value;
												string strUeGdn = nodeMembudn.Value;
												Person pTem = this.FindItem(strUeGdn, ContactType.Group) as Person;
												if (pTem == null)
												{
													if (strUeName == string.Empty)
													{
														strUeName = strUeGdn;
													}
													pTem = new Person(strUeName, strUeName, strUeGdn, false, this.AddressBook);
												}
												else
												{
													pTem.Name = strUeName;
												}
												if (iUtype == 4)
												{
													pTem.Type = ContactType.Camera;
												}
												XmlNodeList listNodePlayload = nodeMemb.ChildNodes;
												foreach (XmlNode nodeUnit in listNodePlayload)
												{
													if (nodeUnit != null)
													{
														string strUnitName = nodeUnit.Name;
														XmlNode nodeGU = nodeUnit.FirstChild;
														if (nodeGU != null)
														{
															XmlNode nodeGUValue = nodeGU.FirstChild;
															if (nodeGUValue != null)
															{
																string strGUValue = nodeGUValue.Value;
																Group g = this.FindItem(strGUValue, ContactType.Group) as Group;
																if (g == null)
																{
																	g = new Group(strGUValue, strGUValue, strGUValue, false, this.AddressBook);
																	this.AddGroup(g, this.AddressBook);
																}
																else
																{
																	g.Name = strGUValue;
																	this.AddPerson2Group(g, pTem);
																}
															}
														}
													}
												}
											}
										}
										break;
									case 2:
										if (nAtrColMemb != null)
										{
											XmlNode nodeMembName = nAtrColMemb.GetNamedItem("name");
											XmlNode nodeMembNum = nAtrColMemb.GetNamedItem("number");
											XmlNode nodeMembudn = nAtrColMemb.GetNamedItem("gdn");
											if (nodeMembName != null && nodeMembudn != null)
											{
												string strGroupName = nodeMembName.Value;
												string strGroupGdn = nodeMembudn.Value;
												Group g = this.FindItem(strGroupGdn, ContactType.Group) as Group;
												if (g == null)
												{
													g = new Group(strGroupName, strGroupName, strGroupGdn, false, this.AddressBook);
													this.AddGroup(g, this.AddressBook);
												}
												else
												{
													g.Name = strGroupName;
												}
												XmlNodeList listNodePlayload = nodeMemb.ChildNodes;
												foreach (XmlNode nodeUnit in listNodePlayload)
												{
													if (nodeUnit != null)
													{
														string strUnitName = nodeUnit.Name;
														XmlNode nodeGU = nodeUnit.FirstChild;
														if (nodeGU != null)
														{
															string strGUName = string.Empty;
															XmlAttributeCollection attGuName = nodeGU.Attributes;
															if (attGuName != null)
															{
																XmlNode nodeGUName = attGuName.GetNamedItem("name");
																if (nodeGUName != null)
																{
																	strGUName = nodeGUName.Value;
																}
															}
															XmlNode nodeGUValue = nodeGU.FirstChild;
															if (nodeGUValue != null)
															{
																string strGUValue = nodeGUValue.Value;
																Person p2Add = this.FindItem(strGUValue, ContactType.Person) as Person;
																if (p2Add == null)
																{
																	if (strGUName == string.Empty)
																	{
																		strGUName = strGUValue;
																	}
																	p2Add = new Person(strGUName, strGUName, strGUValue, false, this.AddressBook);
																	this.AddPerson2Group(g, p2Add);
																}
															}
														}
													}
												}
											}
										}
										break;
									case 3:
										if (nAtrColMemb != null)
										{
											XmlNode nodeMembName = nAtrColMemb.GetNamedItem("name");
											XmlNode nodeMembNum = nAtrColMemb.GetNamedItem("number");
											XmlNode nodeMembudn = nAtrColMemb.GetNamedItem("udn");
											if (nodeMembName != null && nodeMembudn != null)
											{
												string strUeName = nodeMembName.Value;
												string strUeGdn = nodeMembudn.Value;
												XmlNodeList listNodePlayload = nodeMemb.ChildNodes;
												foreach (XmlNode nodeUnit in listNodePlayload)
												{
													if (nodeUnit != null)
													{
														string strUnitName = nodeUnit.Name;
														XmlNode nodeGU = nodeUnit.FirstChild;
														if (nodeGU != null)
														{
															XmlNode nodeGUValue = nodeGU.FirstChild;
															if (nodeGUValue != null)
															{
																string strGUValue = nodeGUValue.Value;
																Group g = this.FindItem(strGUValue, ContactType.Group) as Group;
																if (g == null)
																{
																	g = new Group(strGUValue, strGUValue, strGUValue, false, this.AddressBook);
																	this.AddGroup(g, this.AddressBook);
																}
																else
																{
																	g.Name = strGUValue;
																}
															}
														}
													}
												}
											}
										}
										break;
									}
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex_6C6)
			{
			}
		}

		private bool HandleResourceListsEvent(short code, byte[] content)
		{
			bool result;
			try
			{
				if (ContactService.IsSuccessCode(code))
				{
					resourcelists rlist = this.Deserialize(content, typeof(resourcelists)) as resourcelists;
					if (rlist == null || rlist.list == null)
					{
						result = false;
						return result;
					}
					result = this.FromResouceListToContacts(rlist);
					return result;
				}
				else if (code == 404)
				{
				}
			}
			catch (System.Exception e)
			{
				ContactService.LOG.Error("Failed to handle 'resource-lists' event", e);
				result = false;
				return result;
			}
			result = false;
			return result;
		}

		private object Deserialize(byte[] content, System.Type type)
		{
			object result = null;
			if (content != null)
			{
				XmlReaderSettings settings = new XmlReaderSettings();
				using (System.IO.MemoryStream stream = new System.IO.MemoryStream(content))
				{
					using (XmlReader reader = XmlReader.Create(stream, settings))
					{
						XmlSerializer xmlSerializer = new XmlSerializer(type);
						try
						{
							result = xmlSerializer.Deserialize(reader);
						}
						catch (System.Exception e)
						{
							ContactService.LOG.Error("Failed to deserialize xml content", e);
						}
					}
				}
			}
			else
			{
				ContactService.LOG.Error("Null content");
			}
			return result;
		}

		private byte[] Serialize(object content, bool withoutHeader, bool withoutXsn, XmlSerializerNamespaces namespaceSerializer)
		{
			byte[] xmlResult;
			try
			{
				using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
				{
					using (XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings
					{
						Encoding = new System.Text.UTF8Encoding(false),
						OmitXmlDeclaration = withoutHeader,
						Indent = true
					}))
					{
						XmlSerializer serializer = new XmlSerializer(content.GetType());
						if (namespaceSerializer != null)
						{
							serializer.Serialize(xmlWriter, content, namespaceSerializer);
						}
						else
						{
							serializer.Serialize(xmlWriter, content);
						}
					}
					xmlResult = stream.ToArray();
				}
			}
			catch (System.Exception e)
			{
				ContactService.LOG.Error("Serialization failed", e);
				xmlResult = new byte[0];
			}
			return xmlResult;
		}

		private bool FromResouceListToContacts(resourcelists rlist)
		{
			ContactItem parent = this.addressBook;
			listType[] list2 = rlist.list;
			for (int i = 0; i < list2.Length; i++)
			{
				listType list = list2[i];
				if (list != null && list.name != null)
				{
					this.GetGroupContact(list, parent);
				}
			}
			return true;
		}

		private void GetGroupContact(listType listGroup, ContactItem contctParent)
		{
			IContactService cntService = this.serviceManager.ContactService;
			Group group = null;
			if (listGroup != null && listGroup.name != null)
			{
				string strGroupDisName = listGroup.name;
				if (listGroup.displayname != null)
				{
					strGroupDisName = listGroup.displayname.Value;
				}
				string strUil = UriUtils.GetValidSipUri(listGroup.name);
				group = new Group(listGroup.name, strGroupDisName, strUil, false, contctParent);
				cntService.AddGroup(group, contctParent);
				foreach (entryType entry in listGroup.EntryTypes)
				{
					Person psContact = this.EntryToContact(entry, group);
					cntService.AddPerson2Group(group, psContact);
				}
			}
			foreach (listType list in listGroup.ListTypeLists)
			{
				if (list != null && list.name != null)
				{
					if (group != null)
					{
						this.GetGroupContact(list, group);
					}
				}
			}
		}

		private Person EntryToContact(entryType entry, Group g)
		{
			string strDispName = (entry.displayname == null) ? null : entry.displayname.Value;
			string strUil = UriUtils.GetValidSipUri(entry.uri);
			return new Person(strDispName, strDispName, strUil, false, g);
		}

		private static bool IsSuccessCode(short code)
		{
			return code > 199 && code < 300;
		}
	}
}
