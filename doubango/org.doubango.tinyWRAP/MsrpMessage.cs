using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MsrpMessage : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal MsrpMessage(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MsrpMessage obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MsrpMessage()
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
						tinyWRAPPINVOKE.delete_MsrpMessage(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public MsrpMessage() : this(tinyWRAPPINVOKE.new_MsrpMessage(), true)
		{
		}

		public bool isRequest()
		{
			return tinyWRAPPINVOKE.MsrpMessage_isRequest(this.swigCPtr);
		}

		public short getCode()
		{
			return tinyWRAPPINVOKE.MsrpMessage_getCode(this.swigCPtr);
		}

		public string getPhrase()
		{
			return tinyWRAPPINVOKE.MsrpMessage_getPhrase(this.swigCPtr);
		}

		public tmsrp_request_type_t getRequestType()
		{
			return (tmsrp_request_type_t)tinyWRAPPINVOKE.MsrpMessage_getRequestType(this.swigCPtr);
		}

		public void getByteRange(out long arg0, out long arg1, out long arg2)
		{
			tinyWRAPPINVOKE.MsrpMessage_getByteRange(this.swigCPtr, out arg0, out arg1, out arg2);
		}

		public bool isLastChunck()
		{
			return tinyWRAPPINVOKE.MsrpMessage_isLastChunck(this.swigCPtr);
		}

		public bool isFirstChunck()
		{
			return tinyWRAPPINVOKE.MsrpMessage_isFirstChunck(this.swigCPtr);
		}

		public bool isSuccessReport()
		{
			return tinyWRAPPINVOKE.MsrpMessage_isSuccessReport(this.swigCPtr);
		}

		public string getMsrpHeaderValue(string name)
		{
			return tinyWRAPPINVOKE.MsrpMessage_getMsrpHeaderValue(this.swigCPtr, name);
		}

		public string getMsrpHeaderParamValue(string name, string param)
		{
			return tinyWRAPPINVOKE.MsrpMessage_getMsrpHeaderParamValue(this.swigCPtr, name, param);
		}

		public uint getMsrpContentLength()
		{
			return tinyWRAPPINVOKE.MsrpMessage_getMsrpContentLength(this.swigCPtr);
		}

		public uint getMsrpContent(IntPtr output, uint maxsize)
		{
			return tinyWRAPPINVOKE.MsrpMessage_getMsrpContent(this.swigCPtr, output, maxsize);
		}
	}
}
