using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class ProxyVideoConsumerCallback : IDisposable
	{
		public delegate int SwigDelegateProxyVideoConsumerCallback_0(int nWidth, int nHeight, int nFps);

		public delegate int SwigDelegateProxyVideoConsumerCallback_1(IntPtr frame);

		public delegate int SwigDelegateProxyVideoConsumerCallback_2(uint nCopiedSize, uint nAvailableSize);

		public delegate int SwigDelegateProxyVideoConsumerCallback_3();

		public delegate int SwigDelegateProxyVideoConsumerCallback_4();

		public delegate int SwigDelegateProxyVideoConsumerCallback_5();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_0 swigDelegate0;

		private ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_1 swigDelegate1;

		private ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_2 swigDelegate2;

		private ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_3 swigDelegate3;

		private ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_4 swigDelegate4;

		private ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_5 swigDelegate5;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};

		private static Type[] swigMethodTypes1 = new Type[]
		{
			typeof(ProxyVideoFrame)
		};

		private static Type[] swigMethodTypes2 = new Type[]
		{
			typeof(uint),
			typeof(uint)
		};

		private static Type[] swigMethodTypes3 = new Type[0];

		private static Type[] swigMethodTypes4 = new Type[0];

		private static Type[] swigMethodTypes5 = new Type[0];

		internal ProxyVideoConsumerCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ProxyVideoConsumerCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~ProxyVideoConsumerCallback()
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
						tinyWRAPPINVOKE.delete_ProxyVideoConsumerCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public ProxyVideoConsumerCallback() : this(tinyWRAPPINVOKE.new_ProxyVideoConsumerCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int prepare(int nWidth, int nHeight, int nFps)
		{
			return this.SwigDerivedClassHasMethod("prepare", ProxyVideoConsumerCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.ProxyVideoConsumerCallback_prepareSwigExplicitProxyVideoConsumerCallback(this.swigCPtr, nWidth, nHeight, nFps) : tinyWRAPPINVOKE.ProxyVideoConsumerCallback_prepare(this.swigCPtr, nWidth, nHeight, nFps);
		}

		public virtual int consume(ProxyVideoFrame frame)
		{
			return this.SwigDerivedClassHasMethod("consume", ProxyVideoConsumerCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.ProxyVideoConsumerCallback_consumeSwigExplicitProxyVideoConsumerCallback(this.swigCPtr, ProxyVideoFrame.getCPtr(frame)) : tinyWRAPPINVOKE.ProxyVideoConsumerCallback_consume(this.swigCPtr, ProxyVideoFrame.getCPtr(frame));
		}

		public virtual int bufferCopied(uint nCopiedSize, uint nAvailableSize)
		{
			return this.SwigDerivedClassHasMethod("bufferCopied", ProxyVideoConsumerCallback.swigMethodTypes2) ? tinyWRAPPINVOKE.ProxyVideoConsumerCallback_bufferCopiedSwigExplicitProxyVideoConsumerCallback(this.swigCPtr, nCopiedSize, nAvailableSize) : tinyWRAPPINVOKE.ProxyVideoConsumerCallback_bufferCopied(this.swigCPtr, nCopiedSize, nAvailableSize);
		}

		public virtual int start()
		{
			return this.SwigDerivedClassHasMethod("start", ProxyVideoConsumerCallback.swigMethodTypes3) ? tinyWRAPPINVOKE.ProxyVideoConsumerCallback_startSwigExplicitProxyVideoConsumerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyVideoConsumerCallback_start(this.swigCPtr);
		}

		public virtual int pause()
		{
			return this.SwigDerivedClassHasMethod("pause", ProxyVideoConsumerCallback.swigMethodTypes4) ? tinyWRAPPINVOKE.ProxyVideoConsumerCallback_pauseSwigExplicitProxyVideoConsumerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyVideoConsumerCallback_pause(this.swigCPtr);
		}

		public virtual int stop()
		{
			return this.SwigDerivedClassHasMethod("stop", ProxyVideoConsumerCallback.swigMethodTypes5) ? tinyWRAPPINVOKE.ProxyVideoConsumerCallback_stopSwigExplicitProxyVideoConsumerCallback(this.swigCPtr) : tinyWRAPPINVOKE.ProxyVideoConsumerCallback_stop(this.swigCPtr);
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("prepare", ProxyVideoConsumerCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_0(this.SwigDirectorprepare);
			}
			if (this.SwigDerivedClassHasMethod("consume", ProxyVideoConsumerCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_1(this.SwigDirectorconsume);
			}
			if (this.SwigDerivedClassHasMethod("bufferCopied", ProxyVideoConsumerCallback.swigMethodTypes2))
			{
				this.swigDelegate2 = new ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_2(this.SwigDirectorbufferCopied);
			}
			if (this.SwigDerivedClassHasMethod("start", ProxyVideoConsumerCallback.swigMethodTypes3))
			{
				this.swigDelegate3 = new ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_3(this.SwigDirectorstart);
			}
			if (this.SwigDerivedClassHasMethod("pause", ProxyVideoConsumerCallback.swigMethodTypes4))
			{
				this.swigDelegate4 = new ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_4(this.SwigDirectorpause);
			}
			if (this.SwigDerivedClassHasMethod("stop", ProxyVideoConsumerCallback.swigMethodTypes5))
			{
				this.swigDelegate5 = new ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_5(this.SwigDirectorstop);
			}
			tinyWRAPPINVOKE.ProxyVideoConsumerCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1, this.swigDelegate2, this.swigDelegate3, this.swigDelegate4, this.swigDelegate5);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(ProxyVideoConsumerCallback));
		}

		private int SwigDirectorprepare(int nWidth, int nHeight, int nFps)
		{
			return this.prepare(nWidth, nHeight, nFps);
		}

		private int SwigDirectorconsume(IntPtr frame)
		{
			return this.consume((frame == IntPtr.Zero) ? null : new ProxyVideoFrame(frame, false));
		}

		private int SwigDirectorbufferCopied(uint nCopiedSize, uint nAvailableSize)
		{
			return this.bufferCopied(nCopiedSize, nAvailableSize);
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
