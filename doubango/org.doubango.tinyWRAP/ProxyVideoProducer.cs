using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyVideoProducer : ProxyPlugin
	{
		private HandleRef swigCPtr;

		internal ProxyVideoProducer(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.ProxyVideoProducer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyVideoProducer obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyVideoProducer()
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
						tinyWRAPPINVOKE.delete_ProxyVideoProducer(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public int getRotation()
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_getRotation(this.swigCPtr);
		}

		public bool setRotation(int nRot)
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_setRotation(this.swigCPtr, nRot);
		}

		public bool getMirror()
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_getMirror(this.swigCPtr);
		}

		public bool setMirror(bool bMirror)
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_setMirror(this.swigCPtr, bMirror);
		}

		public bool setActualCameraOutputSize(uint nWidth, uint nHeight)
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_setActualCameraOutputSize(this.swigCPtr, nWidth, nHeight);
		}

		public int push(IntPtr pBuffer, uint nSize)
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_push(this.swigCPtr, pBuffer, nSize);
		}

		public void setCallback(ProxyVideoProducerCallback pCallback)
		{
			tinyWRAPPINVOKE.ProxyVideoProducer_setCallback(this.swigCPtr, ProxyVideoProducerCallback.getCPtr(pCallback));
		}

		public virtual ulong getMediaSessionId()
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_getMediaSessionId(this.swigCPtr);
		}

		public static bool registerPlugin()
		{
			return tinyWRAPPINVOKE.ProxyVideoProducer_registerPlugin();
		}

		public static void setDefaultChroma(tmedia_chroma_t eChroma)
		{
			tinyWRAPPINVOKE.ProxyVideoProducer_setDefaultChroma((int)eChroma);
		}
	}
}
