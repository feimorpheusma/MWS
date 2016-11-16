using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyVideoFrame : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal ProxyVideoFrame(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyVideoFrame obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyVideoFrame()
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
						tinyWRAPPINVOKE.delete_ProxyVideoFrame(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public uint getSize()
		{
			return tinyWRAPPINVOKE.ProxyVideoFrame_getSize(this.swigCPtr);
		}

		public uint getContent(IntPtr pOutput, uint nMaxsize)
		{
			return tinyWRAPPINVOKE.ProxyVideoFrame_getContent(this.swigCPtr, pOutput, nMaxsize);
		}

		public uint getFrameWidth()
		{
			return tinyWRAPPINVOKE.ProxyVideoFrame_getFrameWidth(this.swigCPtr);
		}

		public uint getFrameHeight()
		{
			return tinyWRAPPINVOKE.ProxyVideoFrame_getFrameHeight(this.swigCPtr);
		}
	}
}
