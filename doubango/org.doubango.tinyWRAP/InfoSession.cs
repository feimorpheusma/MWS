using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class InfoSession : SipSession
	{
		private HandleRef swigCPtr;

		internal InfoSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.InfoSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(InfoSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~InfoSession()
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
						tinyWRAPPINVOKE.delete_InfoSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public bool send(byte[] buffer, ActionConfig config)
		{
			IntPtr ptr = Marshal.AllocHGlobal(buffer.Length);
			Marshal.Copy(buffer, 0, ptr, buffer.Length);
			bool ret = this.send(ptr, (uint)buffer.Length, config);
			Marshal.FreeHGlobal(ptr);
			return ret;
		}

		public InfoSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_InfoSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool send(IntPtr payload, uint len, ActionConfig config)
		{
			return tinyWRAPPINVOKE.InfoSession_send__SWIG_0(this.swigCPtr, payload, len, ActionConfig.getCPtr(config));
		}

		public bool send(IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.InfoSession_send__SWIG_1(this.swigCPtr, payload, len);
		}

		public bool accept(ActionConfig config)
		{
			return tinyWRAPPINVOKE.InfoSession_accept__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool accept()
		{
			return tinyWRAPPINVOKE.InfoSession_accept__SWIG_1(this.swigCPtr);
		}

		public bool reject(ActionConfig config)
		{
			return tinyWRAPPINVOKE.InfoSession_reject__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool reject()
		{
			return tinyWRAPPINVOKE.InfoSession_reject__SWIG_1(this.swigCPtr);
		}
	}
}
