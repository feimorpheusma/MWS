using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyPluginMgrCallback : IDisposable
	{
		public delegate int SwigDelegateProxyPluginMgrCallback_0(ulong id, int type);

		public delegate int SwigDelegateProxyPluginMgrCallback_1(ulong id, int type);

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private ProxyPluginMgrCallback.SwigDelegateProxyPluginMgrCallback_0 swigDelegate0;

		private ProxyPluginMgrCallback.SwigDelegateProxyPluginMgrCallback_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(ulong),
			typeof(twrap_proxy_plugin_type_t)
		};

		private static Type[] swigMethodTypes1 = new Type[]
		{
			typeof(ulong),
			typeof(twrap_proxy_plugin_type_t)
		};

		internal ProxyPluginMgrCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyPluginMgrCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyPluginMgrCallback()
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
						tinyWRAPPINVOKE.delete_ProxyPluginMgrCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public ProxyPluginMgrCallback() : this(tinyWRAPPINVOKE.new_ProxyPluginMgrCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int OnPluginCreated(ulong id, twrap_proxy_plugin_type_t type)
		{
			return this.SwigDerivedClassHasMethod("OnPluginCreated", ProxyPluginMgrCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.ProxyPluginMgrCallback_OnPluginCreatedSwigExplicitProxyPluginMgrCallback(this.swigCPtr, id, (int)type) : tinyWRAPPINVOKE.ProxyPluginMgrCallback_OnPluginCreated(this.swigCPtr, id, (int)type);
		}

		public virtual int OnPluginDestroyed(ulong id, twrap_proxy_plugin_type_t type)
		{
			return this.SwigDerivedClassHasMethod("OnPluginDestroyed", ProxyPluginMgrCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.ProxyPluginMgrCallback_OnPluginDestroyedSwigExplicitProxyPluginMgrCallback(this.swigCPtr, id, (int)type) : tinyWRAPPINVOKE.ProxyPluginMgrCallback_OnPluginDestroyed(this.swigCPtr, id, (int)type);
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("OnPluginCreated", ProxyPluginMgrCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new ProxyPluginMgrCallback.SwigDelegateProxyPluginMgrCallback_0(this.SwigDirectorOnPluginCreated);
			}
			if (this.SwigDerivedClassHasMethod("OnPluginDestroyed", ProxyPluginMgrCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new ProxyPluginMgrCallback.SwigDelegateProxyPluginMgrCallback_1(this.SwigDirectorOnPluginDestroyed);
			}
			tinyWRAPPINVOKE.ProxyPluginMgrCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(ProxyPluginMgrCallback));
		}

		private int SwigDirectorOnPluginCreated(ulong id, int type)
		{
			return this.OnPluginCreated(id, (twrap_proxy_plugin_type_t)type);
		}

		private int SwigDirectorOnPluginDestroyed(ulong id, int type)
		{
			return this.OnPluginDestroyed(id, (twrap_proxy_plugin_type_t)type);
		}
	}
}
