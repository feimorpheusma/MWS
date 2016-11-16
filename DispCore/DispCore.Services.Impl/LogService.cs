using log4net;
using System;

namespace DispCore.Services.Impl
{
	public class LogService : ILogService, IService
	{
		private ILog log;

		public bool Start()
		{
			this.log = LogManager.GetLogger(typeof(LogService));
			return this.log != null;
		}

		public bool Stop()
		{
			return true;
		}

		public void Debug(string TAG, object message)
		{
			if (this.log != null)
			{
				this.log.Debug(string.Format("{0}: {1}", TAG, message));
			}
		}

		public void Info(string TAG, object message)
		{
			if (this.log != null)
			{
				this.log.Info(string.Format("{0}: {1}", TAG, message));
			}
		}

		public void Warn(string TAG, object message)
		{
			if (this.log != null)
			{
				this.log.Warn(string.Format("{0}: {1}", TAG, message));
			}
		}

		public void Error(string TAG, object message)
		{
			if (this.log != null)
			{
				this.log.Error(string.Format("{0}: {1}", TAG, message));
			}
		}

		public void Fatal(string TAG, object message)
		{
			if (this.log != null)
			{
				this.log.Fatal(string.Format("{0}: {1}", TAG, message));
			}
		}
	}
}
