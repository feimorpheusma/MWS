using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyAudioConsumerCallback : IDisposable
	{
		public delegate int SwigDelegateProxyAudioConsumerCallback_0(int ptime, int rate, int channels);

		public delegate int SwigDelegateProxyAudioConsumerCallback_1();

		public delegate int SwigDelegateProxyAudioConsumerCallback_2();

		public delegate int SwigDelegateProxyAudioConsumerCallback_3();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_0 swigDelegate0;

		private ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_1 swigDelegate1;

		private ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_2 swigDelegate2;

		private ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_3 swigDelegate3;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};

		private static Type[] swigMethodTypes1 = new Type[0];

		private static Type[] swigMethodTypes2 = new Type[0];

		private static Type[] swigMethodTypes3 = new Type[0];

		internal ProxyAudioConsumerCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyAudioConsumerCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyAudioConsumerCallback()
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
						tinyWRAPPINVOKE.delete_ProxyAudioConsumerCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public ProxyAudioConsumerCallback() : this(tinyWRAPPINVOKE.new_ProxyAudioConsumerCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int prepare(int ptime, int rate, int channels)
		{
			return this.SwigDerivedClassHasMethod("prepare", ProxyAudioConsumerCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.ProxyAudioConsumerCallback_prepareSwigExplicitProxyAudioConsumerCallback(this.swigCPtr, ptime, rate, channels) : tinyWRAPPINVOKE.ProxyAudioConsumerCallback_prepare(this.swigCPtr, ptime, rate, channels);
		}

		public virtual int start()
		{
			return this.SwigDerivedClassHasMethod("start", ProxyAudioConsumerCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.ProxyAudioConsumerCallback_startSwigExplicitProxyAudioConsumerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioConsumerCallback_start(this.swigCPtr);
		}

		public virtual int pause()
		{
			return this.SwigDerivedClassHasMethod("pause", ProxyAudioConsumerCallback.swigMethodTypes2) ? tinyWRAPPINVOKE.ProxyAudioConsumerCallback_pauseSwigExplicitProxyAudioConsumerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioConsumerCallback_pause(this.swigCPtr);
		}

		public virtual int stop()
		{
			return this.SwigDerivedClassHasMethod("stop", ProxyAudioConsumerCallback.swigMethodTypes3) ? tinyWRAPPINVOKE.ProxyAudioConsumerCallback_stopSwigExplicitProxyAudioConsumerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioConsumerCallback_stop(this.swigCPtr);
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("prepare", ProxyAudioConsumerCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_0(this.SwigDirectorprepare);
			}
			if (this.SwigDerivedClassHasMethod("start", ProxyAudioConsumerCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_1(this.SwigDirectorstart);
			}
			if (this.SwigDerivedClassHasMethod("pause", ProxyAudioConsumerCallback.swigMethodTypes2))
			{
				this.swigDelegate2 = new ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_2(this.SwigDirectorpause);
			}
			if (this.SwigDerivedClassHasMethod("stop", ProxyAudioConsumerCallback.swigMethodTypes3))
			{
				this.swigDelegate3 = new ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_3(this.SwigDirectorstop);
			}
			tinyWRAPPINVOKE.ProxyAudioConsumerCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1, this.swigDelegate2, this.swigDelegate3);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(ProxyAudioConsumerCallback));
		}

		private int SwigDirectorprepare(int ptime, int rate, int channels)
		{
			return this.prepare(ptime, rate, channels);
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
