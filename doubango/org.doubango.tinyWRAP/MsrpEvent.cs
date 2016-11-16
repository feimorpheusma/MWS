using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MsrpEvent : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal MsrpEvent(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MsrpEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MsrpEvent()
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
						tinyWRAPPINVOKE.delete_MsrpEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public tmsrp_event_type_t getType()
		{
			return (tmsrp_event_type_t)tinyWRAPPINVOKE.MsrpEvent_getType(this.swigCPtr);
		}

		public MsrpSession getSipSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MsrpEvent_getSipSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new MsrpSession(cPtr, false);
		}

		public MsrpMessage getMessage()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MsrpEvent_getMessage(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new MsrpMessage(cPtr, false);
		}
	}
}
