using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SipStack : SafeObject
	{
		private HandleRef swigCPtr;

		internal SipStack(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.SipStack_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SipStack obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SipStack()
		{
			this.Dispose();
		}

		public override void Dispose()
		{
			lock (this)
			{
				if (this.swigCPtr.Handle != IntPtr.Zero)
				{
					if (this.swigCMemOwn)
					{
						this.swigCMemOwn = false;
						tinyWRAPPINVOKE.delete_SipStack(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public SipStack(SipCallback pCallback, string realm_uri, string impi_uri, string impu_uri) : this(tinyWRAPPINVOKE.new_SipStack(SipCallback.getCPtr(pCallback), realm_uri, impi_uri, impu_uri), true)
		{
		}

		public bool start()
		{
			return tinyWRAPPINVOKE.SipStack_start(this.swigCPtr);
		}

		public bool setDebugCallback(DDebugCallback pCallback)
		{
			return tinyWRAPPINVOKE.SipStack_setDebugCallback(this.swigCPtr, DDebugCallback.getCPtr(pCallback));
		}

		public bool setDisplayName(string display_name)
		{
			return tinyWRAPPINVOKE.SipStack_setDisplayName(this.swigCPtr, display_name);
		}

		public bool setRealm(string realm_uri)
		{
			return tinyWRAPPINVOKE.SipStack_setRealm(this.swigCPtr, realm_uri);
		}

		public bool setIMPI(string impi)
		{
			return tinyWRAPPINVOKE.SipStack_setIMPI(this.swigCPtr, impi);
		}

		public bool setIMPU(string impu_uri)
		{
			return tinyWRAPPINVOKE.SipStack_setIMPU(this.swigCPtr, impu_uri);
		}

		public bool setPassword(string password)
		{
			return tinyWRAPPINVOKE.SipStack_setPassword(this.swigCPtr, password);
		}

		public bool setAMF(string amf)
		{
			return tinyWRAPPINVOKE.SipStack_setAMF(this.swigCPtr, amf);
		}

		public bool setOperatorId(string opid)
		{
			return tinyWRAPPINVOKE.SipStack_setOperatorId(this.swigCPtr, opid);
		}

		public bool setProxyCSCF(string fqdn, ushort port, string transport, string ipversion)
		{
			return tinyWRAPPINVOKE.SipStack_setProxyCSCF(this.swigCPtr, fqdn, port, transport, ipversion);
		}

		public bool setLocalIP(string ip, string transport)
		{
			return tinyWRAPPINVOKE.SipStack_setLocalIP__SWIG_0(this.swigCPtr, ip, transport);
		}

		public bool setLocalIP(string ip)
		{
			return tinyWRAPPINVOKE.SipStack_setLocalIP__SWIG_1(this.swigCPtr, ip);
		}

		public bool setLocalPort(ushort port, string transport)
		{
			return tinyWRAPPINVOKE.SipStack_setLocalPort__SWIG_0(this.swigCPtr, port, transport);
		}

		public bool setLocalPort(ushort port)
		{
			return tinyWRAPPINVOKE.SipStack_setLocalPort__SWIG_1(this.swigCPtr, port);
		}

		public bool setEarlyIMS(bool enabled)
		{
			return tinyWRAPPINVOKE.SipStack_setEarlyIMS(this.swigCPtr, enabled);
		}

		public bool addHeader(string name, string value)
		{
			return tinyWRAPPINVOKE.SipStack_addHeader(this.swigCPtr, name, value);
		}

		public bool removeHeader(string name)
		{
			return tinyWRAPPINVOKE.SipStack_removeHeader(this.swigCPtr, name);
		}

		public bool addDnsServer(string ip)
		{
			return tinyWRAPPINVOKE.SipStack_addDnsServer(this.swigCPtr, ip);
		}

		public bool setDnsDiscovery(bool enabled)
		{
			return tinyWRAPPINVOKE.SipStack_setDnsDiscovery(this.swigCPtr, enabled);
		}

		public bool setAoR(string ip, int port)
		{
			return tinyWRAPPINVOKE.SipStack_setAoR(this.swigCPtr, ip, port);
		}

		public bool setSigCompParams(uint dms, uint sms, uint cpb, bool enablePresDict)
		{
			return tinyWRAPPINVOKE.SipStack_setSigCompParams(this.swigCPtr, dms, sms, cpb, enablePresDict);
		}

		public bool addSigCompCompartment(string compId)
		{
			return tinyWRAPPINVOKE.SipStack_addSigCompCompartment(this.swigCPtr, compId);
		}

		public bool removeSigCompCompartment(string compId)
		{
			return tinyWRAPPINVOKE.SipStack_removeSigCompCompartment(this.swigCPtr, compId);
		}

		public bool setSTUNEnabledForICE(bool enabled)
		{
			return tinyWRAPPINVOKE.SipStack_setSTUNEnabledForICE(this.swigCPtr, enabled);
		}

		public bool setSTUNServer(string hostname, ushort port)
		{
			return tinyWRAPPINVOKE.SipStack_setSTUNServer(this.swigCPtr, hostname, port);
		}

		public bool setSTUNCred(string login, string password)
		{
			return tinyWRAPPINVOKE.SipStack_setSTUNCred(this.swigCPtr, login, password);
		}

		public bool setSTUNEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.SipStack_setSTUNEnabled(this.swigCPtr, enabled);
		}

		public bool setTLSSecAgree(bool enabled)
		{
			return tinyWRAPPINVOKE.SipStack_setTLSSecAgree(this.swigCPtr, enabled);
		}

		public bool setSSLCertificates(string privKey, string pubKey, string caKey, bool verify)
		{
			return tinyWRAPPINVOKE.SipStack_setSSLCertificates__SWIG_0(this.swigCPtr, privKey, pubKey, caKey, verify);
		}

		public bool setSSLCertificates(string privKey, string pubKey, string caKey)
		{
			return tinyWRAPPINVOKE.SipStack_setSSLCertificates__SWIG_1(this.swigCPtr, privKey, pubKey, caKey);
		}

		public bool setSSLCretificates(string privKey, string pubKey, string caKey, bool verify)
		{
			return tinyWRAPPINVOKE.SipStack_setSSLCretificates__SWIG_0(this.swigCPtr, privKey, pubKey, caKey, verify);
		}

		public bool setSSLCretificates(string privKey, string pubKey, string caKey)
		{
			return tinyWRAPPINVOKE.SipStack_setSSLCretificates__SWIG_1(this.swigCPtr, privKey, pubKey, caKey);
		}

		public bool setIPSecSecAgree(bool enabled)
		{
			return tinyWRAPPINVOKE.SipStack_setIPSecSecAgree(this.swigCPtr, enabled);
		}

		public bool setIPSecParameters(string algo, string ealgo, string mode, string proto)
		{
			return tinyWRAPPINVOKE.SipStack_setIPSecParameters(this.swigCPtr, algo, ealgo, mode, proto);
		}

		public string dnsENUM(string service, string e164num, string domain)
		{
			return tinyWRAPPINVOKE.SipStack_dnsENUM(this.swigCPtr, service, e164num, domain);
		}

		public string dnsNaptrSrv(string domain, string service, out ushort OUTPUT)
		{
			return tinyWRAPPINVOKE.SipStack_dnsNaptrSrv(this.swigCPtr, domain, service, out OUTPUT);
		}

		public string dnsSrv(string service, out ushort OUTPUT)
		{
			return tinyWRAPPINVOKE.SipStack_dnsSrv(this.swigCPtr, service, out OUTPUT);
		}

		public bool setMaxFDs(uint max_fds)
		{
			return tinyWRAPPINVOKE.SipStack_setMaxFDs(this.swigCPtr, max_fds);
		}

		public string getLocalIPnPort(string protocol, out ushort OUTPUT)
		{
			return tinyWRAPPINVOKE.SipStack_getLocalIPnPort(this.swigCPtr, protocol, out OUTPUT);
		}

		public string getPreferredIdentity()
		{
			return tinyWRAPPINVOKE.SipStack_getPreferredIdentity(this.swigCPtr);
		}

		public bool isValid()
		{
			return tinyWRAPPINVOKE.SipStack_isValid(this.swigCPtr);
		}

		public bool stop()
		{
			return tinyWRAPPINVOKE.SipStack_stop(this.swigCPtr);
		}

		public static bool initialize()
		{
			return tinyWRAPPINVOKE.SipStack_initialize();
		}

		public static bool deInitialize()
		{
			return tinyWRAPPINVOKE.SipStack_deInitialize();
		}

		public static void setCodecs(tmedia_codec_id_t codecs)
		{
			tinyWRAPPINVOKE.SipStack_setCodecs((int)codecs);
		}

		public static void setCodecs_2(long codecs)
		{
			tinyWRAPPINVOKE.SipStack_setCodecs_2(codecs);
		}

		public static bool setCodecPriority(tmedia_codec_id_t codec_id, int priority)
		{
			return tinyWRAPPINVOKE.SipStack_setCodecPriority((int)codec_id, priority);
		}

		public static bool setCodecPriority_2(int codec, int priority)
		{
			return tinyWRAPPINVOKE.SipStack_setCodecPriority_2(codec, priority);
		}

		public static bool isCodecSupported(tmedia_codec_id_t codec_id)
		{
			return tinyWRAPPINVOKE.SipStack_isCodecSupported((int)codec_id);
		}

		public static bool isIPSecSupported()
		{
			return tinyWRAPPINVOKE.SipStack_isIPSecSupported();
		}
	}
}
