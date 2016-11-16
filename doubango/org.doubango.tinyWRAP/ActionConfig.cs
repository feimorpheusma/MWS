using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ActionConfig : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal ActionConfig(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ActionConfig obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ActionConfig()
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
						tinyWRAPPINVOKE.delete_ActionConfig(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public ActionConfig() : this(tinyWRAPPINVOKE.new_ActionConfig(), true)
		{
		}

		public bool addHeader(string name, string value)
		{
			return tinyWRAPPINVOKE.ActionConfig_addHeader(this.swigCPtr, name, value);
		}

		public bool addPayload(IntPtr payload, uint len)
		{
			return tinyWRAPPINVOKE.ActionConfig_addPayload(this.swigCPtr, payload, len);
		}

		public bool setActiveMedia(twrap_media_type_t type)
		{
			return tinyWRAPPINVOKE.ActionConfig_setActiveMedia(this.swigCPtr, (int)type);
		}

		public ActionConfig setResponseLine(short code, string phrase)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ActionConfig_setResponseLine(this.swigCPtr, code, phrase);
			return (cPtr == IntPtr.Zero) ? null : new ActionConfig(cPtr, false);
		}

		public ActionConfig setMediaString(twrap_media_type_t type, string key, string value)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ActionConfig_setMediaString(this.swigCPtr, (int)type, key, value);
			return (cPtr == IntPtr.Zero) ? null : new ActionConfig(cPtr, false);
		}

		public ActionConfig setMediaInt(twrap_media_type_t type, string key, int value)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.ActionConfig_setMediaInt(this.swigCPtr, (int)type, key, value);
			return (cPtr == IntPtr.Zero) ? null : new ActionConfig(cPtr, false);
		}
	}
}
