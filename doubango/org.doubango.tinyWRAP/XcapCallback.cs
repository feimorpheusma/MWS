using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class XcapCallback : IDisposable
	{
		public delegate int SwigDelegateXcapCallback_0(IntPtr e);

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private XcapCallback.SwigDelegateXcapCallback_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(XcapEvent)
		};

		internal XcapCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(XcapCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~XcapCallback()
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
						tinyWRAPPINVOKE.delete_XcapCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public XcapCallback() : this(tinyWRAPPINVOKE.new_XcapCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int onEvent(XcapEvent e)
		{
			return this.SwigDerivedClassHasMethod("onEvent", XcapCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.XcapCallback_onEventSwigExplicitXcapCallback(this.swigCPtr, XcapEvent.getCPtr(e)) : tinyWRAPPINVOKE.XcapCallback_onEvent(this.swigCPtr, XcapEvent.getCPtr(e));
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("onEvent", XcapCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new XcapCallback.SwigDelegateXcapCallback_0(this.SwigDirectoronEvent);
			}
			tinyWRAPPINVOKE.XcapCallback_director_connect(this.swigCPtr, this.swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(XcapCallback));
		}

		private int SwigDirectoronEvent(IntPtr e)
		{
			return this.onEvent((e == IntPtr.Zero) ? null : new XcapEvent(e, false));
		}
	}
}
