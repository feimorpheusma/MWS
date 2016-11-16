using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyPlugin : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal ProxyPlugin(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyPlugin obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyPlugin()
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
						tinyWRAPPINVOKE.delete_ProxyPlugin(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public twrap_proxy_plugin_type_t getType()
		{
			return (twrap_proxy_plugin_type_t)tinyWRAPPINVOKE.ProxyPlugin_getType(this.swigCPtr);
		}

		public ulong getId()
		{
			return tinyWRAPPINVOKE.ProxyPlugin_getId(this.swigCPtr);
		}
	}
}
