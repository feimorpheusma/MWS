using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class T140Callback : IDisposable
	{
		public delegate int SwigDelegateT140Callback_0(IntPtr pData);

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private T140Callback.SwigDelegateT140Callback_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(T140CallbackData)
		};

		internal T140Callback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(T140Callback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~T140Callback()
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
						tinyWRAPPINVOKE.delete_T140Callback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public T140Callback() : this(tinyWRAPPINVOKE.new_T140Callback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int ondata(T140CallbackData pData)
		{
			return this.SwigDerivedClassHasMethod("ondata", T140Callback.swigMethodTypes0) ? tinyWRAPPINVOKE.T140Callback_ondataSwigExplicitT140Callback(this.swigCPtr, T140CallbackData.getCPtr(pData)) : tinyWRAPPINVOKE.T140Callback_ondata(this.swigCPtr, T140CallbackData.getCPtr(pData));
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("ondata", T140Callback.swigMethodTypes0))
			{
				this.swigDelegate0 = new T140Callback.SwigDelegateT140Callback_0(this.SwigDirectorondata);
			}
			tinyWRAPPINVOKE.T140Callback_director_connect(this.swigCPtr, this.swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(T140Callback));
		}

		private int SwigDirectorondata(IntPtr pData)
		{
			return this.ondata((pData == IntPtr.Zero) ? null : new T140CallbackData(pData, false));
		}
	}
}
