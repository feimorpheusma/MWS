using DispCore.Events;
using DispCore.Models;
using System;

namespace DispCore.Services
{
	public interface IStatusService : IService
	{
		event System.EventHandler<StatusEventArgs> onStatusEvent;

		string defaultIdentity
		{
			get;
			set;
		}

		bool IsContactSubscribed(string uri);

		bool SubscribeTermStatus(Person p);

		bool SubscribeTermStatus(string strUDN);

		bool SubscribeGroupStatus(Group g);

		bool UnSubscribeTermStatus(Person p);

		bool UnSubscribeGroupStatus(Group g);

		bool KillTerm(string termUri);

		bool StunTerm(string termUri);

		bool ReviveTerm(string termUri);

		void DoPostRegistrationOp();
	}
}
