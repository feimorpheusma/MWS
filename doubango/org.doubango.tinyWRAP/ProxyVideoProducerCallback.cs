using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyVideoProducerCallback : IDisposable
	{
		public delegate int SwigDelegateProxyVideoProducerCallback_0(int width, int height, int fps);

		public delegate int SwigDelegateProxyVideoProducerCallback_1();

		public delegate int SwigDelegateProxyVideoProducerCallback_2();

		public delegate int SwigDelegateProxyVideoProducerCallback_3();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_0 swigDelegate0;

		private ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_1 swigDelegate1;

		private ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_2 swigDelegate2;

		private ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_3 swigDelegate3;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};

		private static Type[] swigMethodTypes1 = new Type[0];

		private static Type[] swigMethodTypes2 = new Type[0];

		private static Type[] swigMethodTypes3 = new Type[0];

		internal ProxyVideoProducerCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyVideoProducerCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyVideoProducerCallback()
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
						tinyWRAPPINVOKE.delete_ProxyVideoProducerCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public ProxyVideoProducerCallback() : this(tinyWRAPPINVOKE.new_ProxyVideoProducerCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int prepare(int width, int height, int fps)
		{
			return this.SwigDerivedClassHasMethod("prepare", ProxyVideoProducerCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.ProxyVideoProducerCallback_prepareSwigExplicitProxyVideoProducerCallback(this.swigCPtr, width, height, fps) : tinyWRAPPINVOKE.ProxyVideoProducerCallback_prepare(this.swigCPtr, width, height, fps);
		}

		public virtual int start()
		{
			return this.SwigDerivedClassHasMethod("start", ProxyVideoProducerCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.ProxyVideoProducerCallback_startSwigExplicitProxyVideoProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyVideoProducerCallback_start(this.swigCPtr);
		}

		public virtual int pause()
		{
			return this.SwigDerivedClassHasMethod("pause", ProxyVideoProducerCallback.swigMethodTypes2) ? tinyWRAPPINVOKE.ProxyVideoProducerCallback_pauseSwigExplicitProxyVideoProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyVideoProducerCallback_pause(this.swigCPtr);
		}

		public virtual int stop()
		{
			return this.SwigDerivedClassHasMethod("stop", ProxyVideoProducerCallback.swigMethodTypes3) ? tinyWRAPPINVOKE.ProxyVideoProducerCallback_stopSwigExplicitProxyVideoProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyVideoProducerCallback_stop(this.swigCPtr);
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("prepare", ProxyVideoProducerCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_0(this.SwigDirectorprepare);
			}
			if (this.SwigDerivedClassHasMethod("start", ProxyVideoProducerCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_1(this.SwigDirectorstart);
			}
			if (this.SwigDerivedClassHasMethod("pause", ProxyVideoProducerCallback.swigMethodTypes2))
			{
				this.swigDelegate2 = new ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_2(this.SwigDirectorpause);
			}
			if (this.SwigDerivedClassHasMethod("stop", ProxyVideoProducerCallback.swigMethodTypes3))
			{
				this.swigDelegate3 = new ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_3(this.SwigDirectorstop);
			}
			tinyWRAPPINVOKE.ProxyVideoProducerCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1, this.swigDelegate2, this.swigDelegate3);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(ProxyVideoProducerCallback));
		}

		private int SwigDirectorprepare(int width, int height, int fps)
		{
			return this.prepare(width, height, fps);
		}

		private int SwigDirectorstart()
		{
			return this.start();
		}

		private int SwigDirectorpause()
		{
			return this.pause();
		}

		private int SwigDirectorstop()
		{
			return this.stop();
		}
	}
}
