using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyVideoConsumer : ProxyPlugin
	{
		private HandleRef swigCPtr;

		internal ProxyVideoConsumer(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.ProxyVideoConsumer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyVideoConsumer obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyVideoConsumer()
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
						tinyWRAPPINVOKE.delete_ProxyVideoConsumer(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public bool setDisplaySize(uint nWidth, uint nHeight)
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_setDisplaySize(this.swigCPtr, nWidth, nHeight);
		}

		public uint getDisplayWidth()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_getDisplayWidth(this.swigCPtr);
		}

		public uint getDisplayHeight()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_getDisplayHeight(this.swigCPtr);
		}

		public uint getDecodedWidth()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_getDecodedWidth(this.swigCPtr);
		}

		public uint getDecodedHeight()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_getDecodedHeight(this.swigCPtr);
		}

		public void setCallback(ProxyVideoConsumerCallback pCallback)
		{
			tinyWRAPPINVOKE.ProxyVideoConsumer_setCallback(this.swigCPtr, ProxyVideoConsumerCallback.getCPtr(pCallback));
		}

		public bool setAutoResizeDisplay(bool bAutoResizeDisplay)
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_setAutoResizeDisplay(this.swigCPtr, bAutoResizeDisplay);
		}

		public bool getAutoResizeDisplay()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_getAutoResizeDisplay(this.swigCPtr);
		}

		public bool setConsumeBuffer(IntPtr pConsumeBufferPtr, uint nConsumeBufferSize)
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_setConsumeBuffer(this.swigCPtr, pConsumeBufferPtr, nConsumeBufferSize);
		}

		public uint pull(IntPtr pOutput, uint nSize)
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_pull(this.swigCPtr, pOutput, nSize);
		}

		public bool reset()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_reset(this.swigCPtr);
		}

		public virtual ulong getMediaSessionId()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_getMediaSessionId(this.swigCPtr);
		}

		public static bool registerPlugin()
		{
			return tinyWRAPPINVOKE.ProxyVideoConsumer_registerPlugin();
		}

		public static void setDefaultChroma(tmedia_chroma_t eChroma)
		{
			tinyWRAPPINVOKE.ProxyVideoConsumer_setDefaultChroma((int)eChroma);
		}

		public static void setDefaultAutoResizeDisplay(bool bAutoResizeDisplay)
		{
			tinyWRAPPINVOKE.ProxyVideoConsumer_setDefaultAutoResizeDisplay(bAutoResizeDisplay);
		}
	}
}
