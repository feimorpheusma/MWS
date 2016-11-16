using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SipSession : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SipSession(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SipSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SipSession()
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
						tinyWRAPPINVOKE.delete_SipSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public SipSession(SipStack stack) : this(tinyWRAPPINVOKE.new_SipSession(SipStack.getCPtr(stack)), true)
		{
		}

		public bool haveOwnership()
		{
			return tinyWRAPPINVOKE.SipSession_haveOwnership(this.swigCPtr);
		}

		public bool addHeader(string name, string value)
		{
			return tinyWRAPPINVOKE.SipSession_addHeader(this.swigCPtr, name, value);
		}

		public bool removeHeader(string name)
		{
			return tinyWRAPPINVOKE.SipSession_removeHeader(this.swigCPtr, name);
		}

		public bool addCaps(string name, string value)
		{
			return tinyWRAPPINVOKE.SipSession_addCaps__SWIG_0(this.swigCPtr, name, value);
		}

		public bool addCaps(string name)
		{
			return tinyWRAPPINVOKE.SipSession_addCaps__SWIG_1(this.swigCPtr, name);
		}

		public bool removeCaps(string name)
		{
			return tinyWRAPPINVOKE.SipSession_removeCaps(this.swigCPtr, name);
		}

		public bool setExpires(uint expires)
		{
			return tinyWRAPPINVOKE.SipSession_setExpires(this.swigCPtr, expires);
		}

		public bool setFromUri(string fromUriString)
		{
			return tinyWRAPPINVOKE.SipSession_setFromUri__SWIG_0(this.swigCPtr, fromUriString);
		}

		public bool setFromUri(SipUri fromUri)
		{
			return tinyWRAPPINVOKE.SipSession_setFromUri__SWIG_1(this.swigCPtr, SipUri.getCPtr(fromUri));
		}

		public bool setToUri(string toUriString)
		{
			return tinyWRAPPINVOKE.SipSession_setToUri__SWIG_0(this.swigCPtr, toUriString);
		}

		public bool setToUri(SipUri toUri)
		{
			return tinyWRAPPINVOKE.SipSession_setToUri__SWIG_1(this.swigCPtr, SipUri.getCPtr(toUri));
		}

		public bool setSilentHangup(bool silent)
		{
			return tinyWRAPPINVOKE.SipSession_setSilentHangup(this.swigCPtr, silent);
		}

		public bool addSigCompCompartment(string compId)
		{
			return tinyWRAPPINVOKE.SipSession_addSigCompCompartment(this.swigCPtr, compId);
		}

		public bool removeSigCompCompartment()
		{
			return tinyWRAPPINVOKE.SipSession_removeSigCompCompartment(this.swigCPtr);
		}

		public uint getId()
		{
			return tinyWRAPPINVOKE.SipSession_getId(this.swigCPtr);
		}
	}
}
