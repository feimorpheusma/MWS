using DispCore.Types;
using DispCore.Types.Trunk;
using DispCore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DispCore.Models
{
	public class Group : ContactItem, INotifyPropertyChanged
	{
		private string gdn;

		private TrunkGroupTypes grpType;

		private TrunkGroupStatusTypes grpStatus;

		private string speaker;

		public string GDN
		{
			get
			{
				string result;
				if (this.uri == null || this.uri == "")
				{
					result = this.name;
				}
				else
				{
					result = UriUtils.GetUserName(this.uri);
				}
				return result;
			}
		}

		public TrunkGroupTypes GrpType
		{
			get
			{
				return this.grpType;
			}
			set
			{
				this.grpType = value;
			}
		}

		public TrunkGroupStatusTypes GrpStatus
		{
			get
			{
				return this.grpStatus;
			}
			set
			{
				this.grpStatus = value;
				base.OnPropertyChanged("GrpStatus");
			}
		}

		public string Speaker
		{
			get
			{
				return this.speaker;
			}
			set
			{
				this.speaker = value;
				base.OnPropertyChanged("Speaker");
			}
		}

		public Group(string name, string displayName, string uri, bool isLocal, ContactItem parent) : base(name, displayName, uri, isLocal, parent)
		{
			this.type = ContactType.Group;
			this.children = new System.Collections.Generic.List<ContactItem>();
			this.grpType = TrunkGroupTypes.TGT_PERMANENT;
		}
	}
}
