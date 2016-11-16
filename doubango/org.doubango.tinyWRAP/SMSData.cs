using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SMSData : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SMSData(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SMSData obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SMSData()
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
						tinyWRAPPINVOKE.delete_SMSData(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public byte[] getPayload()
		{
			uint clen = this.getPayloadLength();
			byte[] result;
			if (clen > 0u)
			{
				IntPtr ptr = Marshal.AllocHGlobal((int)clen);
				this.getPayload(ptr, clen);
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

		public SMSData() : this(tinyWRAPPINVOKE.new_SMSData(), true)
		{
		}

		public twrap_sms_type_t getType()
		{
			return (twrap_sms_type_t)tinyWRAPPINVOKE.SMSData_getType(this.swigCPtr);
		}

		public int getMR()
		{
			return tinyWRAPPINVOKE.SMSData_getMR(this.swigCPtr);
		}

		public uint getPayloadLength()
		{
			return tinyWRAPPINVOKE.SMSData_getPayloadLength(this.swigCPtr);
		}

		public uint getPayload(IntPtr output, uint maxsize)
		{
			return tinyWRAPPINVOKE.SMSData_getPayload(this.swigCPtr, output, maxsize);
		}

		public string getOA()
		{
			return tinyWRAPPINVOKE.SMSData_getOA(this.swigCPtr);
		}

		public string getDA()
		{
			return tinyWRAPPINVOKE.SMSData_getDA(this.swigCPtr);
		}
	}
}
