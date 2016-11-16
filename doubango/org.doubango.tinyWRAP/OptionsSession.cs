using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class OptionsSession : SipSession
	{
		private HandleRef swigCPtr;

		internal OptionsSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.OptionsSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(OptionsSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~OptionsSession()
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
						tinyWRAPPINVOKE.delete_OptionsSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public OptionsSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_OptionsSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool send(ActionConfig config)
		{
			return tinyWRAPPINVOKE.OptionsSession_send__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool send()
		{
			return tinyWRAPPINVOKE.OptionsSession_send__SWIG_1(this.swigCPtr);
		}

		public bool accept(ActionConfig config)
		{
			return tinyWRAPPINVOKE.OptionsSession_accept__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool accept()
		{
			return tinyWRAPPINVOKE.OptionsSession_accept__SWIG_1(this.swigCPtr);
		}

		public bool reject(ActionConfig config)
		{
			return tinyWRAPPINVOKE.OptionsSession_reject__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool reject()
		{
			return tinyWRAPPINVOKE.OptionsSession_reject__SWIG_1(this.swigCPtr);
		}
	}
}
