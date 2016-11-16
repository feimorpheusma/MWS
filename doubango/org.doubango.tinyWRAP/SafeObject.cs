using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SafeObject : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SafeObject(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SafeObject obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SafeObject()
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
						tinyWRAPPINVOKE.delete_SafeObject(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public SafeObject() : this(tinyWRAPPINVOKE.new_SafeObject(), true)
		{
		}

		public int Lock()
		{
			return tinyWRAPPINVOKE.SafeObject_Lock(this.swigCPtr);
		}

		public int UnLock()
		{
			return tinyWRAPPINVOKE.SafeObject_UnLock(this.swigCPtr);
		}
	}
}
