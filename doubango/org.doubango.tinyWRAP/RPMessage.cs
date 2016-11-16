using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class RPMessage : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal RPMessage(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(RPMessage obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~RPMessage()
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
						tinyWRAPPINVOKE.delete_RPMessage(this.swigCPtr);
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

		public RPMessage() : this(tinyWRAPPINVOKE.new_RPMessage(), true)
		{
		}

		public twrap_rpmessage_type_t getType()
		{
			return (twrap_rpmessage_type_t)tinyWRAPPINVOKE.RPMessage_getType(this.swigCPtr);
		}

		public uint getPayloadLength()
		{
			return tinyWRAPPINVOKE.RPMessage_getPayloadLength(this.swigCPtr);
		}

		public uint getPayload(IntPtr output, uint maxsize)
		{
			return tinyWRAPPINVOKE.RPMessage_getPayload(this.swigCPtr, output, maxsize);
		}
	}
}
