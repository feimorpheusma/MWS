using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MessagingSession : SipSession
	{
		private HandleRef swigCPtr;

		internal MessagingSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.MessagingSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MessagingSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MessagingSession()
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
						tinyWRAPPINVOKE.delete_MessagingSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public bool send(byte[] buffer)
		{
			IntPtr ptr = Marshal.AllocHGlobal(buffer.Length);
			Marshal.Copy(buffer, 0, ptr, buffer.Length);
			bool ret = this.send(ptr, (uint)buffer.Length);
			Marshal.FreeHGlobal(ptr);
			return ret;
		}

		public MessagingSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_MessagingSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool send(IntPtr payload, uint len, ActionConfig config)
		{
			return tinyWRAPPINVOKE.MessagingSession_send__SWIG_0(this.swigCPtr, payload, len, ActionConfig.getCPtr(config));
		}

		public bool send(IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.MessagingSession_send__SWIG_1(this.swigCPtr, payload, len);
		}

		public bool accept(ActionConfig config)
		{
			return tinyWRAPPINVOKE.MessagingSession_accept__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool accept()
		{
			return tinyWRAPPINVOKE.MessagingSession_accept__SWIG_1(this.swigCPtr);
		}

		public bool reject(ActionConfig config)
		{
			return tinyWRAPPINVOKE.MessagingSession_reject__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool reject()
		{
			return tinyWRAPPINVOKE.MessagingSession_reject__SWIG_1(this.swigCPtr);
		}
	}
}
