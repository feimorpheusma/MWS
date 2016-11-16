using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SipCallback : IDisposable
	{
		public delegate int SwigDelegateSipCallback_0(IntPtr e);

		public delegate int SwigDelegateSipCallback_1(IntPtr e);

		public delegate int SwigDelegateSipCallback_2(IntPtr e);

		public delegate int SwigDelegateSipCallback_3(IntPtr e);

		public delegate int SwigDelegateSipCallback_4(IntPtr e);

		public delegate int SwigDelegateSipCallback_5(IntPtr e);

		public delegate int SwigDelegateSipCallback_6(IntPtr e);

		public delegate int SwigDelegateSipCallback_7(IntPtr e);

		public delegate int SwigDelegateSipCallback_8(IntPtr e);

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SipCallback.SwigDelegateSipCallback_0 swigDelegate0;

		private SipCallback.SwigDelegateSipCallback_1 swigDelegate1;

		private SipCallback.SwigDelegateSipCallback_2 swigDelegate2;

		private SipCallback.SwigDelegateSipCallback_3 swigDelegate3;

		private SipCallback.SwigDelegateSipCallback_4 swigDelegate4;

		private SipCallback.SwigDelegateSipCallback_5 swigDelegate5;

		private SipCallback.SwigDelegateSipCallback_6 swigDelegate6;

		private SipCallback.SwigDelegateSipCallback_7 swigDelegate7;

		private SipCallback.SwigDelegateSipCallback_8 swigDelegate8;

		private static Type[] swigMethodTypes0 = new Type[]
		{
			typeof(DialogEvent)
		};

		private static Type[] swigMethodTypes1 = new Type[]
		{
			typeof(StackEvent)
		};

		private static Type[] swigMethodTypes2 = new Type[]
		{
			typeof(InviteEvent)
		};

		private static Type[] swigMethodTypes3 = new Type[]
		{
			typeof(MessagingEvent)
		};

		private static Type[] swigMethodTypes4 = new Type[]
		{
			typeof(InfoEvent)
		};

		private static Type[] swigMethodTypes5 = new Type[]
		{
			typeof(OptionsEvent)
		};

		private static Type[] swigMethodTypes6 = new Type[]
		{
			typeof(PublicationEvent)
		};

		private static Type[] swigMethodTypes7 = new Type[]
		{
			typeof(RegistrationEvent)
		};

		private static Type[] swigMethodTypes8 = new Type[]
		{
			typeof(SubscriptionEvent)
		};

		internal SipCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SipCallback obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SipCallback()
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
						tinyWRAPPINVOKE.delete_SipCallback(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public SipCallback() : this(tinyWRAPPINVOKE.new_SipCallback(), true)
		{
			this.SwigDirectorConnect();
		}

		public virtual int OnDialogEvent(DialogEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnDialogEvent", SipCallback.swigMethodTypes0) ? tinyWRAPPINVOKE.SipCallback_OnDialogEventSwigExplicitSipCallback(this.swigCPtr, DialogEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnDialogEvent(this.swigCPtr, DialogEvent.getCPtr(e));
		}

		public virtual int OnStackEvent(StackEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnStackEvent", SipCallback.swigMethodTypes1) ? tinyWRAPPINVOKE.SipCallback_OnStackEventSwigExplicitSipCallback(this.swigCPtr, StackEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnStackEvent(this.swigCPtr, StackEvent.getCPtr(e));
		}

		public virtual int OnInviteEvent(InviteEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnInviteEvent", SipCallback.swigMethodTypes2) ? tinyWRAPPINVOKE.SipCallback_OnInviteEventSwigExplicitSipCallback(this.swigCPtr, InviteEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnInviteEvent(this.swigCPtr, InviteEvent.getCPtr(e));
		}

		public virtual int OnMessagingEvent(MessagingEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnMessagingEvent", SipCallback.swigMethodTypes3) ? tinyWRAPPINVOKE.SipCallback_OnMessagingEventSwigExplicitSipCallback(this.swigCPtr, MessagingEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnMessagingEvent(this.swigCPtr, MessagingEvent.getCPtr(e));
		}

		public virtual int OnInfoEvent(InfoEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnInfoEvent", SipCallback.swigMethodTypes4) ? tinyWRAPPINVOKE.SipCallback_OnInfoEventSwigExplicitSipCallback(this.swigCPtr, InfoEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnInfoEvent(this.swigCPtr, InfoEvent.getCPtr(e));
		}

		public virtual int OnOptionsEvent(OptionsEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnOptionsEvent", SipCallback.swigMethodTypes5) ? tinyWRAPPINVOKE.SipCallback_OnOptionsEventSwigExplicitSipCallback(this.swigCPtr, OptionsEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnOptionsEvent(this.swigCPtr, OptionsEvent.getCPtr(e));
		}

		public virtual int OnPublicationEvent(PublicationEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnPublicationEvent", SipCallback.swigMethodTypes6) ? tinyWRAPPINVOKE.SipCallback_OnPublicationEventSwigExplicitSipCallback(this.swigCPtr, PublicationEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnPublicationEvent(this.swigCPtr, PublicationEvent.getCPtr(e));
		}

		public virtual int OnRegistrationEvent(RegistrationEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnRegistrationEvent", SipCallback.swigMethodTypes7) ? tinyWRAPPINVOKE.SipCallback_OnRegistrationEventSwigExplicitSipCallback(this.swigCPtr, RegistrationEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnRegistrationEvent(this.swigCPtr, RegistrationEvent.getCPtr(e));
		}

		public virtual int OnSubscriptionEvent(SubscriptionEvent e)
		{
			return this.SwigDerivedClassHasMethod("OnSubscriptionEvent", SipCallback.swigMethodTypes8) ? tinyWRAPPINVOKE.SipCallback_OnSubscriptionEventSwigExplicitSipCallback(this.swigCPtr, SubscriptionEvent.getCPtr(e)) : tinyWRAPPINVOKE.SipCallback_OnSubscriptionEvent(this.swigCPtr, SubscriptionEvent.getCPtr(e));
		}

		private void SwigDirectorConnect()
		{
			if (this.SwigDerivedClassHasMethod("OnDialogEvent", SipCallback.swigMethodTypes0))
			{
				this.swigDelegate0 = new SipCallback.SwigDelegateSipCallback_0(this.SwigDirectorOnDialogEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnStackEvent", SipCallback.swigMethodTypes1))
			{
				this.swigDelegate1 = new SipCallback.SwigDelegateSipCallback_1(this.SwigDirectorOnStackEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnInviteEvent", SipCallback.swigMethodTypes2))
			{
				this.swigDelegate2 = new SipCallback.SwigDelegateSipCallback_2(this.SwigDirectorOnInviteEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnMessagingEvent", SipCallback.swigMethodTypes3))
			{
				this.swigDelegate3 = new SipCallback.SwigDelegateSipCallback_3(this.SwigDirectorOnMessagingEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnInfoEvent", SipCallback.swigMethodTypes4))
			{
				this.swigDelegate4 = new SipCallback.SwigDelegateSipCallback_4(this.SwigDirectorOnInfoEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnOptionsEvent", SipCallback.swigMethodTypes5))
			{
				this.swigDelegate5 = new SipCallback.SwigDelegateSipCallback_5(this.SwigDirectorOnOptionsEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnPublicationEvent", SipCallback.swigMethodTypes6))
			{
				this.swigDelegate6 = new SipCallback.SwigDelegateSipCallback_6(this.SwigDirectorOnPublicationEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnRegistrationEvent", SipCallback.swigMethodTypes7))
			{
				this.swigDelegate7 = new SipCallback.SwigDelegateSipCallback_7(this.SwigDirectorOnRegistrationEvent);
			}
			if (this.SwigDerivedClassHasMethod("OnSubscriptionEvent", SipCallback.swigMethodTypes8))
			{
				this.swigDelegate8 = new SipCallback.SwigDelegateSipCallback_8(this.SwigDirectorOnSubscriptionEvent);
			}
			tinyWRAPPINVOKE.SipCallback_director_connect(this.swigCPtr, this.swigDelegate0, this.swigDelegate1, this.swigDelegate2, this.swigDelegate3, this.swigDelegate4, this.swigDelegate5, this.swigDelegate6, this.swigDelegate7, this.swigDelegate8);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo methodInfo = base.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return methodInfo.DeclaringType.IsSubclassOf(typeof(SipCallback));
		}

		private int SwigDirectorOnDialogEvent(IntPtr e)
		{
			return this.OnDialogEvent((e == IntPtr.Zero) ? null : new DialogEvent(e, false));
		}

		private int SwigDirectorOnStackEvent(IntPtr e)
		{
			return this.OnStackEvent((e == IntPtr.Zero) ? null : new StackEvent(e, false));
		}

		private int SwigDirectorOnInviteEvent(IntPtr e)
		{
			return this.OnInviteEvent((e == IntPtr.Zero) ? null : new InviteEvent(e, false));
		}

		private int SwigDirectorOnMessagingEvent(IntPtr e)
		{
			return this.OnMessagingEvent((e == IntPtr.Zero) ? null : new MessagingEvent(e, false));
		}

		private int SwigDirectorOnInfoEvent(IntPtr e)
		{
			return this.OnInfoEvent((e == IntPtr.Zero) ? null : new InfoEvent(e, false));
		}

		private int SwigDirectorOnOptionsEvent(IntPtr e)
		{
			return this.OnOptionsEvent((e == IntPtr.Zero) ? null : new OptionsEvent(e, false));
		}

		private int SwigDirectorOnPublicationEvent(IntPtr e)
		{
			return this.OnPublicationEvent((e == IntPtr.Zero) ? null : new PublicationEvent(e, false));
		}

		private int SwigDirectorOnRegistrationEvent(IntPtr e)
		{
			return this.OnRegistrationEvent((e == IntPtr.Zero) ? null : new RegistrationEvent(e, false));
		}

		private int SwigDirectorOnSubscriptionEvent(IntPtr e)
		{
			return this.OnSubscriptionEvent((e == IntPtr.Zero) ? null : new SubscriptionEvent(e, false));
		}
	}
}
