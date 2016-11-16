using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MsrpCallback : IDisposable
	{
		public delegate int SwigDelegateMsrpCallback_0(IntPtr e);

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private MsrpCallback.SwigDelegateMsrpCallback_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(MsrpEvent)
		};

		internal MsrpCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MsrpCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MsrpCallback()
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
						tinyWRAPPINVOKE.delete_MsrpCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public MsrpCallback() : this(tinyWRAPPINVOKE.new_MsrpCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int OnEvent(MsrpEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnEvent", MsrpCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.MsrpCallback_OnEventSwigExplicitMsrpCallback(this.swigCPtr, MsrpEvent.getCPtr(e)) : tinyWRAPPINVOKE.MsrpCallback_OnEvent(this.swigCPtr, MsrpEvent.getCPtr(e));
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("OnEvent", MsrpCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new MsrpCallback.SwigDelegateMsrpCallback_0(this.SwigDirectorOnEvent);
			}
			tinyWRAPPINVOKE.MsrpCallback_director_connect(this.swigCPtr, this.swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(MsrpCallback));
		}

		private int SwigDirectorOnEvent(IntPtr e)
		{
			return this.OnEvent((e == IntPtr.Zero) ? null : new MsrpEvent(e, false));
		}
	}
}
