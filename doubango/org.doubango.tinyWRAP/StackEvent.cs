using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class StackEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal StackEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.StackEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(StackEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~StackEvent()
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
						tinyWRAPPINVOKE.delete_StackEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}
	}
}
