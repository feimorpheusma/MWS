using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class XcapStack : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal XcapStack(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(XcapStack obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~XcapStack()
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
						tinyWRAPPINVOKE.delete_XcapStack(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public bool putElement(string url, byte[] payload)
		{
			IntPtr ptr = Marshal.AllocHGlobal(payload.Length);
			Marshal.Copy(payload, 0, ptr, payload.Length);
			bool ret = this.putElement(url, ptr, (uint)payload.Length);
			Marshal.FreeHGlobal(ptr);
			return ret;
		}

		public bool putAttribute(string url, byte[] payload)
		{
			IntPtr ptr = Marshal.AllocHGlobal(payload.Length);
			Marshal.Copy(payload, 0, ptr, payload.Length);
			bool ret = this.putAttribute(url, ptr, (uint)payload.Length);
			Marshal.FreeHGlobal(ptr);
			return ret;
		}

		public bool putDocument(string url, byte[] payload, string contentType)
		{
			IntPtr ptr = Marshal.AllocHGlobal(payload.Length);
			Marshal.Copy(payload, 0, ptr, payload.Length);
			bool ret = this.putDocument(url, ptr, (uint)payload.Length, contentType);
			Marshal.FreeHGlobal(ptr);
			return ret;
		}

		public XcapStack(XcapCallback callback, string xui, string password, string xcap_root) : this(tinyWRAPPINVOKE.new_XcapStack(XcapCallback.getCPtr(callback), xui, password, xcap_root), true)
		{
		}

		public bool registerAUID(string id, string mime_type, string ns, string document_name, bool is_global)
		{
			return tinyWRAPPINVOKE.XcapStack_registerAUID(this.swigCPtr, id, mime_type, ns, document_name, is_global);
		}

		public bool start()
		{
			return tinyWRAPPINVOKE.XcapStack_start(this.swigCPtr);
		}

		public bool setCredentials(string xui, string password)
		{
			return tinyWRAPPINVOKE.XcapStack_setCredentials(this.swigCPtr, xui, password);
		}

		public bool setXcapRoot(string xcap_root)
		{
			return tinyWRAPPINVOKE.XcapStack_setXcapRoot(this.swigCPtr, xcap_root);
		}

		public bool setLocalIP(string ip)
		{
			return tinyWRAPPINVOKE.XcapStack_setLocalIP(this.swigCPtr, ip);
		}

		public bool setLocalPort(uint port)
		{
			return tinyWRAPPINVOKE.XcapStack_setLocalPort(this.swigCPtr, port);
		}

		public bool addHeader(string name, string value)
		{
			return tinyWRAPPINVOKE.XcapStack_addHeader(this.swigCPtr, name, value);
		}

		public bool removeHeader(string name)
		{
			return tinyWRAPPINVOKE.XcapStack_removeHeader(this.swigCPtr, name);
		}

		public bool setTimeout(uint timeout)
		{
			return tinyWRAPPINVOKE.XcapStack_setTimeout(this.swigCPtr, timeout);
		}

		public bool getDocument(string url)
		{
			return tinyWRAPPINVOKE.XcapStack_getDocument(this.swigCPtr, url);
		}

		public bool getElement(string url)
		{
			return tinyWRAPPINVOKE.XcapStack_getElement(this.swigCPtr, url);
		}

		public bool getAttribute(string url)
		{
			return tinyWRAPPINVOKE.XcapStack_getAttribute(this.swigCPtr, url);
		}

		public bool deleteDocument(string url)
		{
			return tinyWRAPPINVOKE.XcapStack_deleteDocument(this.swigCPtr, url);
		}

		public bool deleteElement(string url)
		{
			return tinyWRAPPINVOKE.XcapStack_deleteElement(this.swigCPtr, url);
		}

		public bool deleteAttribute(string url)
		{
			return tinyWRAPPINVOKE.XcapStack_deleteAttribute(this.swigCPtr, url);
		}

		public bool putDocument(string url, IntPtr payload, uint len, string contentType)
		{
			return tinyWRAPPINVOKE.XcapStack_putDocument(this.swigCPtr, url, payload, len, contentType);
		}

		public bool putElement(string url, IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.XcapStack_putElement(this.swigCPtr, url, payload, len);
		}

		public bool putAttribute(string url, IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.XcapStack_putAttribute(this.swigCPtr, url, payload, len);
		}

		public bool stop()
		{
			return tinyWRAPPINVOKE.XcapStack_stop(this.swigCPtr);
		}
	}
}
