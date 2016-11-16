using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class XcapSelector : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal XcapSelector(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(XcapSelector obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~XcapSelector()
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
						tinyWRAPPINVOKE.delete_XcapSelector(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public XcapSelector(XcapStack stack) : this(tinyWRAPPINVOKE.new_XcapSelector(XcapStack.getCPtr(stack)), true)
		{
		}

		public XcapSelector setAUID(string auid)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapSelector_setAUID(this.swigCPtr, auid);
			return (cPtr == IntPtr.Zero) ? null : new XcapSelector(cPtr, false);
		}

		public XcapSelector setName(string qname)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapSelector_setName(this.swigCPtr, qname);
			return (cPtr == IntPtr.Zero) ? null : new XcapSelector(cPtr, false);
		}

		public XcapSelector setAttribute(string qname, string att_qname, string att_value)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapSelector_setAttribute(this.swigCPtr, qname, att_qname, att_value);
			return (cPtr == IntPtr.Zero) ? null : new XcapSelector(cPtr, false);
		}

		public XcapSelector setPos(string qname, uint pos)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapSelector_setPos(this.swigCPtr, qname, pos);
			return (cPtr == IntPtr.Zero) ? null : new XcapSelector(cPtr, false);
		}

		public XcapSelector setPosAttribute(string qname, uint pos, string att_qname, string att_value)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapSelector_setPosAttribute(this.swigCPtr, qname, pos, att_qname, att_value);
			return (cPtr == IntPtr.Zero) ? null : new XcapSelector(cPtr, false);
		}

		public XcapSelector setNamespace(string prefix, string value)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.XcapSelector_setNamespace(this.swigCPtr, prefix, value);
			return (cPtr == IntPtr.Zero) ? null : new XcapSelector(cPtr, false);
		}

		public string getString()
		{
			return tinyWRAPPINVOKE.XcapSelector_getString(this.swigCPtr);
		}

		public void reset()
		{
			tinyWRAPPINVOKE.XcapSelector_reset(this.swigCPtr);
		}
	}
}
