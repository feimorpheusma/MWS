using DispCore.Trunk.Types;
using System;

namespace DispCore.Utils.Trunk
{
	public class TrunkUitls
	{
		public static TrunkCallType ConvertFromString(string orign)
		{
			TrunkCallType result;
			if (orign == null || orign.Length == 0)
			{
				result = TrunkCallType.TCT_NONE;
			}
			else
			{
				int temp = int.Parse(orign);
				if (temp < 1 || temp > 23)
				{
					result = TrunkCallType.TCT_NONE;
				}
				else
				{
					result = (TrunkCallType)temp;
				}
			}
			return result;
		}

		public static string GetPTTExtension(string strHeardContents, string strKey)
		{
			string result;
			if (strHeardContents == null || strHeardContents == string.Empty)
			{
				result = null;
			}
			else
			{
				string[] strKeys = strHeardContents.Split(new char[]
				{
					';'
				});
				string[] array = strKeys;
				for (int i = 0; i < array.Length; i++)
				{
					string strKeyMemb = array[i];
					string[] strKeyItem = strKeyMemb.Split(new char[]
					{
						'='
					});
					if (strKeyItem != null && strKeyItem.Length == 2)
					{
						string strItemKey = strKeyItem[0];
						if (strItemKey != null && strItemKey.Trim().Equals(strKey, System.StringComparison.InvariantCultureIgnoreCase))
						{
							result = strKeyItem[1];
							return result;
						}
					}
				}
				result = null;
			}
			return result;
		}
	}
}
