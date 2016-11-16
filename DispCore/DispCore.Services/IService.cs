using System;

namespace DispCore.Services
{
	public interface IService
	{
		bool Start();

		bool Stop();
	}
}
