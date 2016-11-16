using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyPluginMgr : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal ProxyPluginMgr(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyPluginMgr obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyPluginMgr()
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
						tinyWRAPPINVOKE.delete_ProxyPluginMgr(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public static ProxyPluginMgr createInstance(ProxyPluginMgrCallback pCallback)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_createInstance(ProxyPluginMgrCallback.getCPtr(pCallback));
			return (cPtr == IntPtr.Zero) ? null : new ProxyPluginMgr(cPtr, true);
		}

		public static ProxyPluginMgr getInstance()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_getInstance();
			return (cPtr == IntPtr.Zero) ? null : new ProxyPluginMgr(cPtr, false);
		}

		public ProxyPlugin findPlugin(ulong id)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_findPlugin(this.swigCPtr, id);
			return (cPtr == IntPtr.Zero) ? null : new ProxyPlugin(cPtr, false);
		}

		public ProxyAudioConsumer findAudioConsumer(ulong id)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_findAudioConsumer(this.swigCPtr, id);
			return (cPtr == IntPtr.Zero) ? null : new ProxyAudioConsumer(cPtr, false);
		}

		public ProxyVideoConsumer findVideoConsumer(ulong id)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_findVideoConsumer(this.swigCPtr, id);
			return (cPtr == IntPtr.Zero) ? null : new ProxyVideoConsumer(cPtr, false);
		}

		public ProxyAudioProducer findAudioProducer(ulong id)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_findAudioProducer(this.swigCPtr, id);
			return (cPtr == IntPtr.Zero) ? null : new ProxyAudioProducer(cPtr, false);
		}

		public ProxyVideoProducer findVideoProducer(ulong id)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ProxyPluginMgr_findVideoProducer(this.swigCPtr, id);
			return (cPtr == IntPtr.Zero) ? null : new ProxyVideoProducer(cPtr, false);
		}
	}
}
