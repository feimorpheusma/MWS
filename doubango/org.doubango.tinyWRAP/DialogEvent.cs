using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class DialogEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal DialogEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.DialogEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(DialogEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~DialogEvent()
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
						tinyWRAPPINVOKE.delete_DialogEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}
	}
}
