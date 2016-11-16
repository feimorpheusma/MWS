using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyAudioProducer : ProxyPlugin
	{
		private HandleRef swigCPtr;

		internal ProxyAudioProducer(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.ProxyAudioProducer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyAudioProducer obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyAudioProducer()
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
						tinyWRAPPINVOKE.delete_ProxyAudioProducer(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public bool setActualSndCardRecordParams(int nPtime, int nRate, int nChannels)
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_setActualSndCardRecordParams(this.swigCPtr, nPtime, nRate, nChannels);
		}

		public bool setPushBuffer(IntPtr pPushBufferPtr, uint nPushBufferSize, bool bUsePushCallback)
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_setPushBuffer__SWIG_0(this.swigCPtr, pPushBufferPtr, nPushBufferSize, bUsePushCallback);
		}

		public bool setPushBuffer(IntPtr pPushBufferPtr, uint nPushBufferSize)
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_setPushBuffer__SWIG_1(this.swigCPtr, pPushBufferPtr, nPushBufferSize);
		}

		public int push(IntPtr pBuffer, uint nSize)
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_push__SWIG_0(this.swigCPtr, pBuffer, nSize);
		}

		public int push(IntPtr pBuffer)
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_push__SWIG_1(this.swigCPtr, pBuffer);
		}

		public int push()
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_push__SWIG_2(this.swigCPtr);
		}

		public bool setGain(uint nGain)
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_setGain(this.swigCPtr, nGain);
		}

		public uint getGain()
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_getGain(this.swigCPtr);
		}

		public void setCallback(ProxyAudioProducerCallback pCallback)
		{
			tinyWRAPPINVOKE.ProxyAudioProducer_setCallback(this.swigCPtr, ProxyAudioProducerCallback.getCPtr(pCallback));
		}

		public virtual ulong getMediaSessionId()
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_getMediaSessionId(this.swigCPtr);
		}

		public static bool registerPlugin()
		{
			return tinyWRAPPINVOKE.ProxyAudioProducer_registerPlugin();
		}
	}
}
