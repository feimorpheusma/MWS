using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MediaContent : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal MediaContent(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MediaContent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MediaContent()
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
						tinyWRAPPINVOKE.delete_MediaContent(this.swigCPtr);
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

		public string getType()
		{
			return tinyWRAPPINVOKE.MediaContent_getType(this.swigCPtr);
		}

		public virtual uint getDataLength()
		{
			return tinyWRAPPINVOKE.MediaContent_getDataLength(this.swigCPtr);
		}

		public virtual uint getData(IntPtr pOutput, uint nMaxsize)
		{
			return tinyWRAPPINVOKE.MediaContent_getData(this.swigCPtr, pOutput, nMaxsize);
		}

		public static MediaContent parse(IntPtr pData, uint nSize, string pType)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MediaContent_parse__SWIG_0(pData, nSize, pType);
			return (cPtr == IntPtr.Zero) ? null : new MediaContent(cPtr, true);
		}

		public static MediaContentCPIM parse(IntPtr pData, uint nSize)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MediaContent_parse__SWIG_1(pData, nSize);
			return (cPtr == IntPtr.Zero) ? null : new MediaContentCPIM(cPtr, true);
		}

		public virtual uint getPayloadLength()
		{
			return tinyWRAPPINVOKE.MediaContent_getPayloadLength(this.swigCPtr);
		}

		public virtual uint getPayload(IntPtr pOutput, uint nMaxsize)
		{
			return tinyWRAPPINVOKE.MediaContent_getPayload(this.swigCPtr, pOutput, nMaxsize);
		}
	}
}
