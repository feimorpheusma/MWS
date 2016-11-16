using System;
using System.IO;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	internal class tinyWRAPPINVOKE
	{
		protected class SWIGExceptionHelper
		{
			public delegate void ExceptionDelegate(string message);

			public delegate void ExceptionArgumentDelegate(string message, string paramName);

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate applicationDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate arithmeticDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate divideByZeroDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate indexOutOfRangeDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidCastDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidOperationDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate ioDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate nullReferenceDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate outOfMemoryDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate overflowDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate systemDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentNullDelegate;

			private static tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentOutOfRangeDelegate;

			[DllImport("tinyWRAP")]
			public static extern void SWIGRegisterExceptionCallbacks_tinyWRAP(tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate applicationDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate arithmeticDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate divideByZeroDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate indexOutOfRangeDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidCastDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidOperationDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate ioDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate nullReferenceDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate outOfMemoryDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate overflowDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate systemExceptionDelegate);

			[DllImport("tinyWRAP", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_tinyWRAP")]
			public static extern void SWIGRegisterExceptionCallbacksArgument_tinyWRAP(tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentNullDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentOutOfRangeDelegate);

			private static void SetPendingApplicationException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new ApplicationException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingArithmeticException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new ArithmeticException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingDivideByZeroException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new DivideByZeroException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingIndexOutOfRangeException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new IndexOutOfRangeException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingInvalidCastException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new InvalidCastException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingInvalidOperationException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new InvalidOperationException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingIOException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new IOException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingNullReferenceException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new NullReferenceException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingOutOfMemoryException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new OutOfMemoryException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingOverflowException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new OverflowException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingSystemException(string message)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new SystemException(message, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingArgumentException(string message, string paramName)
			{
				tinyWRAPPINVOKE.SWIGPendingException.Set(new ArgumentException(message, paramName, tinyWRAPPINVOKE.SWIGPendingException.Retrieve()));
			}

			private static void SetPendingArgumentNullException(string message, string paramName)
			{
				Exception e = tinyWRAPPINVOKE.SWIGPendingException.Retrieve();
				if (e != null)
				{
					message = message + " Inner Exception: " + e.Message;
				}
				tinyWRAPPINVOKE.SWIGPendingException.Set(new ArgumentNullException(paramName, message));
			}

			private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
			{
				Exception e = tinyWRAPPINVOKE.SWIGPendingException.Retrieve();
				if (e != null)
				{
					message = message + " Inner Exception: " + e.Message;
				}
				tinyWRAPPINVOKE.SWIGPendingException.Set(new ArgumentOutOfRangeException(paramName, message));
			}

			static SWIGExceptionHelper()
			{
				tinyWRAPPINVOKE.SWIGExceptionHelper.applicationDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingApplicationException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.arithmeticDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingArithmeticException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.divideByZeroDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingDivideByZeroException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.indexOutOfRangeDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingIndexOutOfRangeException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.invalidCastDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingInvalidCastException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.invalidOperationDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingInvalidOperationException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.ioDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingIOException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.nullReferenceDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingNullReferenceException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.outOfMemoryDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingOutOfMemoryException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.overflowDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingOverflowException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.systemDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingSystemException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.argumentDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingArgumentException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.argumentNullDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingArgumentNullException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.argumentOutOfRangeDelegate = new tinyWRAPPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(tinyWRAPPINVOKE.SWIGExceptionHelper.SetPendingArgumentOutOfRangeException);
				tinyWRAPPINVOKE.SWIGExceptionHelper.SWIGRegisterExceptionCallbacks_tinyWRAP(tinyWRAPPINVOKE.SWIGExceptionHelper.applicationDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.arithmeticDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.divideByZeroDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.indexOutOfRangeDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.invalidCastDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.invalidOperationDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.ioDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.nullReferenceDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.outOfMemoryDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.overflowDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.systemDelegate);
				tinyWRAPPINVOKE.SWIGExceptionHelper.SWIGRegisterExceptionCallbacksArgument_tinyWRAP(tinyWRAPPINVOKE.SWIGExceptionHelper.argumentDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.argumentNullDelegate, tinyWRAPPINVOKE.SWIGExceptionHelper.argumentOutOfRangeDelegate);
			}
		}

		public class SWIGPendingException
		{
			[ThreadStatic]
			private static Exception pendingException = null;

			private static int numExceptionsPending = 0;

			public static bool Pending
			{
				get
				{
					bool pending = false;
					if (tinyWRAPPINVOKE.SWIGPendingException.numExceptionsPending > 0 && tinyWRAPPINVOKE.SWIGPendingException.pendingException != null)
					{
						pending = true;
					}
					return pending;
				}
			}

			public static void Set(Exception e)
			{
				if (tinyWRAPPINVOKE.SWIGPendingException.pendingException != null)
				{
					throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + tinyWRAPPINVOKE.SWIGPendingException.pendingException.ToString() + ")", e);
				}
				tinyWRAPPINVOKE.SWIGPendingException.pendingException = e;
				lock (typeof(tinyWRAPPINVOKE))
				{
					tinyWRAPPINVOKE.SWIGPendingException.numExceptionsPending++;
				}
			}

			public static Exception Retrieve()
			{
				Exception e = null;
				if (tinyWRAPPINVOKE.SWIGPendingException.numExceptionsPending > 0)
				{
					if (tinyWRAPPINVOKE.SWIGPendingException.pendingException != null)
					{
						e = tinyWRAPPINVOKE.SWIGPendingException.pendingException;
						tinyWRAPPINVOKE.SWIGPendingException.pendingException = null;
						lock (typeof(tinyWRAPPINVOKE))
						{
							tinyWRAPPINVOKE.SWIGPendingException.numExceptionsPending--;
						}
					}
				}
				return e;
			}
		}

		protected class SWIGStringHelper
		{
			public delegate string SWIGStringDelegate(string message);

			private static tinyWRAPPINVOKE.SWIGStringHelper.SWIGStringDelegate stringDelegate;

			[DllImport("tinyWRAP")]
			public static extern void SWIGRegisterStringCallback_tinyWRAP(tinyWRAPPINVOKE.SWIGStringHelper.SWIGStringDelegate stringDelegate);

			private static string CreateString(string cString)
			{
				return cString;
			}

			static SWIGStringHelper()
			{
				tinyWRAPPINVOKE.SWIGStringHelper.stringDelegate = new tinyWRAPPINVOKE.SWIGStringHelper.SWIGStringDelegate(tinyWRAPPINVOKE.SWIGStringHelper.CreateString);
				tinyWRAPPINVOKE.SWIGStringHelper.SWIGRegisterStringCallback_tinyWRAP(tinyWRAPPINVOKE.SWIGStringHelper.stringDelegate);
			}
		}

		protected static tinyWRAPPINVOKE.SWIGExceptionHelper swigExceptionHelper;

		protected static tinyWRAPPINVOKE.SWIGStringHelper swigStringHelper;

		static tinyWRAPPINVOKE()
		{
			tinyWRAPPINVOKE.swigExceptionHelper = new tinyWRAPPINVOKE.SWIGExceptionHelper();
			tinyWRAPPINVOKE.swigStringHelper = new tinyWRAPPINVOKE.SWIGStringHelper();
		}

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_DDebugCallback")]
		public static extern IntPtr new_DDebugCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_DDebugCallback")]
		public static extern void delete_DDebugCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugInfo")]
		public static extern int DDebugCallback_OnDebugInfo(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugInfoSwigExplicitDDebugCallback")]
		public static extern int DDebugCallback_OnDebugInfoSwigExplicitDDebugCallback(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugWarn")]
		public static extern int DDebugCallback_OnDebugWarn(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugWarnSwigExplicitDDebugCallback")]
		public static extern int DDebugCallback_OnDebugWarnSwigExplicitDDebugCallback(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugError")]
		public static extern int DDebugCallback_OnDebugError(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugErrorSwigExplicitDDebugCallback")]
		public static extern int DDebugCallback_OnDebugErrorSwigExplicitDDebugCallback(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugFatal")]
		public static extern int DDebugCallback_OnDebugFatal(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_OnDebugFatalSwigExplicitDDebugCallback")]
		public static extern int DDebugCallback_OnDebugFatalSwigExplicitDDebugCallback(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DDebugCallback_director_connect")]
		public static extern void DDebugCallback_director_connect(HandleRef jarg1, DDebugCallback.SwigDelegateDDebugCallback_0 delegate0, DDebugCallback.SwigDelegateDDebugCallback_1 delegate1, DDebugCallback.SwigDelegateDDebugCallback_2 delegate2, DDebugCallback.SwigDelegateDDebugCallback_3 delegate3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_AudioResampler")]
		public static extern IntPtr new_AudioResampler(uint jarg1, uint jarg2, uint jarg3, uint jarg4, uint jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_AudioResampler")]
		public static extern void delete_AudioResampler(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_AudioResampler_isValid")]
		public static extern bool AudioResampler_isValid(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_AudioResampler_getOutputRequiredSizeInShort")]
		public static extern uint AudioResampler_getOutputRequiredSizeInShort(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_AudioResampler_getInputRequiredSizeInShort")]
		public static extern uint AudioResampler_getInputRequiredSizeInShort(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_AudioResampler_process")]
		public static extern uint AudioResampler_process(HandleRef jarg1, IntPtr jarg2, uint jarg3, IntPtr jarg4, uint jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_ActionConfig")]
		public static extern IntPtr new_ActionConfig();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ActionConfig")]
		public static extern void delete_ActionConfig(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ActionConfig_addHeader")]
		public static extern bool ActionConfig_addHeader(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ActionConfig_addPayload")]
		public static extern bool ActionConfig_addPayload(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ActionConfig_setActiveMedia")]
		public static extern bool ActionConfig_setActiveMedia(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ActionConfig_setResponseLine")]
		public static extern IntPtr ActionConfig_setResponseLine(HandleRef jarg1, short jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ActionConfig_setMediaString")]
		public static extern IntPtr ActionConfig_setMediaString(HandleRef jarg1, int jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ActionConfig_setMediaInt")]
		public static extern IntPtr ActionConfig_setMediaInt(HandleRef jarg1, int jarg2, string jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_Codec")]
		public static extern void delete_Codec(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getMediaType")]
		public static extern int Codec_getMediaType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getName")]
		public static extern string Codec_getName(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getDescription")]
		public static extern string Codec_getDescription(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getNegFormat")]
		public static extern string Codec_getNegFormat(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getAudioSamplingRate")]
		public static extern int Codec_getAudioSamplingRate(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getAudioChannels")]
		public static extern int Codec_getAudioChannels(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_Codec_getAudioPTime")]
		public static extern int Codec_getAudioPTime(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MediaSessionMgr")]
		public static extern void delete_MediaSessionMgr(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_sessionSetInt32")]
		public static extern bool MediaSessionMgr_sessionSetInt32(HandleRef jarg1, int jarg2, string jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_sessionGetInt32")]
		public static extern int MediaSessionMgr_sessionGetInt32(HandleRef jarg1, int jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_consumerSetInt32")]
		public static extern bool MediaSessionMgr_consumerSetInt32(HandleRef jarg1, int jarg2, string jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_consumerSetInt64")]
		public static extern bool MediaSessionMgr_consumerSetInt64(HandleRef jarg1, int jarg2, string jarg3, long jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_producerSetInt32")]
		public static extern bool MediaSessionMgr_producerSetInt32(HandleRef jarg1, int jarg2, string jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_producerSetInt64")]
		public static extern bool MediaSessionMgr_producerSetInt64(HandleRef jarg1, int jarg2, string jarg3, long jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_producerGetCodec")]
		public static extern IntPtr MediaSessionMgr_producerGetCodec(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_findProxyPluginConsumer")]
		public static extern IntPtr MediaSessionMgr_findProxyPluginConsumer(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_findProxyPluginProducer")]
		public static extern IntPtr MediaSessionMgr_findProxyPluginProducer(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_registerAudioPluginFromFile")]
		public static extern uint MediaSessionMgr_registerAudioPluginFromFile(string jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_getSessionId")]
		public static extern ulong MediaSessionMgr_getSessionId(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetProfile")]
		public static extern bool MediaSessionMgr_defaultsSetProfile(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetProfile")]
		public static extern int MediaSessionMgr_defaultsGetProfile();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetBandwidthLevel")]
		public static extern bool MediaSessionMgr_defaultsSetBandwidthLevel(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetBandwidthLevel")]
		public static extern int MediaSessionMgr_defaultsGetBandwidthLevel();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetCongestionCtrlEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetCongestionCtrlEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetVideoMotionRank")]
		public static extern bool MediaSessionMgr_defaultsSetVideoMotionRank(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetVideoFps")]
		public static extern bool MediaSessionMgr_defaultsSetVideoFps(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetBandwidthVideoUploadMax")]
		public static extern bool MediaSessionMgr_defaultsSetBandwidthVideoUploadMax(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetBandwidthVideoDownloadMax")]
		public static extern bool MediaSessionMgr_defaultsSetBandwidthVideoDownloadMax(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetPrefVideoSize")]
		public static extern bool MediaSessionMgr_defaultsSetPrefVideoSize(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetJbMargin")]
		public static extern bool MediaSessionMgr_defaultsSetJbMargin(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetJbMaxLateRate")]
		public static extern bool MediaSessionMgr_defaultsSetJbMaxLateRate(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetEchoTail")]
		public static extern bool MediaSessionMgr_defaultsSetEchoTail(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetEchoTail")]
		public static extern uint MediaSessionMgr_defaultsGetEchoTail();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetEchoSkew")]
		public static extern bool MediaSessionMgr_defaultsSetEchoSkew(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetEchoSuppEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetEchoSuppEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetEchoSuppEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetEchoSuppEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAgcEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetAgcEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetAgcEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetAgcEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAgcLevel")]
		public static extern bool MediaSessionMgr_defaultsSetAgcLevel(float jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetAgcLevel")]
		public static extern float MediaSessionMgr_defaultsGetAgcLevel();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetVadEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetVadEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetGetVadEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetGetVadEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetNoiseSuppEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetNoiseSuppEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetNoiseSuppEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetNoiseSuppEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetNoiseSuppLevel")]
		public static extern bool MediaSessionMgr_defaultsSetNoiseSuppLevel(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetNoiseSuppLevel")]
		public static extern int MediaSessionMgr_defaultsGetNoiseSuppLevel();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSet100relEnabled")]
		public static extern bool MediaSessionMgr_defaultsSet100relEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGet100relEnabled")]
		public static extern bool MediaSessionMgr_defaultsGet100relEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetScreenSize")]
		public static extern bool MediaSessionMgr_defaultsSetScreenSize(int jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAudioGain")]
		public static extern bool MediaSessionMgr_defaultsSetAudioGain(int jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAudioPtime")]
		public static extern bool MediaSessionMgr_defaultsSetAudioPtime(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAudioChannels")]
		public static extern bool MediaSessionMgr_defaultsSetAudioChannels(int jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetRtpPortRange")]
		public static extern bool MediaSessionMgr_defaultsSetRtpPortRange(ushort jarg1, ushort jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetRtpSymetricEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetRtpSymetricEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetMediaType")]
		public static extern bool MediaSessionMgr_defaultsSetMediaType(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetVolume")]
		public static extern bool MediaSessionMgr_defaultsSetVolume(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetVolume")]
		public static extern int MediaSessionMgr_defaultsGetVolume();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetInviteSessionTimers")]
		public static extern bool MediaSessionMgr_defaultsSetInviteSessionTimers(int jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetSRtpMode")]
		public static extern bool MediaSessionMgr_defaultsSetSRtpMode(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetSRtpMode")]
		public static extern int MediaSessionMgr_defaultsGetSRtpMode();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetSRtpType")]
		public static extern bool MediaSessionMgr_defaultsSetSRtpType(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetSRtpType")]
		public static extern int MediaSessionMgr_defaultsGetSRtpType();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetRtcpEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetRtcpEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetRtcpEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetRtcpEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetRtcpMuxEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetRtcpMuxEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetRtcpMuxEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetRtcpMuxEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetStunEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetStunEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetIceStunEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetIceStunEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetIceTurnEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetIceTurnEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetStunServer")]
		public static extern bool MediaSessionMgr_defaultsSetStunServer(string jarg1, ushort jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetStunCred")]
		public static extern bool MediaSessionMgr_defaultsSetStunCred(string jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetIceEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetIceEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetByPassEncoding")]
		public static extern bool MediaSessionMgr_defaultsSetByPassEncoding(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetByPassEncoding")]
		public static extern bool MediaSessionMgr_defaultsGetByPassEncoding();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetByPassDecoding")]
		public static extern bool MediaSessionMgr_defaultsSetByPassDecoding(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetByPassDecoding")]
		public static extern bool MediaSessionMgr_defaultsGetByPassDecoding();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetVideoJbEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetVideoJbEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetVideoJbEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetVideoJbEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetVideoZeroArtifactsEnabled")]
		public static extern bool MediaSessionMgr_defaultsSetVideoZeroArtifactsEnabled(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetVideoZeroArtifactsEnabled")]
		public static extern bool MediaSessionMgr_defaultsGetVideoZeroArtifactsEnabled();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetRtpBuffSize")]
		public static extern bool MediaSessionMgr_defaultsSetRtpBuffSize(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsGetRtpBuffSize")]
		public static extern uint MediaSessionMgr_defaultsGetRtpBuffSize();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAvpfTail")]
		public static extern bool MediaSessionMgr_defaultsSetAvpfTail(uint jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetAvpfMode")]
		public static extern bool MediaSessionMgr_defaultsSetAvpfMode(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetOpusMaxCaptureRate")]
		public static extern bool MediaSessionMgr_defaultsSetOpusMaxCaptureRate(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetOpusMaxPlaybackRate")]
		public static extern bool MediaSessionMgr_defaultsSetOpusMaxPlaybackRate(uint jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_defaultsSetMaxFds")]
		public static extern bool MediaSessionMgr_defaultsSetMaxFds(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MediaContent")]
		public static extern void delete_MediaContent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_getType")]
		public static extern string MediaContent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_getDataLength")]
		public static extern uint MediaContent_getDataLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_getData")]
		public static extern uint MediaContent_getData(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_parse__SWIG_0")]
		public static extern IntPtr MediaContent_parse__SWIG_0(IntPtr jarg1, uint jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_parse__SWIG_1")]
		public static extern IntPtr MediaContent_parse__SWIG_1(IntPtr jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_getPayloadLength")]
		public static extern uint MediaContent_getPayloadLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContent_getPayload")]
		public static extern uint MediaContent_getPayload(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MediaContentCPIM")]
		public static extern void delete_MediaContentCPIM(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContentCPIM_getPayloadLength")]
		public static extern uint MediaContentCPIM_getPayloadLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContentCPIM_getPayload")]
		public static extern uint MediaContentCPIM_getPayload(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContentCPIM_getHeaderValue")]
		public static extern string MediaContentCPIM_getHeaderValue(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SipUri__SWIG_0")]
		public static extern IntPtr new_SipUri__SWIG_0(string jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SipUri__SWIG_1")]
		public static extern IntPtr new_SipUri__SWIG_1(string jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SipUri")]
		public static extern void delete_SipUri(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_isValid__SWIG_0")]
		public static extern bool SipUri_isValid__SWIG_0(string jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_isValid__SWIG_1")]
		public static extern bool SipUri_isValid__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getScheme")]
		public static extern string SipUri_getScheme(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getHost")]
		public static extern string SipUri_getHost(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getPort")]
		public static extern ushort SipUri_getPort(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getUserName")]
		public static extern string SipUri_getUserName(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getPassword")]
		public static extern string SipUri_getPassword(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getDisplayName")]
		public static extern string SipUri_getDisplayName(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_getParamValue")]
		public static extern string SipUri_getParamValue(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipUri_setDisplayName")]
		public static extern void SipUri_setDisplayName(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SdpMessage")]
		public static extern IntPtr new_SdpMessage();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SdpMessage")]
		public static extern void delete_SdpMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SdpMessage_getSdpHeaderValue__SWIG_0")]
		public static extern string SdpMessage_getSdpHeaderValue__SWIG_0(HandleRef jarg1, string jarg2, char jarg3, uint jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SdpMessage_getSdpHeaderValue__SWIG_1")]
		public static extern string SdpMessage_getSdpHeaderValue__SWIG_1(HandleRef jarg1, string jarg2, char jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SdpMessage_getSdpHeaderAValue")]
		public static extern string SdpMessage_getSdpHeaderAValue(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SipMessage")]
		public static extern IntPtr new_SipMessage();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SipMessage")]
		public static extern void delete_SipMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_isResponse")]
		public static extern bool SipMessage_isResponse(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getRequestType")]
		public static extern int SipMessage_getRequestType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getResponseCode")]
		public static extern short SipMessage_getResponseCode(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getResponsePhrase")]
		public static extern string SipMessage_getResponsePhrase(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSipHeaderValue__SWIG_0")]
		public static extern string SipMessage_getSipHeaderValue__SWIG_0(HandleRef jarg1, string jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSipHeaderValue__SWIG_1")]
		public static extern string SipMessage_getSipHeaderValue__SWIG_1(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSipHeaderParamValue__SWIG_0")]
		public static extern string SipMessage_getSipHeaderParamValue__SWIG_0(HandleRef jarg1, string jarg2, string jarg3, uint jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSipHeaderParamValue__SWIG_1")]
		public static extern string SipMessage_getSipHeaderParamValue__SWIG_1(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSipContentLength")]
		public static extern uint SipMessage_getSipContentLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSipContent")]
		public static extern uint SipMessage_getSipContent(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipMessage_getSdpMessage")]
		public static extern IntPtr SipMessage_getSdpMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SipEvent")]
		public static extern void delete_SipEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipEvent_getCode")]
		public static extern short SipEvent_getCode(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipEvent_getPhrase")]
		public static extern string SipEvent_getPhrase(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipEvent_getBaseSession")]
		public static extern IntPtr SipEvent_getBaseSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipEvent_getSipMessage")]
		public static extern IntPtr SipEvent_getSipMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_DialogEvent")]
		public static extern void delete_DialogEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_StackEvent")]
		public static extern void delete_StackEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_InviteEvent")]
		public static extern void delete_InviteEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteEvent_getType")]
		public static extern int InviteEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteEvent_getMediaType")]
		public static extern int InviteEvent_getMediaType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteEvent_getSession")]
		public static extern IntPtr InviteEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteEvent_takeCallSessionOwnership")]
		public static extern IntPtr InviteEvent_takeCallSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteEvent_takeMsrpSessionOwnership")]
		public static extern IntPtr InviteEvent_takeMsrpSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MessagingEvent")]
		public static extern void delete_MessagingEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingEvent_getType")]
		public static extern int MessagingEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingEvent_getSession")]
		public static extern IntPtr MessagingEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingEvent_takeSessionOwnership")]
		public static extern IntPtr MessagingEvent_takeSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_InfoEvent")]
		public static extern void delete_InfoEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoEvent_getType")]
		public static extern int InfoEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoEvent_getSession")]
		public static extern IntPtr InfoEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoEvent_takeSessionOwnership")]
		public static extern IntPtr InfoEvent_takeSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_OptionsEvent")]
		public static extern void delete_OptionsEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsEvent_getType")]
		public static extern int OptionsEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsEvent_getSession")]
		public static extern IntPtr OptionsEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsEvent_takeSessionOwnership")]
		public static extern IntPtr OptionsEvent_takeSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_PublicationEvent")]
		public static extern void delete_PublicationEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationEvent_getType")]
		public static extern int PublicationEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationEvent_getSession")]
		public static extern IntPtr PublicationEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationEvent_takeSessionOwnership")]
		public static extern IntPtr PublicationEvent_takeSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_RegistrationEvent")]
		public static extern void delete_RegistrationEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationEvent_getType")]
		public static extern int RegistrationEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationEvent_getSession")]
		public static extern IntPtr RegistrationEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationEvent_takeSessionOwnership")]
		public static extern IntPtr RegistrationEvent_takeSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SubscriptionEvent")]
		public static extern void delete_SubscriptionEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionEvent_getType")]
		public static extern int SubscriptionEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionEvent_getSession")]
		public static extern IntPtr SubscriptionEvent_getSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionEvent_takeSessionOwnership")]
		public static extern IntPtr SubscriptionEvent_takeSessionOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_T140CallbackData")]
		public static extern void delete_T140CallbackData(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_T140CallbackData_getType")]
		public static extern int T140CallbackData_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_T140CallbackData_getSize")]
		public static extern uint T140CallbackData_getSize(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_T140CallbackData_getData")]
		public static extern uint T140CallbackData_getData(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_T140Callback")]
		public static extern IntPtr new_T140Callback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_T140Callback")]
		public static extern void delete_T140Callback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_T140Callback_ondata")]
		public static extern int T140Callback_ondata(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_T140Callback_ondataSwigExplicitT140Callback")]
		public static extern int T140Callback_ondataSwigExplicitT140Callback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_T140Callback_director_connect")]
		public static extern void T140Callback_director_connect(HandleRef jarg1, T140Callback.SwigDelegateT140Callback_0 delegate0);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SipSession")]
		public static extern IntPtr new_SipSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SipSession")]
		public static extern void delete_SipSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_haveOwnership")]
		public static extern bool SipSession_haveOwnership(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_addHeader")]
		public static extern bool SipSession_addHeader(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_removeHeader")]
		public static extern bool SipSession_removeHeader(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_addCaps__SWIG_0")]
		public static extern bool SipSession_addCaps__SWIG_0(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_addCaps__SWIG_1")]
		public static extern bool SipSession_addCaps__SWIG_1(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_removeCaps")]
		public static extern bool SipSession_removeCaps(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_setExpires")]
		public static extern bool SipSession_setExpires(HandleRef jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_setFromUri__SWIG_0")]
		public static extern bool SipSession_setFromUri__SWIG_0(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_setFromUri__SWIG_1")]
		public static extern bool SipSession_setFromUri__SWIG_1(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_setToUri__SWIG_0")]
		public static extern bool SipSession_setToUri__SWIG_0(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_setToUri__SWIG_1")]
		public static extern bool SipSession_setToUri__SWIG_1(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_setSilentHangup")]
		public static extern bool SipSession_setSilentHangup(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_addSigCompCompartment")]
		public static extern bool SipSession_addSigCompCompartment(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_removeSigCompCompartment")]
		public static extern bool SipSession_removeSigCompCompartment(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipSession_getId")]
		public static extern uint SipSession_getId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_InviteSession")]
		public static extern IntPtr new_InviteSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_InviteSession")]
		public static extern void delete_InviteSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_accept__SWIG_0")]
		public static extern bool InviteSession_accept__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_accept__SWIG_1")]
		public static extern bool InviteSession_accept__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_hangup__SWIG_0")]
		public static extern bool InviteSession_hangup__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_hangup__SWIG_1")]
		public static extern bool InviteSession_hangup__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_reject__SWIG_0")]
		public static extern bool InviteSession_reject__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_reject__SWIG_1")]
		public static extern bool InviteSession_reject__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_sendInfo__SWIG_0")]
		public static extern bool InviteSession_sendInfo__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_sendInfo__SWIG_1")]
		public static extern bool InviteSession_sendInfo__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_getMediaMgr")]
		public static extern IntPtr InviteSession_getMediaMgr(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_CallSession")]
		public static extern IntPtr new_CallSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_CallSession")]
		public static extern void delete_CallSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudio__SWIG_0")]
		public static extern bool CallSession_callAudio__SWIG_0(HandleRef jarg1, string jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudio__SWIG_1")]
		public static extern bool CallSession_callAudio__SWIG_1(HandleRef jarg1, string jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudio__SWIG_2")]
		public static extern bool CallSession_callAudio__SWIG_2(HandleRef jarg1, HandleRef jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudio__SWIG_3")]
		public static extern bool CallSession_callAudio__SWIG_3(HandleRef jarg1, HandleRef jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudioVideo__SWIG_0")]
		public static extern bool CallSession_callAudioVideo__SWIG_0(HandleRef jarg1, string jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudioVideo__SWIG_1")]
		public static extern bool CallSession_callAudioVideo__SWIG_1(HandleRef jarg1, string jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudioVideo__SWIG_2")]
		public static extern bool CallSession_callAudioVideo__SWIG_2(HandleRef jarg1, HandleRef jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callAudioVideo__SWIG_3")]
		public static extern bool CallSession_callAudioVideo__SWIG_3(HandleRef jarg1, HandleRef jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callVideo__SWIG_0")]
		public static extern bool CallSession_callVideo__SWIG_0(HandleRef jarg1, string jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callVideo__SWIG_1")]
		public static extern bool CallSession_callVideo__SWIG_1(HandleRef jarg1, string jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callVideo__SWIG_2")]
		public static extern bool CallSession_callVideo__SWIG_2(HandleRef jarg1, HandleRef jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_callVideo__SWIG_3")]
		public static extern bool CallSession_callVideo__SWIG_3(HandleRef jarg1, HandleRef jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_call__SWIG_0")]
		public static extern bool CallSession_call__SWIG_0(HandleRef jarg1, string jarg2, int jarg3, int jarg4, HandleRef jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_call__SWIG_1")]
		public static extern bool CallSession_call__SWIG_1(HandleRef jarg1, string jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_call__SWIG_2")]
		public static extern bool CallSession_call__SWIG_2(HandleRef jarg1, HandleRef jarg2, int jarg3, int jarg4, HandleRef jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_call__SWIG_3")]
		public static extern bool CallSession_call__SWIG_3(HandleRef jarg1, HandleRef jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setSessionTimer")]
		public static extern bool CallSession_setSessionTimer(HandleRef jarg1, uint jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_set100rel")]
		public static extern bool CallSession_set100rel(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setRtcp")]
		public static extern bool CallSession_setRtcp(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setRtcpMux")]
		public static extern bool CallSession_setRtcpMux(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setSRtpMode")]
		public static extern bool CallSession_setSRtpMode(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setAvpfMode")]
		public static extern bool CallSession_setAvpfMode(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setICE")]
		public static extern bool CallSession_setICE(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setICEStun")]
		public static extern bool CallSession_setICEStun(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setICETurn")]
		public static extern bool CallSession_setICETurn(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setSTUNServer")]
		public static extern bool CallSession_setSTUNServer(HandleRef jarg1, string jarg2, ushort jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setSTUNCred")]
		public static extern bool CallSession_setSTUNCred(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setVideoFps")]
		public static extern bool CallSession_setVideoFps(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setVideoBandwidthUploadMax")]
		public static extern bool CallSession_setVideoBandwidthUploadMax(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setVideoBandwidthDownloadMax")]
		public static extern bool CallSession_setVideoBandwidthDownloadMax(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setVideoPrefSize")]
		public static extern bool CallSession_setVideoPrefSize(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setQoS")]
		public static extern bool CallSession_setQoS(HandleRef jarg1, int jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_hold__SWIG_0")]
		public static extern bool CallSession_hold__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_hold__SWIG_1")]
		public static extern bool CallSession_hold__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_resume__SWIG_0")]
		public static extern bool CallSession_resume__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_resume__SWIG_1")]
		public static extern bool CallSession_resume__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_update__SWIG_0")]
		public static extern bool CallSession_update__SWIG_0(HandleRef jarg1, int jarg2, int jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_update__SWIG_1")]
		public static extern bool CallSession_update__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_transfer__SWIG_0")]
		public static extern bool CallSession_transfer__SWIG_0(HandleRef jarg1, string jarg2, HandleRef jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_transfer__SWIG_1")]
		public static extern bool CallSession_transfer__SWIG_1(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_acceptTransfer__SWIG_0")]
		public static extern bool CallSession_acceptTransfer__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_acceptTransfer__SWIG_1")]
		public static extern bool CallSession_acceptTransfer__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_rejectTransfer__SWIG_0")]
		public static extern bool CallSession_rejectTransfer__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_rejectTransfer__SWIG_1")]
		public static extern bool CallSession_rejectTransfer__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_sendDTMF")]
		public static extern bool CallSession_sendDTMF(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_getSessionTransferId")]
		public static extern uint CallSession_getSessionTransferId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_sendT140Data__SWIG_0")]
		public static extern bool CallSession_sendT140Data__SWIG_0(HandleRef jarg1, int jarg2, IntPtr jarg3, uint jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_sendT140Data__SWIG_1")]
		public static extern bool CallSession_sendT140Data__SWIG_1(HandleRef jarg1, int jarg2, IntPtr jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_sendT140Data__SWIG_2")]
		public static extern bool CallSession_sendT140Data__SWIG_2(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_setT140Callback")]
		public static extern bool CallSession_setT140Callback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_MsrpSession")]
		public static extern IntPtr new_MsrpSession(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MsrpSession")]
		public static extern void delete_MsrpSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_setCallback")]
		public static extern bool MsrpSession_setCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_callMsrp__SWIG_0")]
		public static extern bool MsrpSession_callMsrp__SWIG_0(HandleRef jarg1, string jarg2, HandleRef jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_callMsrp__SWIG_1")]
		public static extern bool MsrpSession_callMsrp__SWIG_1(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_callMsrp__SWIG_2")]
		public static extern bool MsrpSession_callMsrp__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_callMsrp__SWIG_3")]
		public static extern bool MsrpSession_callMsrp__SWIG_3(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_sendMessage__SWIG_0")]
		public static extern bool MsrpSession_sendMessage__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_sendMessage__SWIG_1")]
		public static extern bool MsrpSession_sendMessage__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_sendFile__SWIG_0")]
		public static extern bool MsrpSession_sendFile__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_sendFile__SWIG_1")]
		public static extern bool MsrpSession_sendFile__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_MessagingSession")]
		public static extern IntPtr new_MessagingSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MessagingSession")]
		public static extern void delete_MessagingSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_send__SWIG_0")]
		public static extern bool MessagingSession_send__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_send__SWIG_1")]
		public static extern bool MessagingSession_send__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_accept__SWIG_0")]
		public static extern bool MessagingSession_accept__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_accept__SWIG_1")]
		public static extern bool MessagingSession_accept__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_reject__SWIG_0")]
		public static extern bool MessagingSession_reject__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_reject__SWIG_1")]
		public static extern bool MessagingSession_reject__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_InfoSession")]
		public static extern IntPtr new_InfoSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_InfoSession")]
		public static extern void delete_InfoSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_send__SWIG_0")]
		public static extern bool InfoSession_send__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_send__SWIG_1")]
		public static extern bool InfoSession_send__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_accept__SWIG_0")]
		public static extern bool InfoSession_accept__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_accept__SWIG_1")]
		public static extern bool InfoSession_accept__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_reject__SWIG_0")]
		public static extern bool InfoSession_reject__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_reject__SWIG_1")]
		public static extern bool InfoSession_reject__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_OptionsSession")]
		public static extern IntPtr new_OptionsSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_OptionsSession")]
		public static extern void delete_OptionsSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_send__SWIG_0")]
		public static extern bool OptionsSession_send__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_send__SWIG_1")]
		public static extern bool OptionsSession_send__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_accept__SWIG_0")]
		public static extern bool OptionsSession_accept__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_accept__SWIG_1")]
		public static extern bool OptionsSession_accept__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_reject__SWIG_0")]
		public static extern bool OptionsSession_reject__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_reject__SWIG_1")]
		public static extern bool OptionsSession_reject__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_PublicationSession")]
		public static extern IntPtr new_PublicationSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_PublicationSession")]
		public static extern void delete_PublicationSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationSession_publish__SWIG_0")]
		public static extern bool PublicationSession_publish__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, HandleRef jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationSession_publish__SWIG_1")]
		public static extern bool PublicationSession_publish__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationSession_unPublish__SWIG_0")]
		public static extern bool PublicationSession_unPublish__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationSession_unPublish__SWIG_1")]
		public static extern bool PublicationSession_unPublish__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_RegistrationSession")]
		public static extern IntPtr new_RegistrationSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_RegistrationSession")]
		public static extern void delete_RegistrationSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_register___SWIG_0")]
		public static extern bool RegistrationSession_register___SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_register___SWIG_1")]
		public static extern bool RegistrationSession_register___SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_unRegister__SWIG_0")]
		public static extern bool RegistrationSession_unRegister__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_unRegister__SWIG_1")]
		public static extern bool RegistrationSession_unRegister__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_accept__SWIG_0")]
		public static extern bool RegistrationSession_accept__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_accept__SWIG_1")]
		public static extern bool RegistrationSession_accept__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_reject__SWIG_0")]
		public static extern bool RegistrationSession_reject__SWIG_0(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_reject__SWIG_1")]
		public static extern bool RegistrationSession_reject__SWIG_1(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SubscriptionSession")]
		public static extern IntPtr new_SubscriptionSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SubscriptionSession")]
		public static extern void delete_SubscriptionSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionSession_subscribe")]
		public static extern bool SubscriptionSession_subscribe(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionSession_unSubscribe")]
		public static extern bool SubscriptionSession_unSubscribe(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyPluginMgr")]
		public static extern void delete_ProxyPluginMgr(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_createInstance")]
		public static extern IntPtr ProxyPluginMgr_createInstance(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_getInstance")]
		public static extern IntPtr ProxyPluginMgr_getInstance();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_findPlugin")]
		public static extern IntPtr ProxyPluginMgr_findPlugin(HandleRef jarg1, ulong jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_findAudioConsumer")]
		public static extern IntPtr ProxyPluginMgr_findAudioConsumer(HandleRef jarg1, ulong jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_findVideoConsumer")]
		public static extern IntPtr ProxyPluginMgr_findVideoConsumer(HandleRef jarg1, ulong jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_findAudioProducer")]
		public static extern IntPtr ProxyPluginMgr_findAudioProducer(HandleRef jarg1, ulong jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgr_findVideoProducer")]
		public static extern IntPtr ProxyPluginMgr_findVideoProducer(HandleRef jarg1, ulong jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_ProxyPluginMgrCallback")]
		public static extern IntPtr new_ProxyPluginMgrCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyPluginMgrCallback")]
		public static extern void delete_ProxyPluginMgrCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgrCallback_OnPluginCreated")]
		public static extern int ProxyPluginMgrCallback_OnPluginCreated(HandleRef jarg1, ulong jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgrCallback_OnPluginCreatedSwigExplicitProxyPluginMgrCallback")]
		public static extern int ProxyPluginMgrCallback_OnPluginCreatedSwigExplicitProxyPluginMgrCallback(HandleRef jarg1, ulong jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgrCallback_OnPluginDestroyed")]
		public static extern int ProxyPluginMgrCallback_OnPluginDestroyed(HandleRef jarg1, ulong jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgrCallback_OnPluginDestroyedSwigExplicitProxyPluginMgrCallback")]
		public static extern int ProxyPluginMgrCallback_OnPluginDestroyedSwigExplicitProxyPluginMgrCallback(HandleRef jarg1, ulong jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPluginMgrCallback_director_connect")]
		public static extern void ProxyPluginMgrCallback_director_connect(HandleRef jarg1, ProxyPluginMgrCallback.SwigDelegateProxyPluginMgrCallback_0 delegate0, ProxyPluginMgrCallback.SwigDelegateProxyPluginMgrCallback_1 delegate1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyPlugin")]
		public static extern void delete_ProxyPlugin(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPlugin_getType")]
		public static extern int ProxyPlugin_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyPlugin_getId")]
		public static extern ulong ProxyPlugin_getId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_ProxyAudioConsumerCallback")]
		public static extern IntPtr new_ProxyAudioConsumerCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyAudioConsumerCallback")]
		public static extern void delete_ProxyAudioConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_prepare")]
		public static extern int ProxyAudioConsumerCallback_prepare(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_prepareSwigExplicitProxyAudioConsumerCallback")]
		public static extern int ProxyAudioConsumerCallback_prepareSwigExplicitProxyAudioConsumerCallback(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_start")]
		public static extern int ProxyAudioConsumerCallback_start(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_startSwigExplicitProxyAudioConsumerCallback")]
		public static extern int ProxyAudioConsumerCallback_startSwigExplicitProxyAudioConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_pause")]
		public static extern int ProxyAudioConsumerCallback_pause(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_pauseSwigExplicitProxyAudioConsumerCallback")]
		public static extern int ProxyAudioConsumerCallback_pauseSwigExplicitProxyAudioConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_stop")]
		public static extern int ProxyAudioConsumerCallback_stop(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_stopSwigExplicitProxyAudioConsumerCallback")]
		public static extern int ProxyAudioConsumerCallback_stopSwigExplicitProxyAudioConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumerCallback_director_connect")]
		public static extern void ProxyAudioConsumerCallback_director_connect(HandleRef jarg1, ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_0 delegate0, ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_1 delegate1, ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_2 delegate2, ProxyAudioConsumerCallback.SwigDelegateProxyAudioConsumerCallback_3 delegate3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyAudioConsumer")]
		public static extern void delete_ProxyAudioConsumer(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_setActualSndCardPlaybackParams")]
		public static extern bool ProxyAudioConsumer_setActualSndCardPlaybackParams(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_queryForResampler")]
		public static extern bool ProxyAudioConsumer_queryForResampler(HandleRef jarg1, ushort jarg2, ushort jarg3, ushort jarg4, ushort jarg5, ushort jarg6);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_setPullBuffer")]
		public static extern bool ProxyAudioConsumer_setPullBuffer(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_pull__SWIG_0")]
		public static extern uint ProxyAudioConsumer_pull__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_pull__SWIG_1")]
		public static extern uint ProxyAudioConsumer_pull__SWIG_1(HandleRef jarg1, IntPtr jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_pull__SWIG_2")]
		public static extern uint ProxyAudioConsumer_pull__SWIG_2(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_setGain")]
		public static extern bool ProxyAudioConsumer_setGain(HandleRef jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_getGain")]
		public static extern uint ProxyAudioConsumer_getGain(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_reset")]
		public static extern bool ProxyAudioConsumer_reset(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_setCallback")]
		public static extern void ProxyAudioConsumer_setCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_getMediaSessionId")]
		public static extern ulong ProxyAudioConsumer_getMediaSessionId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_registerPlugin")]
		public static extern bool ProxyAudioConsumer_registerPlugin();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_ProxyVideoConsumerCallback")]
		public static extern IntPtr new_ProxyVideoConsumerCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyVideoConsumerCallback")]
		public static extern void delete_ProxyVideoConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_prepare")]
		public static extern int ProxyVideoConsumerCallback_prepare(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_prepareSwigExplicitProxyVideoConsumerCallback")]
		public static extern int ProxyVideoConsumerCallback_prepareSwigExplicitProxyVideoConsumerCallback(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_consume")]
		public static extern int ProxyVideoConsumerCallback_consume(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_consumeSwigExplicitProxyVideoConsumerCallback")]
		public static extern int ProxyVideoConsumerCallback_consumeSwigExplicitProxyVideoConsumerCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_bufferCopied")]
		public static extern int ProxyVideoConsumerCallback_bufferCopied(HandleRef jarg1, uint jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_bufferCopiedSwigExplicitProxyVideoConsumerCallback")]
		public static extern int ProxyVideoConsumerCallback_bufferCopiedSwigExplicitProxyVideoConsumerCallback(HandleRef jarg1, uint jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_start")]
		public static extern int ProxyVideoConsumerCallback_start(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_startSwigExplicitProxyVideoConsumerCallback")]
		public static extern int ProxyVideoConsumerCallback_startSwigExplicitProxyVideoConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_pause")]
		public static extern int ProxyVideoConsumerCallback_pause(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_pauseSwigExplicitProxyVideoConsumerCallback")]
		public static extern int ProxyVideoConsumerCallback_pauseSwigExplicitProxyVideoConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_stop")]
		public static extern int ProxyVideoConsumerCallback_stop(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_stopSwigExplicitProxyVideoConsumerCallback")]
		public static extern int ProxyVideoConsumerCallback_stopSwigExplicitProxyVideoConsumerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumerCallback_director_connect")]
		public static extern void ProxyVideoConsumerCallback_director_connect(HandleRef jarg1, ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_0 delegate0, ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_1 delegate1, ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_2 delegate2, ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_3 delegate3, ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_4 delegate4, ProxyVideoConsumerCallback.SwigDelegateProxyVideoConsumerCallback_5 delegate5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyVideoConsumer")]
		public static extern void delete_ProxyVideoConsumer(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_setDisplaySize")]
		public static extern bool ProxyVideoConsumer_setDisplaySize(HandleRef jarg1, uint jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_getDisplayWidth")]
		public static extern uint ProxyVideoConsumer_getDisplayWidth(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_getDisplayHeight")]
		public static extern uint ProxyVideoConsumer_getDisplayHeight(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_getDecodedWidth")]
		public static extern uint ProxyVideoConsumer_getDecodedWidth(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_getDecodedHeight")]
		public static extern uint ProxyVideoConsumer_getDecodedHeight(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_setCallback")]
		public static extern void ProxyVideoConsumer_setCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_setAutoResizeDisplay")]
		public static extern bool ProxyVideoConsumer_setAutoResizeDisplay(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_getAutoResizeDisplay")]
		public static extern bool ProxyVideoConsumer_getAutoResizeDisplay(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_setConsumeBuffer")]
		public static extern bool ProxyVideoConsumer_setConsumeBuffer(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_pull")]
		public static extern uint ProxyVideoConsumer_pull(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_reset")]
		public static extern bool ProxyVideoConsumer_reset(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_getMediaSessionId")]
		public static extern ulong ProxyVideoConsumer_getMediaSessionId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_registerPlugin")]
		public static extern bool ProxyVideoConsumer_registerPlugin();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_setDefaultChroma")]
		public static extern void ProxyVideoConsumer_setDefaultChroma(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_setDefaultAutoResizeDisplay")]
		public static extern void ProxyVideoConsumer_setDefaultAutoResizeDisplay(bool jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyVideoFrame")]
		public static extern void delete_ProxyVideoFrame(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoFrame_getSize")]
		public static extern uint ProxyVideoFrame_getSize(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoFrame_getContent")]
		public static extern uint ProxyVideoFrame_getContent(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoFrame_getFrameWidth")]
		public static extern uint ProxyVideoFrame_getFrameWidth(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoFrame_getFrameHeight")]
		public static extern uint ProxyVideoFrame_getFrameHeight(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_ProxyAudioProducerCallback")]
		public static extern IntPtr new_ProxyAudioProducerCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyAudioProducerCallback")]
		public static extern void delete_ProxyAudioProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_prepare")]
		public static extern int ProxyAudioProducerCallback_prepare(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_prepareSwigExplicitProxyAudioProducerCallback")]
		public static extern int ProxyAudioProducerCallback_prepareSwigExplicitProxyAudioProducerCallback(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_start")]
		public static extern int ProxyAudioProducerCallback_start(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_startSwigExplicitProxyAudioProducerCallback")]
		public static extern int ProxyAudioProducerCallback_startSwigExplicitProxyAudioProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_pause")]
		public static extern int ProxyAudioProducerCallback_pause(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_pauseSwigExplicitProxyAudioProducerCallback")]
		public static extern int ProxyAudioProducerCallback_pauseSwigExplicitProxyAudioProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_stop")]
		public static extern int ProxyAudioProducerCallback_stop(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_stopSwigExplicitProxyAudioProducerCallback")]
		public static extern int ProxyAudioProducerCallback_stopSwigExplicitProxyAudioProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_fillPushBuffer")]
		public static extern int ProxyAudioProducerCallback_fillPushBuffer(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_fillPushBufferSwigExplicitProxyAudioProducerCallback")]
		public static extern int ProxyAudioProducerCallback_fillPushBufferSwigExplicitProxyAudioProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducerCallback_director_connect")]
		public static extern void ProxyAudioProducerCallback_director_connect(HandleRef jarg1, ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_0 delegate0, ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_1 delegate1, ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_2 delegate2, ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_3 delegate3, ProxyAudioProducerCallback.SwigDelegateProxyAudioProducerCallback_4 delegate4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyAudioProducer")]
		public static extern void delete_ProxyAudioProducer(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_setActualSndCardRecordParams")]
		public static extern bool ProxyAudioProducer_setActualSndCardRecordParams(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_setPushBuffer__SWIG_0")]
		public static extern bool ProxyAudioProducer_setPushBuffer__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, bool jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_setPushBuffer__SWIG_1")]
		public static extern bool ProxyAudioProducer_setPushBuffer__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_push__SWIG_0")]
		public static extern int ProxyAudioProducer_push__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_push__SWIG_1")]
		public static extern int ProxyAudioProducer_push__SWIG_1(HandleRef jarg1, IntPtr jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_push__SWIG_2")]
		public static extern int ProxyAudioProducer_push__SWIG_2(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_setGain")]
		public static extern bool ProxyAudioProducer_setGain(HandleRef jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_getGain")]
		public static extern uint ProxyAudioProducer_getGain(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_setCallback")]
		public static extern void ProxyAudioProducer_setCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_getMediaSessionId")]
		public static extern ulong ProxyAudioProducer_getMediaSessionId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_registerPlugin")]
		public static extern bool ProxyAudioProducer_registerPlugin();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_ProxyVideoProducerCallback")]
		public static extern IntPtr new_ProxyVideoProducerCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyVideoProducerCallback")]
		public static extern void delete_ProxyVideoProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_prepare")]
		public static extern int ProxyVideoProducerCallback_prepare(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_prepareSwigExplicitProxyVideoProducerCallback")]
		public static extern int ProxyVideoProducerCallback_prepareSwigExplicitProxyVideoProducerCallback(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_start")]
		public static extern int ProxyVideoProducerCallback_start(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_startSwigExplicitProxyVideoProducerCallback")]
		public static extern int ProxyVideoProducerCallback_startSwigExplicitProxyVideoProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_pause")]
		public static extern int ProxyVideoProducerCallback_pause(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_pauseSwigExplicitProxyVideoProducerCallback")]
		public static extern int ProxyVideoProducerCallback_pauseSwigExplicitProxyVideoProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_stop")]
		public static extern int ProxyVideoProducerCallback_stop(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_stopSwigExplicitProxyVideoProducerCallback")]
		public static extern int ProxyVideoProducerCallback_stopSwigExplicitProxyVideoProducerCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducerCallback_director_connect")]
		public static extern void ProxyVideoProducerCallback_director_connect(HandleRef jarg1, ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_0 delegate0, ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_1 delegate1, ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_2 delegate2, ProxyVideoProducerCallback.SwigDelegateProxyVideoProducerCallback_3 delegate3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_ProxyVideoProducer")]
		public static extern void delete_ProxyVideoProducer(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_getRotation")]
		public static extern int ProxyVideoProducer_getRotation(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_setRotation")]
		public static extern bool ProxyVideoProducer_setRotation(HandleRef jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_getMirror")]
		public static extern bool ProxyVideoProducer_getMirror(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_setMirror")]
		public static extern bool ProxyVideoProducer_setMirror(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_setActualCameraOutputSize")]
		public static extern bool ProxyVideoProducer_setActualCameraOutputSize(HandleRef jarg1, uint jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_push")]
		public static extern int ProxyVideoProducer_push(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_setCallback")]
		public static extern void ProxyVideoProducer_setCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_getMediaSessionId")]
		public static extern ulong ProxyVideoProducer_getMediaSessionId(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_registerPlugin")]
		public static extern bool ProxyVideoProducer_registerPlugin();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_setDefaultChroma")]
		public static extern void ProxyVideoProducer_setDefaultChroma(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SipCallback")]
		public static extern IntPtr new_SipCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SipCallback")]
		public static extern void delete_SipCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnDialogEvent")]
		public static extern int SipCallback_OnDialogEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnDialogEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnDialogEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnStackEvent")]
		public static extern int SipCallback_OnStackEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnStackEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnStackEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnInviteEvent")]
		public static extern int SipCallback_OnInviteEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnInviteEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnInviteEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnMessagingEvent")]
		public static extern int SipCallback_OnMessagingEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnMessagingEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnMessagingEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnInfoEvent")]
		public static extern int SipCallback_OnInfoEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnInfoEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnInfoEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnOptionsEvent")]
		public static extern int SipCallback_OnOptionsEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnOptionsEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnOptionsEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnPublicationEvent")]
		public static extern int SipCallback_OnPublicationEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnPublicationEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnPublicationEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnRegistrationEvent")]
		public static extern int SipCallback_OnRegistrationEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnRegistrationEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnRegistrationEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnSubscriptionEvent")]
		public static extern int SipCallback_OnSubscriptionEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_OnSubscriptionEventSwigExplicitSipCallback")]
		public static extern int SipCallback_OnSubscriptionEventSwigExplicitSipCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipCallback_director_connect")]
		public static extern void SipCallback_director_connect(HandleRef jarg1, SipCallback.SwigDelegateSipCallback_0 delegate0, SipCallback.SwigDelegateSipCallback_1 delegate1, SipCallback.SwigDelegateSipCallback_2 delegate2, SipCallback.SwigDelegateSipCallback_3 delegate3, SipCallback.SwigDelegateSipCallback_4 delegate4, SipCallback.SwigDelegateSipCallback_5 delegate5, SipCallback.SwigDelegateSipCallback_6 delegate6, SipCallback.SwigDelegateSipCallback_7 delegate7, SipCallback.SwigDelegateSipCallback_8 delegate8);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SafeObject")]
		public static extern IntPtr new_SafeObject();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SafeObject")]
		public static extern void delete_SafeObject(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SafeObject_Lock")]
		public static extern int SafeObject_Lock(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SafeObject_UnLock")]
		public static extern int SafeObject_UnLock(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SipStack")]
		public static extern IntPtr new_SipStack(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SipStack")]
		public static extern void delete_SipStack(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_start")]
		public static extern bool SipStack_start(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setDebugCallback")]
		public static extern bool SipStack_setDebugCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setDisplayName")]
		public static extern bool SipStack_setDisplayName(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setRealm")]
		public static extern bool SipStack_setRealm(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setIMPI")]
		public static extern bool SipStack_setIMPI(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setIMPU")]
		public static extern bool SipStack_setIMPU(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setPassword")]
		public static extern bool SipStack_setPassword(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setAMF")]
		public static extern bool SipStack_setAMF(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setOperatorId")]
		public static extern bool SipStack_setOperatorId(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setProxyCSCF")]
		public static extern bool SipStack_setProxyCSCF(HandleRef jarg1, string jarg2, ushort jarg3, string jarg4, string jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setLocalIP__SWIG_0")]
		public static extern bool SipStack_setLocalIP__SWIG_0(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setLocalIP__SWIG_1")]
		public static extern bool SipStack_setLocalIP__SWIG_1(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setLocalPort__SWIG_0")]
		public static extern bool SipStack_setLocalPort__SWIG_0(HandleRef jarg1, ushort jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setLocalPort__SWIG_1")]
		public static extern bool SipStack_setLocalPort__SWIG_1(HandleRef jarg1, ushort jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setEarlyIMS")]
		public static extern bool SipStack_setEarlyIMS(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_addHeader")]
		public static extern bool SipStack_addHeader(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_removeHeader")]
		public static extern bool SipStack_removeHeader(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_addDnsServer")]
		public static extern bool SipStack_addDnsServer(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setDnsDiscovery")]
		public static extern bool SipStack_setDnsDiscovery(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setAoR")]
		public static extern bool SipStack_setAoR(HandleRef jarg1, string jarg2, int jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSigCompParams")]
		public static extern bool SipStack_setSigCompParams(HandleRef jarg1, uint jarg2, uint jarg3, uint jarg4, bool jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_addSigCompCompartment")]
		public static extern bool SipStack_addSigCompCompartment(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_removeSigCompCompartment")]
		public static extern bool SipStack_removeSigCompCompartment(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSTUNEnabledForICE")]
		public static extern bool SipStack_setSTUNEnabledForICE(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSTUNServer")]
		public static extern bool SipStack_setSTUNServer(HandleRef jarg1, string jarg2, ushort jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSTUNCred")]
		public static extern bool SipStack_setSTUNCred(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSTUNEnabled")]
		public static extern bool SipStack_setSTUNEnabled(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setTLSSecAgree")]
		public static extern bool SipStack_setTLSSecAgree(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSSLCertificates__SWIG_0")]
		public static extern bool SipStack_setSSLCertificates__SWIG_0(HandleRef jarg1, string jarg2, string jarg3, string jarg4, bool jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSSLCertificates__SWIG_1")]
		public static extern bool SipStack_setSSLCertificates__SWIG_1(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSSLCretificates__SWIG_0")]
		public static extern bool SipStack_setSSLCretificates__SWIG_0(HandleRef jarg1, string jarg2, string jarg3, string jarg4, bool jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setSSLCretificates__SWIG_1")]
		public static extern bool SipStack_setSSLCretificates__SWIG_1(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setIPSecSecAgree")]
		public static extern bool SipStack_setIPSecSecAgree(HandleRef jarg1, bool jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setIPSecParameters")]
		public static extern bool SipStack_setIPSecParameters(HandleRef jarg1, string jarg2, string jarg3, string jarg4, string jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_dnsENUM")]
		public static extern string SipStack_dnsENUM(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_dnsNaptrSrv")]
		public static extern string SipStack_dnsNaptrSrv(HandleRef jarg1, string jarg2, string jarg3, out ushort jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_dnsSrv")]
		public static extern string SipStack_dnsSrv(HandleRef jarg1, string jarg2, out ushort jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setMaxFDs")]
		public static extern bool SipStack_setMaxFDs(HandleRef jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_getLocalIPnPort")]
		public static extern string SipStack_getLocalIPnPort(HandleRef jarg1, string jarg2, out ushort jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_getPreferredIdentity")]
		public static extern string SipStack_getPreferredIdentity(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_isValid")]
		public static extern bool SipStack_isValid(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_stop")]
		public static extern bool SipStack_stop(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_initialize")]
		public static extern bool SipStack_initialize();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_deInitialize")]
		public static extern bool SipStack_deInitialize();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setCodecs")]
		public static extern void SipStack_setCodecs(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setCodecs_2")]
		public static extern void SipStack_setCodecs_2(long jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setCodecPriority")]
		public static extern bool SipStack_setCodecPriority(int jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_setCodecPriority_2")]
		public static extern bool SipStack_setCodecPriority_2(int jarg1, int jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_isCodecSupported")]
		public static extern bool SipStack_isCodecSupported(int jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_isIPSecSupported")]
		public static extern bool SipStack_isIPSecSupported();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_transport_error_get")]
		public static extern int tsip_event_code_dialog_transport_error_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_global_error_get")]
		public static extern int tsip_event_code_dialog_global_error_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_message_error_get")]
		public static extern int tsip_event_code_dialog_message_error_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_request_incoming_get")]
		public static extern int tsip_event_code_dialog_request_incoming_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_request_outgoing_get")]
		public static extern int tsip_event_code_dialog_request_outgoing_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_request_cancelled_get")]
		public static extern int tsip_event_code_dialog_request_cancelled_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_request_sent_get")]
		public static extern int tsip_event_code_dialog_request_sent_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_connecting_get")]
		public static extern int tsip_event_code_dialog_connecting_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_connected_get")]
		public static extern int tsip_event_code_dialog_connected_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_terminating_get")]
		public static extern int tsip_event_code_dialog_terminating_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_dialog_terminated_get")]
		public static extern int tsip_event_code_dialog_terminated_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_starting_get")]
		public static extern int tsip_event_code_stack_starting_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_started_get")]
		public static extern int tsip_event_code_stack_started_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_stopping_get")]
		public static extern int tsip_event_code_stack_stopping_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_stopped_get")]
		public static extern int tsip_event_code_stack_stopped_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_failed_to_start_get")]
		public static extern int tsip_event_code_stack_failed_to_start_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_failed_to_stop_get")]
		public static extern int tsip_event_code_stack_failed_to_stop_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_tsip_event_code_stack_disconnected_get")]
		public static extern int tsip_event_code_stack_disconnected_get();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_XcapSelector")]
		public static extern IntPtr new_XcapSelector(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_XcapSelector")]
		public static extern void delete_XcapSelector(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_setAUID")]
		public static extern IntPtr XcapSelector_setAUID(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_setName")]
		public static extern IntPtr XcapSelector_setName(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_setAttribute")]
		public static extern IntPtr XcapSelector_setAttribute(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_setPos")]
		public static extern IntPtr XcapSelector_setPos(HandleRef jarg1, string jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_setPosAttribute")]
		public static extern IntPtr XcapSelector_setPosAttribute(HandleRef jarg1, string jarg2, uint jarg3, string jarg4, string jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_setNamespace")]
		public static extern IntPtr XcapSelector_setNamespace(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_getString")]
		public static extern string XcapSelector_getString(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapSelector_reset")]
		public static extern void XcapSelector_reset(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_XcapMessage")]
		public static extern IntPtr new_XcapMessage();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_XcapMessage")]
		public static extern void delete_XcapMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getCode")]
		public static extern short XcapMessage_getCode(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getPhrase")]
		public static extern string XcapMessage_getPhrase(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getXcapHeaderValue__SWIG_0")]
		public static extern string XcapMessage_getXcapHeaderValue__SWIG_0(HandleRef jarg1, string jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getXcapHeaderValue__SWIG_1")]
		public static extern string XcapMessage_getXcapHeaderValue__SWIG_1(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getXcapHeaderParamValue__SWIG_0")]
		public static extern string XcapMessage_getXcapHeaderParamValue__SWIG_0(HandleRef jarg1, string jarg2, string jarg3, uint jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getXcapHeaderParamValue__SWIG_1")]
		public static extern string XcapMessage_getXcapHeaderParamValue__SWIG_1(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getXcapContentLength")]
		public static extern uint XcapMessage_getXcapContentLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapMessage_getXcapContent")]
		public static extern uint XcapMessage_getXcapContent(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_XcapEvent")]
		public static extern void delete_XcapEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapEvent_getType")]
		public static extern int XcapEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapEvent_getXcapMessage")]
		public static extern IntPtr XcapEvent_getXcapMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_XcapCallback")]
		public static extern IntPtr new_XcapCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_XcapCallback")]
		public static extern void delete_XcapCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapCallback_onEvent")]
		public static extern int XcapCallback_onEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapCallback_onEventSwigExplicitXcapCallback")]
		public static extern int XcapCallback_onEventSwigExplicitXcapCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapCallback_director_connect")]
		public static extern void XcapCallback_director_connect(HandleRef jarg1, XcapCallback.SwigDelegateXcapCallback_0 delegate0);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_XcapStack")]
		public static extern IntPtr new_XcapStack(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_XcapStack")]
		public static extern void delete_XcapStack(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_registerAUID")]
		public static extern bool XcapStack_registerAUID(HandleRef jarg1, string jarg2, string jarg3, string jarg4, string jarg5, bool jarg6);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_start")]
		public static extern bool XcapStack_start(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_setCredentials")]
		public static extern bool XcapStack_setCredentials(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_setXcapRoot")]
		public static extern bool XcapStack_setXcapRoot(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_setLocalIP")]
		public static extern bool XcapStack_setLocalIP(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_setLocalPort")]
		public static extern bool XcapStack_setLocalPort(HandleRef jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_addHeader")]
		public static extern bool XcapStack_addHeader(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_removeHeader")]
		public static extern bool XcapStack_removeHeader(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_setTimeout")]
		public static extern bool XcapStack_setTimeout(HandleRef jarg1, uint jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_getDocument")]
		public static extern bool XcapStack_getDocument(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_getElement")]
		public static extern bool XcapStack_getElement(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_getAttribute")]
		public static extern bool XcapStack_getAttribute(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_deleteDocument")]
		public static extern bool XcapStack_deleteDocument(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_deleteElement")]
		public static extern bool XcapStack_deleteElement(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_deleteAttribute")]
		public static extern bool XcapStack_deleteAttribute(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_putDocument")]
		public static extern bool XcapStack_putDocument(HandleRef jarg1, string jarg2, IntPtr jarg3, uint jarg4, string jarg5);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_putElement")]
		public static extern bool XcapStack_putElement(HandleRef jarg1, string jarg2, IntPtr jarg3, uint jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_putAttribute")]
		public static extern bool XcapStack_putAttribute(HandleRef jarg1, string jarg2, IntPtr jarg3, uint jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_XcapStack_stop")]
		public static extern bool XcapStack_stop(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_RPMessage")]
		public static extern IntPtr new_RPMessage();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_RPMessage")]
		public static extern void delete_RPMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RPMessage_getType")]
		public static extern int RPMessage_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RPMessage_getPayloadLength")]
		public static extern uint RPMessage_getPayloadLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RPMessage_getPayload")]
		public static extern uint RPMessage_getPayload(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_SMSData")]
		public static extern IntPtr new_SMSData();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SMSData")]
		public static extern void delete_SMSData(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSData_getType")]
		public static extern int SMSData_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSData_getMR")]
		public static extern int SMSData_getMR(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSData_getPayloadLength")]
		public static extern uint SMSData_getPayloadLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSData_getPayload")]
		public static extern uint SMSData_getPayload(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSData_getOA")]
		public static extern string SMSData_getOA(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSData_getDA")]
		public static extern string SMSData_getDA(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSEncoder_encodeSubmit")]
		public static extern IntPtr SMSEncoder_encodeSubmit(int jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSEncoder_encodeDeliver")]
		public static extern IntPtr SMSEncoder_encodeDeliver(int jarg1, string jarg2, string jarg3, string jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSEncoder_encodeACK")]
		public static extern IntPtr SMSEncoder_encodeACK(int jarg1, string jarg2, string jarg3, bool jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSEncoder_encodeError")]
		public static extern IntPtr SMSEncoder_encodeError(int jarg1, string jarg2, string jarg3, bool jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SMSEncoder_decode")]
		public static extern IntPtr SMSEncoder_decode(IntPtr jarg1, uint jarg2, bool jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_SMSEncoder")]
		public static extern void delete_SMSEncoder(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_MsrpMessage")]
		public static extern IntPtr new_MsrpMessage();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MsrpMessage")]
		public static extern void delete_MsrpMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_isRequest")]
		public static extern bool MsrpMessage_isRequest(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getCode")]
		public static extern short MsrpMessage_getCode(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getPhrase")]
		public static extern string MsrpMessage_getPhrase(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getRequestType")]
		public static extern int MsrpMessage_getRequestType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getByteRange")]
		public static extern void MsrpMessage_getByteRange(HandleRef jarg1, out long jarg2, out long jarg3, out long jarg4);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_isLastChunck")]
		public static extern bool MsrpMessage_isLastChunck(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_isFirstChunck")]
		public static extern bool MsrpMessage_isFirstChunck(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_isSuccessReport")]
		public static extern bool MsrpMessage_isSuccessReport(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getMsrpHeaderValue")]
		public static extern string MsrpMessage_getMsrpHeaderValue(HandleRef jarg1, string jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getMsrpHeaderParamValue")]
		public static extern string MsrpMessage_getMsrpHeaderParamValue(HandleRef jarg1, string jarg2, string jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getMsrpContentLength")]
		public static extern uint MsrpMessage_getMsrpContentLength(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpMessage_getMsrpContent")]
		public static extern uint MsrpMessage_getMsrpContent(HandleRef jarg1, IntPtr jarg2, uint jarg3);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MsrpEvent")]
		public static extern void delete_MsrpEvent(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpEvent_getType")]
		public static extern int MsrpEvent_getType(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpEvent_getSipSession")]
		public static extern IntPtr MsrpEvent_getSipSession(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpEvent_getMessage")]
		public static extern IntPtr MsrpEvent_getMessage(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_new_MsrpCallback")]
		public static extern IntPtr new_MsrpCallback();

		[DllImport("tinyWRAP", EntryPoint = "CSharp_delete_MsrpCallback")]
		public static extern void delete_MsrpCallback(HandleRef jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpCallback_OnEvent")]
		public static extern int MsrpCallback_OnEvent(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpCallback_OnEventSwigExplicitMsrpCallback")]
		public static extern int MsrpCallback_OnEventSwigExplicitMsrpCallback(HandleRef jarg1, HandleRef jarg2);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpCallback_director_connect")]
		public static extern void MsrpCallback_director_connect(HandleRef jarg1, MsrpCallback.SwigDelegateMsrpCallback_0 delegate0);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaContentCPIM_SWIGUpcast")]
		public static extern IntPtr MediaContentCPIM_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_DialogEvent_SWIGUpcast")]
		public static extern IntPtr DialogEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_StackEvent_SWIGUpcast")]
		public static extern IntPtr StackEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteEvent_SWIGUpcast")]
		public static extern IntPtr InviteEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingEvent_SWIGUpcast")]
		public static extern IntPtr MessagingEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoEvent_SWIGUpcast")]
		public static extern IntPtr InfoEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsEvent_SWIGUpcast")]
		public static extern IntPtr OptionsEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationEvent_SWIGUpcast")]
		public static extern IntPtr PublicationEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationEvent_SWIGUpcast")]
		public static extern IntPtr RegistrationEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionEvent_SWIGUpcast")]
		public static extern IntPtr SubscriptionEvent_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InviteSession_SWIGUpcast")]
		public static extern IntPtr InviteSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_CallSession_SWIGUpcast")]
		public static extern IntPtr CallSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MsrpSession_SWIGUpcast")]
		public static extern IntPtr MsrpSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MessagingSession_SWIGUpcast")]
		public static extern IntPtr MessagingSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_InfoSession_SWIGUpcast")]
		public static extern IntPtr InfoSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_OptionsSession_SWIGUpcast")]
		public static extern IntPtr OptionsSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_PublicationSession_SWIGUpcast")]
		public static extern IntPtr PublicationSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_RegistrationSession_SWIGUpcast")]
		public static extern IntPtr RegistrationSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SubscriptionSession_SWIGUpcast")]
		public static extern IntPtr SubscriptionSession_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioConsumer_SWIGUpcast")]
		public static extern IntPtr ProxyAudioConsumer_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoConsumer_SWIGUpcast")]
		public static extern IntPtr ProxyVideoConsumer_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyAudioProducer_SWIGUpcast")]
		public static extern IntPtr ProxyAudioProducer_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_ProxyVideoProducer_SWIGUpcast")]
		public static extern IntPtr ProxyVideoProducer_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_SipStack_SWIGUpcast")]
		public static extern IntPtr SipStack_SWIGUpcast(IntPtr jarg1);

		[DllImport("tinyWRAP", EntryPoint = "CSharp_MediaSessionMgr_codecSetInt32")]
		public static extern bool MediaSessionMgr_codecSetInt32(HandleRef jarg1, int jarg2, string jarg3, long jarg4);
	}
}
