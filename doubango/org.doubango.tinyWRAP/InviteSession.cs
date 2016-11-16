using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class InviteSession : SipSession
	{
		private HandleRef swigCPtr;

		internal InviteSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.InviteSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(InviteSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~InviteSession()
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
						tinyWRAPPINVOKE.delete_InviteSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public InviteSession(SipStack Stack) : this(tinyWRAPPINVOKE.new_InviteSession(SipStack.getCPtr(Stack)), true)
		{
		}

		public bool accept(ActionConfig config)
		{
			return tinyWRAPPINVOKE.InviteSession_accept__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool accept()
		{
			return tinyWRAPPINVOKE.InviteSession_accept__SWIG_1(this.swigCPtr);
		}

		public bool hangup(ActionConfig config)
		{
			return tinyWRAPPINVOKE.InviteSession_hangup__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool hangup()
		{
			return tinyWRAPPINVOKE.InviteSession_hangup__SWIG_1(this.swigCPtr);
		}

		public bool reject(ActionConfig config)
		{
			return tinyWRAPPINVOKE.InviteSession_reject__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool reject()
		{
			return tinyWRAPPINVOKE.InviteSession_reject__SWIG_1(this.swigCPtr);
		}

		public bool sendInfo(IntPtr payload, uint len, ActionConfig config)
		{
			return tinyWRAPPINVOKE.InviteSession_sendInfo__SWIG_0(this.swigCPtr, payload, len, ActionConfig.getCPtr(config));
		}

		public bool sendInfo(IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.InviteSession_sendInfo__SWIG_1(this.swigCPtr, payload, len);
		}

		public MediaSessionMgr getMediaMgr()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.InviteSession_getMediaMgr(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new MediaSessionMgr(cPtr, false);
		}
	}
}
