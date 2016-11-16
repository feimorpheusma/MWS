using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class T140CallbackData : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal T140CallbackData(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(T140CallbackData obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~T140CallbackData()
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
						tinyWRAPPINVOKE.delete_T140CallbackData(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public tmedia_t140_data_type_t getType()
		{
			return (tmedia_t140_data_type_t)tinyWRAPPINVOKE.T140CallbackData_getType(this.swigCPtr);
		}

		public uint getSize()
		{
			return tinyWRAPPINVOKE.T140CallbackData_getSize(this.swigCPtr);
		}

		public uint getData(IntPtr pOutput, uint nMaxsize)
		{
			return tinyWRAPPINVOKE.T140CallbackData_getData(this.swigCPtr, pOutput, nMaxsize);
		}
	}
}
