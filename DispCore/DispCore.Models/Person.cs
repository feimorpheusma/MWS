using DispCore.Types;
using DispCore.Types.Trunk;
using DispCore.Utils;
using System;

namespace DispCore.Models
{
	public class Person : ContactItem
	{
		private string udn;

		private TrunkUserTypes userType;

		private TrunkGroupMembTypes membType;

		private TrunkUserCallStatusTypes callStatus;

		private TrunkUserRegStatusTypes regStatus;

		private TrunkUserCtrlStatusTypes ctrlStatus;

		private bool privilege;

		private System.DateTime Hyper;

		private string strHomePage;

		private string strFreeText;

		private PresenceStatus psStatus;

		public string UDN
		{
			get
			{
				return UriUtils.GetUserName(this.uri);
			}
		}

		public TrunkUserTypes TermType
		{
			get
			{
				return this.userType;
			}
			set
			{
				this.userType = value;
			}
		}

		public TrunkGroupMembTypes MembType
		{
			get
			{
				return this.membType;
			}
			set
			{
				this.membType = value;
			}
		}

		public TrunkUserCallStatusTypes CallStatus
		{
			get
			{
				return this.callStatus;
			}
			set
			{
				this.callStatus = value;
				base.OnPropertyChanged("CallStatus");
			}
		}

		public TrunkUserRegStatusTypes RegStatus
		{
			get
			{
				return this.regStatus;
			}
			set
			{
				this.regStatus = value;
				base.OnPropertyChanged("RegStatus");
			}
		}

		public TrunkUserCtrlStatusTypes CtrlStatus
		{
			get
			{
				return this.ctrlStatus;
			}
			set
			{
				this.ctrlStatus = value;
				base.OnPropertyChanged("CtrlStatus");
			}
		}

		public bool Privilege
		{
			get
			{
				return this.privilege;
			}
			set
			{
				this.privilege = value;
			}
		}

		public System.DateTime HyperAvaiability
		{
			get
			{
				return this.Hyper;
			}
			set
			{
				this.Hyper = value;
			}
		}

		public string HomePage
		{
			get
			{
				return this.strHomePage;
			}
			set
			{
				this.strHomePage = value;
			}
		}

		public string FreeText
		{
			get
			{
				return this.strFreeText;
			}
			set
			{
				this.strFreeText = value;
			}
		}

		public PresenceStatus PresenceStatus
		{
			get
			{
				return this.psStatus;
			}
			set
			{
				this.psStatus = value;
			}
		}

		public Person(string name, string displayName, string uri, bool isLocal, ContactItem parent) : base(name, displayName, uri, isLocal, parent)
		{
			if (name == string.Empty)
			{
				name = uri;
			}
			if (displayName == string.Empty)
			{
				displayName = uri;
			}
			this.type = ContactType.Person;
			this.regStatus = TrunkUserRegStatusTypes.TURST_UNREGISTERED;
			this.children = null;
		}
	}
}
