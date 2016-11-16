using DispCore.Models.Cfg;
using DispCore.Services.Impl;
using log4net;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Utils
{
	public static class UriUtils
	{
		private const long MAX_PHONE_NUMBER = 1000000000000L;

		private const string INVALID_SIP_URI = "sip:invalid@test.com";

		private static readonly ILog LOG = LogManager.GetLogger(typeof(UriUtils));

		private static ServiceManager serviceManager = null;

		public static ServiceManager ServiceManager
		{
			get
			{
				return UriUtils.serviceManager;
			}
			set
			{
				UriUtils.serviceManager = value;
			}
		}

		public static Uri GetHttpUri(string UriString)
		{
			Uri result;
			try
			{
				result = new Uri(UriString);
			}
			catch
			{
				result = new Uri("http://doubango.org");
			}
			return result;
		}

		public static string GetUserName(string uri)
		{
			string userName = null;
			if (!string.IsNullOrEmpty(uri))
			{
				SipUri sipUri = new SipUri(uri);
				if (sipUri.isValid())
				{
					userName = sipUri.getUserName();
				}
				sipUri.Dispose();
			}
			return (userName == null) ? uri : userName;
		}

		public static bool IsValidSipUri(string uri)
		{
			return SipUri.isValid(uri);
		}

		public static string GetValidSipUri(string uri)
		{
			string result;
			if (string.IsNullOrEmpty(uri))
			{
				result = "sip:invalid@test.com";
			}
			else if (uri.StartsWith("sip:") || uri.StartsWith("sip:") || uri.StartsWith("tel:"))
			{
				result = uri;
			}
			else if (uri.Contains("@"))
			{
				result = string.Format("sip:{0}", uri);
			}
			else
			{
				string realm = UriUtils.ServiceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.REALM, Configuration.DEFAULT_NETWORK_REALM);
				if (realm.StartsWith("sip:") || realm.StartsWith("sips:"))
				{
					realm = realm.Substring(realm.IndexOf(":") + 1);
				}
				result = string.Format("sip:{0}@{1}", uri.Replace("(", "").Replace(")", "").Replace("-", ""), "test.com");
			}
			return result;
		}

		public static string GetValidPhoneNumber(string uri)
		{
			string result2;
			if (uri != null && (uri.StartsWith("sip:") || uri.StartsWith("sip:") || uri.StartsWith("tel:")))
			{
				SipUri sipUri = new SipUri(uri);
				if (sipUri.isValid())
				{
					string userName = sipUri.getUserName();
					if (userName != null)
					{
						try
						{
							string scheme = sipUri.getScheme();
							if (scheme != null && scheme.Equals("tel"))
							{
								userName = userName.Replace("-", "");
							}
							long result = System.Convert.ToInt64(userName.StartsWith("+") ? userName.Substring(1) : userName);
							if (result < 1000000000000L)
							{
								result2 = userName;
								return result2;
							}
						}
						catch (System.FormatException)
						{
						}
						catch (System.Exception e)
						{
							UriUtils.LOG.Error(e);
						}
					}
				}
				sipUri.Dispose();
			}
			else
			{
				try
				{
					uri = uri.Replace("-", "");
					long result = System.Convert.ToInt64(uri.StartsWith("+") ? uri.Substring(1) : uri);
					if (result < 1000000000000L)
					{
						result2 = uri;
						return result2;
					}
				}
				catch (System.FormatException)
				{
				}
				catch (System.Exception e)
				{
					UriUtils.LOG.Error(e);
				}
			}
			result2 = null;
			return result2;
		}
	}
}
