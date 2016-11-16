using DispCore.Events;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DispCore.Models
{
	public class MyMsrpSession : MyInviteSession
	{
		private class MyMsrpCallback : MsrpCallback
		{
			private readonly MyMsrpSession session;

			private byte[] tempBuffer;

			private System.IntPtr tempBufferPtr;

			private System.IO.MemoryStream chatStream;

			private string contentType;

			private string wContentType = null;

			internal MyMsrpCallback(MyMsrpSession session)
			{
				this.session = session;
			}

			public override void Dispose()
			{
				if (this.chatStream != null)
				{
					this.chatStream.Close();
				}
				if (this.tempBufferPtr != System.IntPtr.Zero)
				{
					System.Runtime.InteropServices.Marshal.FreeHGlobal(this.tempBufferPtr);
					this.tempBufferPtr = System.IntPtr.Zero;
				}
			}

			private bool AppenData(byte[] data, uint len)
			{
				bool result;
				try
				{
					if (this.session.MediaType == MediaType.Chat)
					{
						if (this.chatStream == null)
						{
							this.chatStream = new System.IO.MemoryStream();
						}
						this.chatStream.Write(data, 0, (int)len);
					}
					else if (this.session.MediaType == MediaType.FileTransfer)
					{
						if (this.session.mOutFileStream == null)
						{
							MyMsrpSession.LOG.Error("Null FileStream");
							result = false;
							return result;
						}
						lock (this.session.mOutFileStream)
						{
							this.session.mOutFileStream.Write(data, 0, (int)len);
						}
					}
				}
				catch (System.Exception e)
				{
					MyMsrpSession.LOG.Error(e);
					result = false;
					return result;
				}
				result = true;
				return result;
			}

			private void ProcessResponse(MsrpMessage message)
			{
				short code = message.getCode();
				if (code >= 200 && code <= 299)
				{
					if (this.session.MediaType == MediaType.FileTransfer)
					{
						long start = -1L;
						long end = -1L;
						long total = -1L;
						message.getByteRange(out start, out end, out total);
						MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, MsrpEventTypes.SUCCESS_2XX);
						eargs.AddExtra("byte-start", start).AddExtra("byte-end", end).AddExtra("byte-total", total).AddExtra("response-code", code).AddExtra("session", this.session);
						EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
					}
				}
				else if (code >= 300)
				{
					MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, MsrpEventTypes.ERROR);
					eargs.AddExtra("response-code", code).AddExtra("session", this.session);
					EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
				}
			}

			private void ProcessRequest(MsrpMessage message)
			{
				switch (message.getRequestType())
				{
				case tmsrp_request_type_t.tmsrp_SEND:
				{
					uint clen = message.getMsrpContentLength();
					if (clen == 0u)
					{
						MyMsrpSession.LOG.Info("Empty MSRP message");
					}
					else
					{
						if (this.tempBuffer == null || this.tempBufferPtr == System.IntPtr.Zero || (long)this.tempBuffer.Length < (long)((ulong)clen))
						{
							this.tempBuffer = new byte[clen];
							if (this.tempBufferPtr != System.IntPtr.Zero)
							{
								System.Runtime.InteropServices.Marshal.FreeHGlobal(this.tempBufferPtr);
							}
							this.tempBufferPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal((int)clen);
						}
						uint read = message.getMsrpContent(this.tempBufferPtr, (uint)this.tempBuffer.Length);
						System.Runtime.InteropServices.Marshal.Copy(this.tempBufferPtr, this.tempBuffer, 0, this.tempBuffer.Length);
						if (message.isFirstChunck())
						{
							this.contentType = message.getMsrpHeaderValue("Content-Type");
							if (!string.IsNullOrEmpty(this.contentType) && this.contentType.StartsWith("Message/CPIM", System.StringComparison.InvariantCultureIgnoreCase))
							{
								MediaContentCPIM mediaContent = MediaContent.parse(this.tempBufferPtr, read);
								System.Runtime.InteropServices.Marshal.Copy(this.tempBufferPtr, this.tempBuffer, 0, this.tempBuffer.Length);
								if (mediaContent != null)
								{
									this.wContentType = mediaContent.getHeaderValue("Content-Type");
									this.tempBuffer = mediaContent.getPayload();
									read = (uint)this.tempBuffer.Length;
									mediaContent.Dispose();
								}
							}
						}
						this.AppenData(this.tempBuffer, read);
						if (this.session.MediaType == MediaType.FileTransfer)
						{
							long start = -1L;
							long end = -1L;
							long total = -1L;
							message.getByteRange(out start, out end, out total);
							MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, MsrpEventTypes.DATA);
							eargs.AddExtra("byte-start", start).AddExtra("byte-end", end).AddExtra("byte-total", total).AddExtra("request-type", "SEND").AddExtra("session", this.session);
							EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
						}
						if (message.isLastChunck())
						{
							if (this.session.MediaType == MediaType.Chat && this.chatStream != null)
							{
								MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, MsrpEventTypes.DATA);
								eargs.AddExtra("content-type", this.contentType).AddExtra("w-content-type", this.wContentType).AddExtra("data", this.chatStream.ToArray()).AddExtra("session", this.session);
								EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
								this.chatStream.SetLength(0L);
							}
							else if (this.session.MediaType == MediaType.FileTransfer)
							{
								if (this.session.mOutFileStream != null)
								{
									lock (this.session.mOutFileStream)
									{
										this.session.mOutFileStream.Close();
										this.session.mOutFileStream = null;
									}
								}
							}
						}
					}
					break;
				}
				case tmsrp_request_type_t.tmsrp_REPORT:
					if (this.session.MediaType == MediaType.FileTransfer)
					{
						long start = -1L;
						long end = -1L;
						long total = -1L;
						message.getByteRange(out start, out end, out total);
						bool isSuccessReport = message.isSuccessReport();
						MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, isSuccessReport ? MsrpEventTypes.SUCCESS_REPORT : MsrpEventTypes.FAILURE_REPORT);
						eargs.AddExtra("byte-start", start).AddExtra("byte-end", end).AddExtra("byte-total", total).AddExtra("session", this.session);
						EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
					}
					break;
				}
			}

			public override int OnEvent(MsrpEvent e)
			{
				tmsrp_event_type_t type = e.getType();
				SipSession session = e.getSipSession();
				int result;
				if (session == null || (ulong)session.getId() != (ulong)this.session.Id)
				{
					MyMsrpSession.LOG.Error("Invalid session");
					result = -1;
				}
				else
				{
					switch (type)
					{
					case tmsrp_event_type_t.tmsrp_event_type_connected:
					{
						MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, MsrpEventTypes.CONNECTED);
						eargs.AddExtra("session", this.session);
						EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
						if (this.session.mPendingMessages != null && this.session.mPendingMessages.Count > 0)
						{
							if (this.session.IsConnected)
							{
								foreach (MyMsrpSession.PendingMessage pendingMsg in this.session.mPendingMessages)
								{
									MyMsrpSession.LOG.Info("Sending pending message...");
									this.session.SendMessage(pendingMsg.Message, pendingMsg.ContentType, pendingMsg.WContentType);
								}
								this.session.mPendingMessages.Clear();
							}
							else
							{
								MyMsrpSession.LOG.Warn("There are pending messages but we are not connected");
							}
						}
						break;
					}
					case tmsrp_event_type_t.tmsrp_event_type_disconnected:
					{
						if (this.session.mOutFileStream != null)
						{
							lock (this.session.mOutFileStream)
							{
								if (this.session.mOutFileStream != null)
								{
									this.session.mOutFileStream.Close();
									this.session.mOutFileStream = null;
								}
							}
						}
						MsrpEventArgs eargs = new MsrpEventArgs(this.session.Id, MsrpEventTypes.DISCONNECTED);
						eargs.AddExtra("session", this.session);
						EventHandlerTrigger.TriggerEvent<MsrpEventArgs>(this.session.mOnMsrpEvent, this.session, eargs);
						break;
					}
					case tmsrp_event_type_t.tmsrp_event_type_message:
					{
						MsrpMessage message = e.getMessage();
						if (message == null)
						{
							MyMsrpSession.LOG.Error("Invalid MSRP content");
							result = -1;
							return result;
						}
						if (message.isRequest())
						{
							this.ProcessRequest(message);
						}
						else
						{
							this.ProcessResponse(message);
						}
						break;
					}
					}
					result = 0;
				}
				return result;
			}
		}

		private class PendingMessage
		{
			private readonly string message;

			private readonly string contentType;

			private readonly string wContentType;

			internal string Message
			{
				get
				{
					return this.message;
				}
			}

			internal string ContentType
			{
				get
				{
					return this.contentType;
				}
			}

			internal string WContentType
			{
				get
				{
					return this.wContentType;
				}
			}

			internal PendingMessage(string message, string contentType, string wContentType)
			{
				this.message = message;
				this.contentType = contentType;
				this.wContentType = wContentType;
			}
		}

		private const string DESTINATION_FOLDER = "Doubango\\SharedContent";

		private const string CHAT_ACCEPT_TYPES = "text/plain message/CPIM";

		private const string CHAT_ACCEPT_WRAPPED_TYPES = "text/plain image/jpeg image/gif image/bmp image/png";

		private const string FILE_ACCEPT_TYPES = "message/CPIM application/octet-stream";

		private const string FILE_ACCEPT_WRAPPED_TYPES = "application/octet-stream image/jpeg image/gif image/bmp image/png";

		private const int CHUNK_DURATION = 25;

		private static readonly ILog LOG = LogManager.GetLogger(typeof(MyMsrpSession));

		private readonly MsrpSession mSession;

		private readonly MyMsrpSession.MyMsrpCallback mCallback;

		private System.Collections.Generic.List<MyMsrpSession.PendingMessage> mPendingMessages = null;

		private string mFilePath;

		private string mFileType;

		private System.IO.FileStream mOutFileStream;

		private bool mFailureReport = true;

		private bool mSuccessReport;

		private bool mOmaFinalDeliveryReport;

		private static System.Collections.Generic.IDictionary<long, MyMsrpSession> sSessions = new System.Collections.Generic.Dictionary<long, MyMsrpSession>();

		public event System.EventHandler<MsrpEventArgs> mOnMsrpEvent;

		protected override SipSession Session
		{
			get
			{
				return this.mSession;
			}
		}

		public string FilePath
		{
			get
			{
				return this.mFilePath;
			}
		}

		public bool FailureReport
		{
			get
			{
				return this.mFailureReport;
			}
			set
			{
				this.mFailureReport = value;
			}
		}

		public bool SuccessReport
		{
			get
			{
				return this.mSuccessReport;
			}
			set
			{
				this.mSuccessReport = value;
			}
		}

		public bool OmaFinalDeliveryReport
		{
			get
			{
				return this.mOmaFinalDeliveryReport;
			}
			set
			{
				this.mOmaFinalDeliveryReport = value;
			}
		}

		public static MyMsrpSession TakeIncomingSession(MySipStack sipStack, MsrpSession session, SipMessage message)
		{
			SdpMessage sdp = message.getSdpMessage();
			string fromUri = message.getSipHeaderValue("f");
			MyMsrpSession result;
			if (string.IsNullOrEmpty(fromUri))
			{
				MyMsrpSession.LOG.Error("Invalid fromUri");
				result = null;
			}
			else if (sdp == null)
			{
				MyMsrpSession.LOG.Error("Invalid Sdp content");
				result = null;
			}
			else
			{
				string fileSelector = sdp.getSdpHeaderAValue("message", "file-selector");
				MediaType mediaType = string.IsNullOrEmpty(fileSelector) ? MediaType.Chat : MediaType.FileTransfer;
				MyMsrpSession msrpSession;
				if (mediaType == MediaType.Chat)
				{
					msrpSession = MyMsrpSession.CreateIncomingSession(sipStack, session, mediaType, fromUri);
				}
				else
				{
					string type = null;
					int nameIndexStart = fileSelector.IndexOf("name:\"");
					if (nameIndexStart == -1)
					{
						MyMsrpSession.LOG.Error("No name attribute");
						result = null;
						return result;
					}
					int nameIndexEnd = fileSelector.IndexOf("\"", nameIndexStart + 6);
					if (nameIndexEnd == -1)
					{
						MyMsrpSession.LOG.Error("Invalid name attribute");
						result = null;
						return result;
					}
					string name = fileSelector.Substring(nameIndexStart + 6, nameIndexEnd - nameIndexStart - 6).Trim();
					fileSelector = fileSelector.Substring(0, nameIndexStart) + fileSelector.Substring(nameIndexEnd + 1, fileSelector.Length - nameIndexEnd - 1);
					string[] attributes = fileSelector.Split(" ".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
					string[] array = attributes;
					for (int i = 0; i < array.Length; i++)
					{
						string attribute = array[i];
						string[] avp = attribute.Split(":".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
						if (avp.Length >= 2)
						{
							if (string.Equals(avp[0], "type", System.StringComparison.InvariantCultureIgnoreCase) && avp[1] != null)
							{
								type = avp[1];
							}
						}
					}
					msrpSession = MyMsrpSession.CreateIncomingSession(sipStack, session, mediaType, fromUri);
					msrpSession.mFilePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), string.Format("{0}/{1}", "Doubango\\SharedContent", name));
					msrpSession.mFileType = type;
				}
				result = msrpSession;
			}
			return result;
		}

		public static MyMsrpSession CreateIncomingSession(MySipStack sipStack, MsrpSession session, MediaType mediaType, string remoteUri)
		{
			MyMsrpSession result;
			if (mediaType == MediaType.FileTransfer || mediaType == MediaType.Chat)
			{
				MyMsrpSession msrpSession = new MyMsrpSession(sipStack, session, mediaType, remoteUri);
				MyMsrpSession.sSessions.Add(msrpSession.Id, msrpSession);
				result = msrpSession;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static MyMsrpSession CreateOutgoingSession(MySipStack sipStack, MediaType mediaType, string remoteUri)
		{
			MyMsrpSession result;
			if (mediaType == MediaType.FileTransfer || mediaType == MediaType.Chat)
			{
				MyMsrpSession msrpSession = new MyMsrpSession(sipStack, null, mediaType, remoteUri);
				MyMsrpSession.sSessions.Add(msrpSession.Id, msrpSession);
				result = msrpSession;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static void ReleaseSession(MyMsrpSession session)
		{
			if (session != null)
			{
				lock (MyMsrpSession.sSessions)
				{
					long id = session.Id;
					session.Dispose();
					MyMsrpSession.sSessions.Remove(id);
				}
			}
		}

		public static MyMsrpSession GetSession(long id)
		{
			MyMsrpSession result;
			lock (MyMsrpSession.sSessions)
			{
				if (MyMsrpSession.sSessions.ContainsKey(id))
				{
					result = MyMsrpSession.sSessions[id];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		public static bool HasSession(long id)
		{
			bool result;
			lock (MyMsrpSession.sSessions)
			{
				result = MyMsrpSession.sSessions.ContainsKey(id);
			}
			return result;
		}

		public MyMsrpSession(MySipStack sipStack, MsrpSession session, MediaType mediaType, string remoteUri) : base(sipStack)
		{
			this.mCallback = new MyMsrpSession.MyMsrpCallback(this);
			this.mMediaType = mediaType;
			this.remotePartyUri = remoteUri;
			if (session == null)
			{
				this.outgoing = true;
				this.mSession = new MsrpSession(sipStack.WrappedStack, this.mCallback);
			}
			else
			{
				this.outgoing = false;
				this.mSession = session;
				this.mSession.setCallback(this.mCallback);
			}
			base.init();
			base.SigCompId = sipStack.SigCompId;
			this.mSession.addHeader("Subject", "FIXME");
		}

		public new void Dispose()
		{
			if (this.mOutFileStream != null)
			{
				this.mOutFileStream.Close();
			}
			base.Dispose();
		}

		public bool Accept()
		{
			bool result;
			if (base.State == InviteState.INCOMING && base.MediaType == MediaType.FileTransfer)
			{
				try
				{
					System.IO.FileInfo fInfo = new System.IO.FileInfo(this.FilePath);
					if (!System.IO.Directory.Exists(fInfo.DirectoryName))
					{
						System.IO.Directory.CreateDirectory(fInfo.DirectoryName);
					}
					if (this.mOutFileStream != null)
					{
						lock (this.mOutFileStream)
						{
							this.mOutFileStream.Close();
							this.mOutFileStream = null;
						}
					}
					this.mOutFileStream = System.IO.File.Create(this.FilePath);
				}
				catch (System.IO.IOException ioE)
				{
					MyMsrpSession.LOG.Error(ioE);
					result = this.HangUp();
					return result;
				}
			}
			result = this.mSession.accept(null);
			return result;
		}

		public bool HangUp()
		{
			bool result;
			if (this.connected)
			{
				if (this.mOutFileStream != null)
				{
					lock (this.mOutFileStream)
					{
						this.mOutFileStream.Close();
						this.mOutFileStream = null;
					}
				}
				result = this.mSession.hangup(null);
			}
			else
			{
				result = this.mSession.reject(null);
			}
			return result;
		}

		public bool SendFile(string path)
		{
			bool result;
			if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
			{
				MyMsrpSession.LOG.Error(string.Format("File ({0}) doesn't exist", path));
				result = false;
			}
			else if (this.mMediaType != MediaType.FileTransfer)
			{
				MyMsrpSession.LOG.Error("Invalid media type");
				result = false;
			}
			else
			{
				System.IO.FileInfo finfo = new System.IO.FileInfo(path);
				this.mFilePath = (this.mFilePath = finfo.FullName);
				this.mFileType = this.GetFileType(finfo.Extension);
				string fileSelector = string.Format("name:\"{0}\" type:{1} size:{2}", finfo.Name, this.mFileType, finfo.Length);
				ActionConfig config = new ActionConfig();
				config.setMediaString(twrap_media_type_t.twrap_media_msrp, "file-path", this.mFilePath).setMediaString(twrap_media_type_t.twrap_media_msrp, "file-selector", fileSelector).setMediaString(twrap_media_type_t.twrap_media_msrp, "accept-types", "message/CPIM application/octet-stream").setMediaString(twrap_media_type_t.twrap_media_msrp, "accept-wrapped-types", "application/octet-stream image/jpeg image/gif image/bmp image/png").setMediaString(twrap_media_type_t.twrap_media_msrp, "file-disposition", "attachment").setMediaString(twrap_media_type_t.twrap_media_msrp, "file-icon", "cid:icon@cetc7").setMediaString(twrap_media_type_t.twrap_media_msrp, "Failure-Report", this.FailureReport ? "yes" : "no").setMediaString(twrap_media_type_t.twrap_media_msrp, "Success-Report", this.SuccessReport ? "yes" : "no").setMediaInt(twrap_media_type_t.twrap_media_msrp, "chunck-duration", 25);
				bool ret = this.mSession.callMsrp(base.RemotePartyUri, config);
				config.Dispose();
				result = ret;
			}
			return result;
		}

		public bool SendMessage(string message)
		{
			return this.SendMessage(message, null, null);
		}

		public bool SendMessage(string message, string contentType, string wContentType)
		{
			bool result;
			if (string.IsNullOrEmpty(message))
			{
				MyMsrpSession.LOG.Error("Null or empty message");
				result = false;
			}
			else if (this.mMediaType != MediaType.Chat)
			{
				MyMsrpSession.LOG.Error("Invalid media type");
				result = false;
			}
			else if (base.IsConnected)
			{
				ActionConfig config = new ActionConfig();
				if (!string.IsNullOrEmpty(contentType))
				{
					config.setMediaString(twrap_media_type_t.twrap_media_msrp, "content-type", "text/plain");
				}
				if (!string.IsNullOrEmpty(wContentType))
				{
					config.setMediaString(twrap_media_type_t.twrap_media_msrp, "w-content-type", wContentType);
				}
				byte[] payload = System.Text.Encoding.UTF8.GetBytes(message);
				System.IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(payload.Length);
				System.Runtime.InteropServices.Marshal.Copy(payload, 0, ptr, payload.Length);
				bool ret = this.mSession.sendMessage(ptr, (uint)payload.Length, config);
				System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
				config.Dispose();
				result = ret;
			}
			else
			{
				if (this.mPendingMessages == null)
				{
					this.mPendingMessages = new System.Collections.Generic.List<MyMsrpSession.PendingMessage>();
				}
				this.mPendingMessages.Add(new MyMsrpSession.PendingMessage(message, contentType, wContentType));
				ActionConfig config = new ActionConfig();
				config.setMediaString(twrap_media_type_t.twrap_media_msrp, "accept-types", "text/plain message/CPIM").setMediaString(twrap_media_type_t.twrap_media_msrp, "accept-wrapped-types", "text/plain image/jpeg image/gif image/bmp image/png").setMediaString(twrap_media_type_t.twrap_media_msrp, "Failure-Report", this.FailureReport ? "yes" : "no").setMediaString(twrap_media_type_t.twrap_media_msrp, "Success-Report", this.SuccessReport ? "yes" : "no").setMediaInt(twrap_media_type_t.twrap_media_msrp, "chunck-duration", 50);
				bool ret = this.mSession.callMsrp(base.RemotePartyUri, config);
				config.Dispose();
				result = ret;
			}
			return result;
		}

		private string GetFileType(string extension)
		{
			string type = "application/octet-stream";
			if (extension.Equals("jpe") || extension.Equals("jpeg") || extension.Equals("jpg"))
			{
				type = "image/jpeg";
			}
			else if (extension.Equals("gif") || extension.Equals("png") || extension.Equals("bmp"))
			{
				type = string.Format("image/{0}", extension);
			}
			return type;
		}
	}
}
