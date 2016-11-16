using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SipUri : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SipUri(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SipUri obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SipUri()
		{
			this.Dispose();
		}

		public virtual void Dispose()
		{
			lock (this)
			{
				if (this.swigCPtr.Handle != IntPtr.Zero)
				{
					if (this.swigCMemOwn)
					{
						this.swigCMemOwn = false;
						tinyWRAPPINVOKE.delete_SipUri(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public SipUri(string uriString, string displayName) : this(tinyWRAPPINVOKE.new_SipUri__SWIG_0(uriString, displayName), true)
		{
		}

		public SipUri(string uriString) : this(tinyWRAPPINVOKE.new_SipUri__SWIG_1(uriString), true)
		{
		}

		public static bool isValid(string arg0)
		{
			return tinyWRAPPINVOKE.SipUri_isValid__SWIG_0(arg0);
		}

		public bool isValid()
		{
			return tinyWRAPPINVOKE.SipUri_isValid__SWIG_1(this.swigCPtr);
		}

		public string getScheme()
		{
			return tinyWRAPPINVOKE.SipUri_getScheme(this.swigCPtr);
		}

		public string getHost()
		{
			return tinyWRAPPINVOKE.SipUri_getHost(this.swigCPtr);
		}

		public ushort getPort()
		{
			return tinyWRAPPINVOKE.SipUri_getPort(this.swigCPtr);
		}

		public string getUserName()
		{
			return tinyWRAPPINVOKE.SipUri_getUserName(this.swigCPtr);
		}

		public string getPassword()
		{
			return tinyWRAPPINVOKE.SipUri_getPassword(this.swigCPtr);
		}

		public string getDisplayName()
		{
			return tinyWRAPPINVOKE.SipUri_getDisplayName(this.swigCPtr);
		}

		public string getParamValue(string pname)
		{
			return tinyWRAPPINVOKE.SipUri_getParamValue(this.swigCPtr, pname);
		}

		public void setDisplayName(string displayName)
		{
			tinyWRAPPINVOKE.SipUri_setDisplayName(this.swigCPtr, displayName);
		}
	}
}
