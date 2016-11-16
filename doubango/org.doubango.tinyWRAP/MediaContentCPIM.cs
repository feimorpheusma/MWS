using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MediaContentCPIM : MediaContent
	{
		private HandleRef swigCPtr;

		internal MediaContentCPIM(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.MediaContentCPIM_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MediaContentCPIM obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MediaContentCPIM()
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
						tinyWRAPPINVOKE.delete_MediaContentCPIM(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public override uint getPayloadLength()
		{
			return tinyWRAPPINVOKE.MediaContentCPIM_getPayloadLength(this.swigCPtr);
		}

		public override uint getPayload(IntPtr pOutput, uint nMaxsize)
		{
			return tinyWRAPPINVOKE.MediaContentCPIM_getPayload(this.swigCPtr, pOutput, nMaxsize);
		}

		public string getHeaderValue(string pName)
		{
			return tinyWRAPPINVOKE.MediaContentCPIM_getHeaderValue(this.swigCPtr, pName);
		}
	}
}
