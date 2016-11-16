using log4net;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
{
	public class MySipStack : System.IDisposable
	{
		public enum STACK_STATE
		{
			NONE,
			STARTING,
			STARTED,
			STOPPING,
			STOPPED,
			DISCONNECTED
		}

		public class Preferences
		{
			public string impi;

			public string impu;

			public string password;

			public string realm;

			public string pcscf_host;

			public int pcscf_port;

			public string transport;

			public string ipversion;

			public string local_ip;

			public int local_port;

			public bool dtls_srtp;

			public string privKey;

			public string pubKey;

			public string caKey;

			public bool ipsec_secagree;

			public string algo;

			public string ealgo;

			public string mode;

			public string proto;

			public bool dnsDiscovery;

			public bool earlyIms;

			public bool enableSigComp;

			public string akaAmf;

			public string akaOpID;

			public bool nattUseStun;

			public bool nattStunDisc;

			public string stunServer;

			public int stunPort;

			public long codec;
		}

		private static readonly ILog LOG = LogManager.GetLogger(typeof(MySipStack));

		private MySipStack.STACK_STATE state = MySipStack.STACK_STATE.NONE;

		private string compId;

		private string privacy;

		private string userAgent;

		private string pAccessNetworkInfo;

		private readonly SipStack wrappedStack;

		private MySipStack.Preferences preferences;

		public SipStack WrappedStack
		{
			get
			{
				return this.wrappedStack;
			}
		}

		public MySipStack.Preferences SelfPreferences
		{
			get
			{
				return this.preferences;
			}
		}

		public MySipStack.STACK_STATE State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}

		public string SigCompId
		{
			get
			{
				return this.compId;
			}
			set
			{
				if (this.compId != null && this.compId != value)
				{
					this.wrappedStack.removeSigCompCompartment(this.compId);
				}
				this.compId = value;
				if (value != null)
				{
					this.wrappedStack.addSigCompCompartment(this.compId);
				}
			}
		}

		public MySipStack(SipCallback callback, MySipStack.Preferences preferences)
		{
			this.wrappedStack = new SipStack(callback, preferences.realm, preferences.impi, preferences.impu);
			this.wrappedStack.addHeader("Allow", "INVITE, ACK, CANCEL, BYE, MESSAGE, OPTIONS, NOTIFY, PRACK, UPDATE, REFER");
			this.SetPreferences(preferences);
		}

		public void SetPreferences(MySipStack.Preferences preferences)
		{
			this.preferences = preferences;
			this.wrappedStack.setIMPI(preferences.impi);
			this.wrappedStack.setIMPU(preferences.impu);
			this.wrappedStack.setPassword(preferences.password);
			this.wrappedStack.setRealm(preferences.realm);
			this.wrappedStack.setLocalIP(preferences.local_ip);
			this.wrappedStack.setLocalPort((ushort)preferences.local_port);
			this.wrappedStack.setAMF(preferences.akaAmf);
			this.wrappedStack.setOperatorId(preferences.akaOpID);
			SipStack.setCodecs((tmedia_codec_id_t)preferences.codec);
			if (preferences.nattUseStun)
			{
				MySipStack.LOG.Debug("STUN=yes");
				this.wrappedStack.setSTUNEnabled(true);
				if (preferences.nattStunDisc)
				{
					string domain = preferences.realm.Substring(preferences.realm.IndexOf(':') + 1);
					ushort port = 0;
					string server = this.wrappedStack.dnsSrv(string.Format("_stun._udp.{0}", domain), out port);
					if (server == null)
					{
						MySipStack.LOG.Error("STUN discovery has failed");
					}
					MySipStack.LOG.Debug(string.Format("STUN1 - server={0} and port={1}", server, port));
					this.wrappedStack.setSTUNServer(server, port);
				}
				else
				{
					MySipStack.LOG.Info(string.Format("STUN2 - server={0} and port={1}", preferences.stunServer, preferences.stunPort));
					this.wrappedStack.setSTUNServer(preferences.stunServer, (ushort)preferences.stunPort);
				}
			}
			else
			{
				MySipStack.LOG.Debug("STUN=no");
				this.wrappedStack.setSTUNEnabled(false);
			}
			this.wrappedStack.setProxyCSCF(preferences.pcscf_host, (ushort)preferences.pcscf_port, preferences.transport, preferences.ipversion);
			this.wrappedStack.setSSLCertificates(preferences.privKey, preferences.pubKey, preferences.caKey);
			if (preferences.ipsec_secagree)
			{
				this.wrappedStack.setIPSecParameters(preferences.algo, preferences.ealgo, preferences.mode, preferences.proto);
				this.wrappedStack.setIPSecSecAgree(true);
			}
			else
			{
				this.wrappedStack.setIPSecSecAgree(false);
			}
			this.wrappedStack.setDnsDiscovery(preferences.dnsDiscovery);
			this.wrappedStack.setEarlyIMS(preferences.earlyIms);
			if (preferences.enableSigComp)
			{
				this.compId = string.Format("urn:uuid:{0}", System.Guid.NewGuid().ToString());
			}
			else
			{
				this.compId = null;
			}
		}

		public void SetPreferences()
		{
			this.SetPreferences(this.preferences);
		}

		public void Dispose()
		{
			this.wrappedStack.setDebugCallback(null);
			if (this.wrappedStack != null)
			{
				this.wrappedStack.Dispose();
			}
		}
	}
}
