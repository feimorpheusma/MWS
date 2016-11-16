using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class AudioResampler : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal AudioResampler(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(AudioResampler obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~AudioResampler()
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
						tinyWRAPPINVOKE.delete_AudioResampler(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public AudioResampler(uint nInFreq, uint nOutFreq, uint nFrameDuration, uint nChannels, uint nQuality) : this(tinyWRAPPINVOKE.new_AudioResampler(nInFreq, nOutFreq, nFrameDuration, nChannels, nQuality), true)
		{
		}

		public bool isValid()
		{
			return tinyWRAPPINVOKE.AudioResampler_isValid(this.swigCPtr);
		}

		public uint getOutputRequiredSizeInShort()
		{
			return tinyWRAPPINVOKE.AudioResampler_getOutputRequiredSizeInShort(this.swigCPtr);
		}

		public uint getInputRequiredSizeInShort()
		{
			return tinyWRAPPINVOKE.AudioResampler_getInputRequiredSizeInShort(this.swigCPtr);
		}

		public uint process(IntPtr pInData, uint nInSizeInBytes, IntPtr pOutData, uint nOutSizeInBytes)
		{
			return tinyWRAPPINVOKE.AudioResampler_process(this.swigCPtr, pInData, nInSizeInBytes, pOutData, nOutSizeInBytes);
		}
	}
}
