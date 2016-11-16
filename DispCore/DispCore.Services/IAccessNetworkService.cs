using DispCore.Events;
using DispCore.Models;
using System;

namespace DispCore.Services
{
	public interface IAccessNetworkService : IService
	{
		event System.EventHandler<AccessNetworkEventArgs> onAccessNetworkEvent;

		MyRegistrationSession RegSession
		{
			get;
		}

		bool IsRegistered
		{
			get;
		}

		bool Register();

		bool Unregister();
	}
}
