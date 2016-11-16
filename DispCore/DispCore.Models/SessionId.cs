using System;

namespace DispCore.Models
{
	public interface SessionId
	{
		bool _Equals(object obj);

		int _GetHashCode();
	}
}
