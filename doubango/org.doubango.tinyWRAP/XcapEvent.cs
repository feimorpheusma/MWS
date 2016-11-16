using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class XcapEvent : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal XcapEvent(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(XcapEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~XcapEvent()
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
						tinyWRAPPINVOKE.delete_XcapEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public thttp_event_type_t getType()
		{
			return (thttp_event_type_t)tinyWRAPPINVOKE.XcapEvent_getType(this.swigCPtr);
		}

		public XcapMessage getXcapMessage()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapEvent_getXcapMessage(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new XcapMessage(cPtr, false);
		}
	}
}
