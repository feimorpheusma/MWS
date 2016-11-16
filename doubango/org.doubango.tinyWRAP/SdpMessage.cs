using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SdpMessage : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SdpMessage(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SdpMessage obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SdpMessage()
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
						tinyWRAPPINVOKE.delete_SdpMessage(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public SdpMessage() : this(tinyWRAPPINVOKE.new_SdpMessage(), true)
		{
		}

		public string getSdpHeaderValue(string media, char name, uint index)
		{
			return tinyWRAPPINVOKE.SdpMessage_getSdpHeaderValue__SWIG_0(this.swigCPtr, media, name, index);
		}

		public string getSdpHeaderValue(string media, char name)
		{
			return tinyWRAPPINVOKE.SdpMessage_getSdpHeaderValue__SWIG_1(this.swigCPtr, media, name);
		}

		public string getSdpHeaderAValue(string media, string attributeName)
		{
			return tinyWRAPPINVOKE.SdpMessage_getSdpHeaderAValue(this.swigCPtr, media, attributeName);
		}
	}
}
