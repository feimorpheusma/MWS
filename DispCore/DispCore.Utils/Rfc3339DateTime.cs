using System;
using System.Globalization;

namespace DispCore.Utils
{
	public static class Rfc3339DateTime
	{
		private const string format = "yyyy-MM-dd'T'HH:mm:ss.fffK";

		private static string[] formats = new string[0];

		public static string Rfc3339DateTimeFormat
		{
			get
			{
				return "yyyy-MM-dd'T'HH:mm:ss.fffK";
			}
		}

		public static string[] Rfc3339DateTimePatterns
		{
			get
			{
				string[] result;
				if (Rfc3339DateTime.formats.Length > 0)
				{
					result = Rfc3339DateTime.formats;
				}
				else
				{
					Rfc3339DateTime.formats = new string[11];
					Rfc3339DateTime.formats[0] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";
					Rfc3339DateTime.formats[1] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffffK";
					Rfc3339DateTime.formats[2] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffK";
					Rfc3339DateTime.formats[3] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffK";
					Rfc3339DateTime.formats[4] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK";
					Rfc3339DateTime.formats[5] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffK";
					Rfc3339DateTime.formats[6] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fK";
					Rfc3339DateTime.formats[7] = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
					Rfc3339DateTime.formats[8] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";
					Rfc3339DateTime.formats[9] = System.Globalization.DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern;
					Rfc3339DateTime.formats[10] = System.Globalization.DateTimeFormatInfo.InvariantInfo.SortableDateTimePattern;
					result = Rfc3339DateTime.formats;
				}
				return result;
			}
		}

		public static System.DateTime Parse(string s)
		{
			if (s == null)
			{
				throw new System.ArgumentNullException("s");
			}
			System.DateTime result;
			if (Rfc3339DateTime.TryParse(s, out result))
			{
				return result;
			}
			throw new System.FormatException(string.Format(null, "{0} is not a valid RFC 3339 string representation of a date and time.", new object[]
			{
				s
			}));
		}

		public static string ToString(System.DateTime utcDateTime)
		{
			if (utcDateTime.Kind != System.DateTimeKind.Utc)
			{
				throw new System.ArgumentException("utcDateTime");
			}
			return utcDateTime.ToString(Rfc3339DateTime.Rfc3339DateTimeFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo);
		}

		public static bool TryParse(string s, out System.DateTime result)
		{
			bool wasConverted = false;
			result = System.DateTime.MinValue;
			if (!string.IsNullOrEmpty(s))
			{
				System.DateTime parseResult;
				if (System.DateTime.TryParseExact(s, Rfc3339DateTime.Rfc3339DateTimePatterns, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AdjustToUniversal, out parseResult))
				{
					result = System.DateTime.SpecifyKind(parseResult, System.DateTimeKind.Utc);
					wasConverted = true;
				}
			}
			return wasConverted;
		}
	}
}
