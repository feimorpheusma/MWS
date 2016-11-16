using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SipMessage : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SipMessage(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SipMessage obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SipMessage()
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
						tinyWRAPPINVOKE.delete_SipMessage(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public byte[] getSipContent()
		{
			uint clen = this.getSipContentLength();
			byte[] result;
			if (clen > 0u)
			{
				IntPtr ptr = Marshal.AllocHGlobal((int)clen);
				this.getSipContent(ptr, clen);
				byte[] bytes = new byte[clen];
				Marshal.Copy(ptr, bytes, 0, bytes.Length);
				Marshal.FreeHGlobal(ptr);
				result = bytes;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public SipMessage() : this(tinyWRAPPINVOKE.new_SipMessage(), true)
		{
		}

		public bool isResponse()
		{
			return tinyWRAPPINVOKE.SipMessage_isResponse(this.swigCPtr);
		}

		public tsip_request_type_t getRequestType()
		{
			return (tsip_request_type_t)tinyWRAPPINVOKE.SipMessage_getRequestType(this.swigCPtr);
		}

		public short getResponseCode()
		{
			return tinyWRAPPINVOKE.SipMessage_getResponseCode(this.swigCPtr);
		}

		public string getResponsePhrase()
		{
			return tinyWRAPPINVOKE.SipMessage_getResponsePhrase(this.swigCPtr);
		}

		public string getSipHeaderValue(string name, uint index)
		{
			return tinyWRAPPINVOKE.SipMessage_getSipHeaderValue__SWIG_0(this.swigCPtr, name, index);
		}

		public string getSipHeaderValue(string name)
		{
			return tinyWRAPPINVOKE.SipMessage_getSipHeaderValue__SWIG_1(this.swigCPtr, name);
		}

		public string getSipHeaderParamValue(string name, string param, uint index)
		{
			return tinyWRAPPINVOKE.SipMessage_getSipHeaderParamValue__SWIG_0(this.swigCPtr, name, param, index);
		}

		public string getSipHeaderParamValue(string name, string param)
		{
			return tinyWRAPPINVOKE.SipMessage_getSipHeaderParamValue__SWIG_1(this.swigCPtr, name, param);
		}

		public uint getSipContentLength()
		{
			return tinyWRAPPINVOKE.SipMessage_getSipContentLength(this.swigCPtr);
		}

		public uint getSipContent(IntPtr output, uint maxsize)
		{
			return tinyWRAPPINVOKE.SipMessage_getSipContent(this.swigCPtr, output, maxsize);
		}

		public SdpMessage getSdpMessage()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SipMessage_getSdpMessage(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new SdpMessage(cPtr, false);
		}
	}
}
