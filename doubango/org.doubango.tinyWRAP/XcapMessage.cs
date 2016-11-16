using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class XcapMessage : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal XcapMessage(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(XcapMessage obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~XcapMessage()
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
						tinyWRAPPINVOKE.delete_XcapMessage(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public XcapMessage() : this(tinyWRAPPINVOKE.new_XcapMessage(), true)
		{
		}

		public short getCode()
		{
			return tinyWRAPPINVOKE.XcapMessage_getCode(this.swigCPtr);
		}

		public string getPhrase()
		{
			return tinyWRAPPINVOKE.XcapMessage_getPhrase(this.swigCPtr);
		}

		public string getXcapHeaderValue(string name, uint index)
		{
			return tinyWRAPPINVOKE.XcapMessage_getXcapHeaderValue__SWIG_0(this.swigCPtr, name, index);
		}

		public string getXcapHeaderValue(string name)
		{
			return tinyWRAPPINVOKE.XcapMessage_getXcapHeaderValue__SWIG_1(this.swigCPtr, name);
		}

		public string getXcapHeaderParamValue(string name, string param, uint index)
		{
			return tinyWRAPPINVOKE.XcapMessage_getXcapHeaderParamValue__SWIG_0(this.swigCPtr, name, param, index);
		}

		public string getXcapHeaderParamValue(string name, string param)
		{
			return tinyWRAPPINVOKE.XcapMessage_getXcapHeaderParamValue__SWIG_1(this.swigCPtr, name, param);
		}

		public uint getXcapContentLength()
		{
			return tinyWRAPPINVOKE.XcapMessage_getXcapContentLength(this.swigCPtr);
		}

		public uint getXcapContent(IntPtr output, uint maxsize)
		{
			return tinyWRAPPINVOKE.XcapMessage_getXcapContent(this.swigCPtr, output, maxsize);
		}
	}
}
