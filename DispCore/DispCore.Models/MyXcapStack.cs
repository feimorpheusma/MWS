using DispCore.Services.Impl;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.Threading;

namespace DispCore.Models
{
	public class MyXcapStack : System.IDisposable
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MyXcapStack));

		private string xui;

		private string password;

		private string xcapRoot;

		private int timeout;

		private readonly XcapStack stack;

		private readonly MySyncXcapCallback synCallback;

		private bool running;

		private Semaphore synchronizer;

		public Semaphore Synchronizer
		{
			get
			{
				return this.synchronizer;
			}
		}

		internal XcapStack Stack
		{
			get
			{
				return this.stack;
			}
		}

		internal bool IsRunning
		{
			get
			{
				return this.running;
			}
		}

		public string XUI
		{
			get
			{
				return this.xui;
			}
		}

		public string Password
		{
			get
			{
				return this.password;
			}
		}

		public string XcapRoot
		{
			get
			{
				return this.xcapRoot;
			}
		}

		public int Timeout
		{
			get
			{
				return this.timeout;
			}
		}

		public MyXcapStack(XcapCallback callback, string xui, string password, string xcapRoot, int timeout)
		{
			this.stack = new XcapStack(callback, xui, password, xcapRoot);
			if (callback is MySyncXcapCallback)
			{
				this.synCallback = (callback as MySyncXcapCallback);
			}
			this.xui = xui;
			this.password = password;
			this.xcapRoot = xcapRoot;
			this.timeout = timeout;
			this.stack.setTimeout((uint)timeout);
			this.synchronizer = new Semaphore(0, 1);
		}

		~MyXcapStack()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			if (this.synchronizer != null)
			{
				this.synchronizer.Close();
				this.synchronizer = null;
			}
			if (this.stack != null)
			{
				this.stack.Dispose();
			}
		}

		public bool Configure(string xui, string password, string xcapRoot, int timeout)
		{
			bool result;
			if (!this.stack.setCredentials(xui, password))
			{
				result = false;
			}
			else
			{
				this.xui = xui;
				this.password = password;
				if (!this.stack.setXcapRoot(xcapRoot))
				{
					result = false;
				}
				else
				{
					this.xcapRoot = xcapRoot;
					if (!this.stack.setTimeout((uint)timeout))
					{
						result = false;
					}
					else
					{
						this.timeout = timeout;
						result = true;
					}
				}
			}
			return result;
		}

		internal bool Start()
		{
			MyXcapStack.LOG.Debug(string.Format("XCAP-ROOT={0}", this.XcapRoot));
			bool result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = false;
			}
			else if (this.stack.start())
			{
				this.running = true;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		internal bool AddHeader(string name, string value)
		{
			bool result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = false;
			}
			else
			{
				result = this.stack.addHeader(name, value);
			}
			return result;
		}

		internal bool RemoveHeader(string name)
		{
			bool result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = false;
			}
			else
			{
				result = this.stack.removeHeader(name);
			}
			return result;
		}

		internal MyXcapMessage GetDocument(string url)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.getDocument(url))
			{
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage GetElement(string url)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.getElement(url))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage GetAttribute(string url)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.getAttribute(url))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage DeleteDocument(string url)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.deleteDocument(url))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage DeleteElement(string url)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.deleteElement(url))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage DeleteAttribute(string url)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.deleteAttribute(url))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage PutDocument(string url, byte[] payload, uint len, string contentType)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.putDocument(url, payload, contentType))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage PutElement(string url, byte[] payload, uint len)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.putElement(url, payload))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal MyXcapMessage PutAttribute(string url, byte[] payload, uint len)
		{
			MyXcapMessage result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = null;
			}
			else if (!this.stack.putAttribute(url, payload))
			{
				MyXcapStack.LOG.Error("Request failed");
				result = null;
			}
			else
			{
				result = this.WaitThenReturnResult();
			}
			return result;
		}

		internal bool Stop()
		{
			bool result;
			if (this.stack == null)
			{
				MyXcapStack.LOG.Error("Invalid Internal XCAP Stack");
				result = false;
			}
			else if (this.stack.stop())
			{
				this.running = false;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		private MyXcapMessage WaitThenReturnResult()
		{
			MyXcapMessage result;
			if (this.synCallback != null)
			{
				if (!this.synCallback.StackService.XCapStack.Synchronizer.WaitOne())
				{
					MyXcapStack.LOG.Error("Failed to synchronize");
					result = null;
				}
				else
				{
					result = this.synCallback.LastMessage;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
