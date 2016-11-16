using System;

namespace DispCore.Services
{
	public interface ILogService : IService
	{
		void Debug(string TAG, object message);

		void Info(string TAG, object message);

		void Warn(string TAG, object message);

		void Error(string TAG, object message);

		void Fatal(string TAG, object message);
	}
}
