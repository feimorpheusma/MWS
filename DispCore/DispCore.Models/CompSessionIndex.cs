using System;

namespace DispCore.Models
{
	public class CompSessionIndex : SessionId
	{
		private string remoteParty;

		private MediaType sessionType;

		public CompSessionIndex(string remoteParty, MediaType sessionType)
		{
			this.remoteParty = remoteParty;
			this.sessionType = sessionType;
		}

		public bool _Equals(object obj)
		{
			bool result;
			if (obj is CompSessionIndex)
			{
				CompSessionIndex other = obj as CompSessionIndex;
				if (this.remoteParty.Equals(other.remoteParty) && this.sessionType == other.sessionType)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public int _GetHashCode()
		{
			string temp = this.remoteParty + this.sessionType;
			return temp.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return this._Equals(obj);
		}

		public override int GetHashCode()
		{
			return this._GetHashCode();
		}
	}
}
