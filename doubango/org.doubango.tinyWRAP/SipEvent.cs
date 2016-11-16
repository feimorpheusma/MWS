using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SipEvent : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SipEvent(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SipEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SipEvent()
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
						tinyWRAPPINVOKE.delete_SipEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public short getCode()
		{
			return tinyWRAPPINVOKE.SipEvent_getCode(this.swigCPtr);
		}

		public string getPhrase()
		{
			return tinyWRAPPINVOKE.SipEvent_getPhrase(this.swigCPtr);
		}

		public SipSession getBaseSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SipEvent_getBaseSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new SipSession(cPtr, false);
		}

		public SipMessage getSipMessage()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SipEvent_getSipMessage(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new SipMessage(cPtr, false);
		}
	}
}
