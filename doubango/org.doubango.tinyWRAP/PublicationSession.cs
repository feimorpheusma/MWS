using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class PublicationSession : SipSession
	{
		private HandleRef swigCPtr;

		internal PublicationSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.PublicationSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(PublicationSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~PublicationSession()
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
						tinyWRAPPINVOKE.delete_PublicationSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public PublicationSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_PublicationSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool publish(IntPtr payload, uint len, ActionConfig config)
		{
			return tinyWRAPPINVOKE.PublicationSession_publish__SWIG_0(this.swigCPtr, payload, len, ActionConfig.getCPtr(config));
		}

		public bool publish(IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.PublicationSession_publish__SWIG_1(this.swigCPtr, payload, len);
		}

		public bool unPublish(ActionConfig config)
		{
			return tinyWRAPPINVOKE.PublicationSession_unPublish__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool unPublish()
		{
			return tinyWRAPPINVOKE.PublicationSession_unPublish__SWIG_1(this.swigCPtr);
		}
	}
}
