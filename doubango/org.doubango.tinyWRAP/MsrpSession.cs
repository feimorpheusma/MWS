using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MsrpSession : InviteSession
	{
		private HandleRef swigCPtr;

		internal MsrpSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.MsrpSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MsrpSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MsrpSession()
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
						tinyWRAPPINVOKE.delete_MsrpSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public MsrpSession(SipStack pStack, MsrpCallback pCallback) : this(tinyWRAPPINVOKE.new_MsrpSession(SipStack.getCPtr(pStack), MsrpCallback.getCPtr(pCallback)), true)
		{
		}

		public bool setCallback(MsrpCallback pCallback)
		{
			return tinyWRAPPINVOKE.MsrpSession_setCallback(this.swigCPtr, MsrpCallback.getCPtr(pCallback));
		}

		public bool callMsrp(string remoteUriString, ActionConfig config)
		{
			return tinyWRAPPINVOKE.MsrpSession_callMsrp__SWIG_0(this.swigCPtr, remoteUriString, ActionConfig.getCPtr(config));
		}

		public bool callMsrp(string remoteUriString)
		{
			return tinyWRAPPINVOKE.MsrpSession_callMsrp__SWIG_1(this.swigCPtr, remoteUriString);
		}

		public bool callMsrp(SipUri remoteUri, ActionConfig config)
		{
			return tinyWRAPPINVOKE.MsrpSession_callMsrp__SWIG_2(this.swigCPtr, SipUri.getCPtr(remoteUri), ActionConfig.getCPtr(config));
		}

		public bool callMsrp(SipUri remoteUri)
		{
			return tinyWRAPPINVOKE.MsrpSession_callMsrp__SWIG_3(this.swigCPtr, SipUri.getCPtr(remoteUri));
		}

		public bool sendMessage(IntPtr payload, uint len, ActionConfig config)
		{
			return tinyWRAPPINVOKE.MsrpSession_sendMessage__SWIG_0(this.swigCPtr, payload, len, ActionConfig.getCPtr(config));
		}

		public bool sendMessage(IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.MsrpSession_sendMessage__SWIG_1(this.swigCPtr, payload, len);
		}

		public bool sendFile(ActionConfig config)
		{
			return tinyWRAPPINVOKE.MsrpSession_sendFile__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool sendFile()
		{
			return tinyWRAPPINVOKE.MsrpSession_sendFile__SWIG_1(this.swigCPtr);
		}
	}
}
