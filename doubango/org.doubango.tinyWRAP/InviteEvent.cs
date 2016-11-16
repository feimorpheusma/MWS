using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class InviteEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal InviteEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.InviteEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(InviteEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~InviteEvent()
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
						tinyWRAPPINVOKE.delete_InviteEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_invite_event_type_t getType()
		{
			return (tsip_invite_event_type_t)tinyWRAPPINVOKE.InviteEvent_getType(this.swigCPtr);
		}

		public twrap_media_type_t getMediaType()
		{
			return (twrap_media_type_t)tinyWRAPPINVOKE.InviteEvent_getMediaType(this.swigCPtr);
		}

		public InviteSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.InviteEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new InviteSession(cPtr, false);
		}

		public CallSession takeCallSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.InviteEvent_takeCallSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new CallSession(cPtr, true);
		}

		public MsrpSession takeMsrpSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.InviteEvent_takeMsrpSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new MsrpSession(cPtr, true);
		}
	}
}
