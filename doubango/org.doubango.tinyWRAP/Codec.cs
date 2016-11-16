using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class Codec : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal Codec(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(Codec obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~Codec()
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
						tinyWRAPPINVOKE.delete_Codec(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public twrap_media_type_t getMediaType()
		{
			return (twrap_media_type_t)tinyWRAPPINVOKE.Codec_getMediaType(this.swigCPtr);
		}

		public string getName()
		{
			return tinyWRAPPINVOKE.Codec_getName(this.swigCPtr);
		}

		public string getDescription()
		{
			return tinyWRAPPINVOKE.Codec_getDescription(this.swigCPtr);
		}

		public string getNegFormat()
		{
			return tinyWRAPPINVOKE.Codec_getNegFormat(this.swigCPtr);
		}

		public int getAudioSamplingRate()
		{
			return tinyWRAPPINVOKE.Codec_getAudioSamplingRate(this.swigCPtr);
		}

		public int getAudioChannels()
		{
			return tinyWRAPPINVOKE.Codec_getAudioChannels(this.swigCPtr);
		}

		public int getAudioPTime()
		{
			return tinyWRAPPINVOKE.Codec_getAudioPTime(this.swigCPtr);
		}
	}
}
