using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class OptionsEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal OptionsEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.OptionsEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(OptionsEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~OptionsEvent()
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
						tinyWRAPPINVOKE.delete_OptionsEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_options_event_type_t getType()
		{
			return (tsip_options_event_type_t)tinyWRAPPINVOKE.OptionsEvent_getType(this.swigCPtr);
		}

		public OptionsSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.OptionsEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new OptionsSession(cPtr, false);
		}

		public OptionsSession takeSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.OptionsEvent_takeSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new OptionsSession(cPtr, false);
		}
	}
}
