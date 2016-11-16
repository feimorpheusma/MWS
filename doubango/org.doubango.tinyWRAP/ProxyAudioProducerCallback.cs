using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyAudioProducerCallback : IDisposable
	{
		public delegate int SwigDelegateProxyAudioProducerCallback_0(int ptime, int rate, int channels);

		public delegate int SwigDelegateProxyAudioProducerCallback_1();

		public delegate int SwigDelegateProxyAudioProducerCallback_2();

		public delegate int SwigDelegateProxyAudioProducerCallback_3();

		public delegate int SwigDelegateProxyAudioProducerCallback_4();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_0 swigDelegate0;

		private ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_1 swigDelegate1;

		private ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_2 swigDelegate2;

		private ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_3 swigDelegate3;

		private ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_4 swigDelegate4;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};

		private static Type[] swigMethodTypes1 = new Type[0];

		private static Type[] swigMethodTypes2 = new Type[0];

		private static Type[] swigMethodTypes3 = new Type[0];

		private static Type[] swigMethodTypes4 = new Type[0];

		internal ProxyAudioProducerCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyAudioProducerCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyAudioProducerCallback()
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
						tinyWRAPPINVOKE.delete_ProxyAudioProducerCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public ProxyAudioProducerCallback() : this(tinyWRAPPINVOKE.new_ProxyAudioProducerCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int prepare(int ptime, int rate, int channels)
		{
			return this.SwigDerivedClassHasMethod("prepare", ProxyAudioProducerCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.ProxyAudioProducerCallback_prepareSwigExplicitProxyAudioProducerCallback(this.swigCPtr, ptime, rate, channels) : tinyWRAPPINVOKE.ProxyAudioProducerCallback_prepare(this.swigCPtr, ptime, rate, channels);
		}

		public virtual int start()
		{
			return this.SwigDerivedClassHasMethod("start", ProxyAudioProducerCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.ProxyAudioProducerCallback_startSwigExplicitProxyAudioProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioProducerCallback_start(this.swigCPtr);
		}

		public virtual int pause()
		{
			return this.SwigDerivedClassHasMethod("pause", ProxyAudioProducerCallback.swigMethodTypes2) ? tinyWRAPPINVOKE.ProxyAudioProducerCallback_pauseSwigExplicitProxyAudioProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioProducerCallback_pause(this.swigCPtr);
		}

		public virtual int stop()
		{
			return this.SwigDerivedClassHasMethod("stop", ProxyAudioProducerCallback.swigMethodTypes3) ? tinyWRAPPINVOKE.ProxyAudioProducerCallback_stopSwigExplicitProxyAudioProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioProducerCallback_stop(this.swigCPtr);
		}

		public virtual int fillPushBuffer()
		{
			return this.SwigDerivedClassHasMethod("fillPushBuffer", ProxyAudioProducerCallback.swigMethodTypes4) ? tinyWRAPPINVOKE.ProxyAudioProducerCallback_fillPushBufferSwigExplicitProxyAudioProducerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyAudioProducerCallback_fillPushBuffer(this.swigCPtr);
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("prepare", ProxyAudioProducerCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_0(this.SwigDirectorprepare);
			}
			if (this.SwigDerivedClassHasMethod("start", ProxyAudioProducerCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_1(this.SwigDirectorstart);
			}
			if (this.SwigDerivedClassHasMethod("pause", ProxyAudioProducerCallback.swigMethodTypes2))
			{
				this.swigDelegate2 = new ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_2(this.SwigDirectorpause);
			}
			if (this.SwigDerivedClassHasMethod("stop", ProxyAudioProducerCallback.swigMethodTypes3))
			{
				this.swigDelegate3 = new ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_3(this.SwigDirectorstop);
			}
			if (this.SwigDerivedClassHasMethod("fillPushBuffer", ProxyAudioProducerCallback.swigMethodTypes4))
			{
				this.swigDelegate4 = new ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_4(this.SwigDirectorfillPushBuffer);
			}
			tinyWRAPPINVOKE.ProxyAudioProducerCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1, this.swigDelegate2, this.swigDelegate3, this.swigDelegate4);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(ProxyAudioProducerCallback));
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

		private int SwigDirectorfillPushBuffer()
		{
			return this.fillPushBuffer();
		}
	}
}
