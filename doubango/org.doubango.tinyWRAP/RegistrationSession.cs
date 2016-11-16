using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class RegistrationSession : SipSession
	{
		private HandleRef swigCPtr;

		internal RegistrationSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.RegistrationSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(RegistrationSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~RegistrationSession()
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
						tinyWRAPPINVOKE.delete_RegistrationSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public RegistrationSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_RegistrationSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool register_(ActionConfig config)
		{
			return tinyWRAPPINVOKE.RegistrationSession_register___SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool register_()
		{
			return tinyWRAPPINVOKE.RegistrationSession_register___SWIG_1(this.swigCPtr);
		}

		public bool unRegister(ActionConfig config)
		{
			return tinyWRAPPINVOKE.RegistrationSession_unRegister__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool unRegister()
		{
			return tinyWRAPPINVOKE.RegistrationSession_unRegister__SWIG_1(this.swigCPtr);
		}

		public bool accept(ActionConfig config)
		{
			return tinyWRAPPINVOKE.RegistrationSession_accept__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool accept()
		{
			return tinyWRAPPINVOKE.RegistrationSession_accept__SWIG_1(this.swigCPtr);
		}

		public bool reject(ActionConfig config)
		{
			return tinyWRAPPINVOKE.RegistrationSession_reject__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool reject()
		{
			return tinyWRAPPINVOKE.RegistrationSession_reject__SWIG_1(this.swigCPtr);
		}
	}
}
