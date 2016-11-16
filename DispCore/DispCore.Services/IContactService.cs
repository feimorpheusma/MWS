using DispCore.Events;
using DispCore.Models;
using DispCore.Types;
using System;
using System.Collections.Generic;

namespace DispCore.Services
{
	public interface IContactService : IService
	{
		event System.EventHandler<ContactEventArgs> onContactEvent;

		ContactItem AddressBook
		{
			get;
		}

		ContactItem AddressBookTemp
		{
			get;
		}

		bool GetRemoteContactsSync();

		bool GetRemoteContactsAsync();

		bool LoadLocalContacts();

		ContactItem FindItem(string key, ContactType contactType);

		bool AddFavorite(ContactItem item);

		bool AddGroup(Group group, ContactItem cntParent);

		bool DeleteGroup(Group parent, Group group);

		bool UpdatePersonInfo(Person person);

		bool UpdateGroupInfo(Group group);

		bool AddPerson2Group(Group group, Person person);

		bool AddPerson2Group(Group group, Camera person);

		bool AddPerson2Group(Group group, System.Collections.Generic.List<Person> persons);

		bool DelPersonInGroup(Group group, Person person);

		bool DelPersonInGroup(Group group, System.Collections.Generic.List<Person> persons);

		void ParseDPlussGURelation(byte[] p);

		bool CreateGroup(bool isTempGrp, string groupName, int priority, int maxPeriod, System.Collections.Generic.List<ContactItem> userList, string strGroupGDN);

		bool CreateDelGroup(bool bCreate, string strGroupGDN, string groupName, int priority, System.Collections.Generic.List<string> userList);

		bool CreateGroup(string name, string displayName);

		bool DeleteGroup(Group group);

		bool CreatePerson(string uri, string displayName, Group group);

		bool DeletePerson(Person person);
	}
}
