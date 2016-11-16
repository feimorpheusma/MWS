using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class InfoEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal InfoEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.InfoEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(InfoEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~InfoEvent()
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
						tinyWRAPPINVOKE.delete_InfoEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_info_event_type_t getType()
		{
			return (tsip_info_event_type_t)tinyWRAPPINVOKE.InfoEvent_getType(this.swigCPtr);
		}

		public InfoSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.InfoEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new InfoSession(cPtr, false);
		}

		public InfoSession takeSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.InfoEvent_takeSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new InfoSession(cPtr, false);
		}
	}
}
