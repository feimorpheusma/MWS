using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyAudioConsumer : ProxyPlugin
	{
		private HandleRef swigCPtr;

		internal ProxyAudioConsumer(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.ProxyAudioConsumer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyAudioConsumer obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyAudioConsumer()
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
						tinyWRAPPINVOKE.delete_ProxyAudioConsumer(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public bool setActualSndCardPlaybackParams(int nPtime, int nRate, int nChannels)
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_setActualSndCardPlaybackParams(this.swigCPtr, nPtime, nRate, nChannels);
		}

		public bool queryForResampler(ushort nInFreq, ushort nOutFreq, ushort nFrameDuration, ushort nChannels, ushort nResamplerQuality)
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_queryForResampler(this.swigCPtr, nInFreq, nOutFreq, nFrameDuration, nChannels, nResamplerQuality);
		}

		public bool setPullBuffer(IntPtr pPullBufferPtr, uint nPullBufferSize)
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_setPullBuffer(this.swigCPtr, pPullBufferPtr, nPullBufferSize);
		}

		public uint pull(IntPtr pOutput, uint nSize)
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_pull__SWIG_0(this.swigCPtr, pOutput, nSize);
		}

		public uint pull(IntPtr pOutput)
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_pull__SWIG_1(this.swigCPtr, pOutput);
		}

		public uint pull()
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_pull__SWIG_2(this.swigCPtr);
		}

		public bool setGain(uint nGain)
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_setGain(this.swigCPtr, nGain);
		}

		public uint getGain()
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_getGain(this.swigCPtr);
		}

		public bool reset()
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_reset(this.swigCPtr);
		}

		public void setCallback(ProxyAudioConsumerCallback pCallback)
		{
			tinyWRAPPINVOKE.ProxyAudioConsumer_setCallback(this.swigCPtr, ProxyAudioConsumerCallback.getCPtr(pCallback));
		}

		public virtual ulong getMediaSessionId()
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_getMediaSessionId(this.swigCPtr);
		}

		public static bool registerPlugin()
		{
			return tinyWRAPPINVOKE.ProxyAudioConsumer_registerPlugin();
		}
	}
}
