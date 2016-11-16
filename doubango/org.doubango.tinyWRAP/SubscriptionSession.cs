using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SubscriptionSession : SipSession
	{
		private HandleRef swigCPtr;

		internal SubscriptionSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.SubscriptionSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SubscriptionSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SubscriptionSession()
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
						tinyWRAPPINVOKE.delete_SubscriptionSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public SubscriptionSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_SubscriptionSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool subscribe()
		{
			return tinyWRAPPINVOKE.SubscriptionSession_subscribe(this.swigCPtr);
		}

		public bool unSubscribe()
		{
			return tinyWRAPPINVOKE.SubscriptionSession_unSubscribe(this.swigCPtr);
		}
	}
}
