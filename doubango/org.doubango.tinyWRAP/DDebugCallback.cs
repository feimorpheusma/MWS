using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class DDebugCallback : IDisposable
	{
		public delegate int SwigDelegateDDebugCallback_0(string message);

		public delegate int SwigDelegateDDebugCallback_1(string message);

		public delegate int SwigDelegateDDebugCallback_2(string message);

		public delegate int SwigDelegateDDebugCallback_3(string message);

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private DDebugCallback.SwigDelegateDDebugCallback_0 swigDelegate0;

		private DDebugCallback.SwigDelegateDDebugCallback_1 swigDelegate1;

		private DDebugCallback.SwigDelegateDDebugCallback_2 swigDelegate2;

		private DDebugCallback.SwigDelegateDDebugCallback_3 swigDelegate3;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(string)
		};

		private static Type[] swigMethodTypes1 = new Type[]
		{
			typeof(string)
		};

		private static Type[] swigMethodTypes2 = new Type[]
		{
			typeof(string)
		};

		private static Type[] swigMethodTypes3 = new Type[]
		{
			typeof(string)
		};

		internal DDebugCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(DDebugCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~DDebugCallback()
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
						tinyWRAPPINVOKE.delete_DDebugCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public DDebugCallback() : this(tinyWRAPPINVOKE.new_DDebugCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int OnDebugInfo(string message)
		{
			return this.SwigDerivedClassHasMethod("OnDebugInfo", DDebugCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.DDebugCallback_OnDebugInfoSwigExplicitDDebugCallback(this.swigCPtr, message) : tinyWRAPPINVOKE.DDebugCallback_OnDebugInfo(this.swigCPtr, message);
		}

		public virtual int OnDebugWarn(string message)
		{
			return this.SwigDerivedClassHasMethod("OnDebugWarn", DDebugCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.DDebugCallback_OnDebugWarnSwigExplicitDDebugCallback(this.swigCPtr, message) : tinyWRAPPINVOKE.DDebugCallback_OnDebugWarn(this.swigCPtr, message);
		}

		public virtual int OnDebugError(string message)
		{
			return this.SwigDerivedClassHasMethod("OnDebugError", DDebugCallback.swigMethodTypes2) ? tinyWRAPPINVOKE.DDebugCallback_OnDebugErrorSwigExplicitDDebugCallback(this.swigCPtr, message) : tinyWRAPPINVOKE.DDebugCallback_OnDebugError(this.swigCPtr, message);
		}

		public virtual int OnDebugFatal(string message)
		{
			return this.SwigDerivedClassHasMethod("OnDebugFatal", DDebugCallback.swigMethodTypes3) ? tinyWRAPPINVOKE.DDebugCallback_OnDebugFatalSwigExplicitDDebugCallback(this.swigCPtr, message) : tinyWRAPPINVOKE.DDebugCallback_OnDebugFatal(this.swigCPtr, message);
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("OnDebugInfo", DDebugCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new DDebugCallback.SwigDelegateDDebugCallback_0(this.SwigDirectorOnDebugInfo);
			}
			if (this.SwigDerivedClassHasMethod("OnDebugWarn", DDebugCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new DDebugCallback.SwigDelegateDDebugCallback_1(this.SwigDirectorOnDebugWarn);
			}
			if (this.SwigDerivedClassHasMethod("OnDebugError", DDebugCallback.swigMethodTypes2))
			{
				this.swigDelegate2 = new DDebugCallback.SwigDelegateDDebugCallback_2(this.SwigDirectorOnDebugError);
			}
			if (this.SwigDerivedClassHasMethod("OnDebugFatal", DDebugCallback.swigMethodTypes3))
			{
				this.swigDelegate3 = new DDebugCallback.SwigDelegateDDebugCallback_3(this.SwigDirectorOnDebugFatal);
			}
			tinyWRAPPINVOKE.DDebugCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1, this.swigDelegate2, this.swigDelegate3);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(DDebugCallback));
		}

		private int SwigDirectorOnDebugInfo(string message)
		{
			return this.OnDebugInfo(message);
		}

		private int SwigDirectorOnDebugWarn(string message)
		{
			return this.OnDebugWarn(message);
		}

		private int SwigDirectorOnDebugError(string message)
		{
			return this.OnDebugError(message);
		}

		private int SwigDirectorOnDebugFatal(string message)
		{
			return this.OnDebugFatal(message);
		}
	}
}
