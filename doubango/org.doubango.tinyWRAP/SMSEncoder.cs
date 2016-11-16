using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SMSEncoder : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal SMSEncoder(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SMSEncoder obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SMSEncoder()
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
						tinyWRAPPINVOKE.delete_SMSEncoder(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public static RPMessage encodeSubmit(int mr, string smsc, string destination, string ascii)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SMSEncoder_encodeSubmit(mr, smsc, destination, ascii);
			return (cPtr == IntPtr.Zero) ? null : new RPMessage(cPtr, true);
		}

		public static RPMessage encodeDeliver(int mr, string smsc, string originator, string ascii)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SMSEncoder_encodeDeliver(mr, smsc, originator, ascii);
			return (cPtr == IntPtr.Zero) ? null : new RPMessage(cPtr, true);
		}

		public static RPMessage encodeACK(int mr, string smsc, string destination, bool forSUBMIT)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SMSEncoder_encodeACK(mr, smsc, destination, forSUBMIT);
			return (cPtr == IntPtr.Zero) ? null : new RPMessage(cPtr, true);
		}

		public static RPMessage encodeError(int mr, string smsc, string destination, bool forSUBMIT)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SMSEncoder_encodeError(mr, smsc, destination, forSUBMIT);
			return (cPtr == IntPtr.Zero) ? null : new RPMessage(cPtr, true);
		}

		public static SMSData decode(IntPtr data, uint size, bool MobOrig)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SMSEncoder_decode(data, size, MobOrig);
			return (cPtr == IntPtr.Zero) ? null : new SMSData(cPtr, true);
		}
	}
}
