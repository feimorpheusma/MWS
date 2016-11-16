using DispCore.Models;
using DispCore.Models.History;
using System;
using System.Collections.ObjectModel;

namespace DispCore.Services
{
	public interface IHistoryService : IService
	{
		ObservableCollection<AVCallHistory> AvHistories
		{
			get;
		}

		ObservableCollection<MyMessageSession> ModelOfMessageList
		{
			get;
		}

		void AddEvent(HistoryItem @event);

		void UpdateEvent(HistoryItem @event);

		void DeleteEvent(HistoryItem @event);

		void DeleteEvent(int location);

		void Clear();
	}
}
