using DispCore.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DispCore.Utils
{
	public class MyObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
	{
		private readonly bool trackItemsPropChanges;

		public event System.EventHandler<StringEventArgs> onItemPropChanged;

		public MyObservableCollection() : this(false)
		{
		}

		public MyObservableCollection(bool trackItemsPropChanges)
		{
			this.trackItemsPropChanges = trackItemsPropChanges;
		}

		public MyObservableCollection(System.Collections.Generic.IEnumerable<T> collection, bool trackItemsPropChanges) : base(collection)
		{
			this.trackItemsPropChanges = trackItemsPropChanges;
		}

		public void RemoveRange(System.Collections.Generic.IEnumerable<T> collection)
		{
			foreach (T i in collection)
			{
				base.Items.Remove(i);
			}
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void Replace(T item)
		{
			this.ReplaceRange(new T[]
			{
				item
			});
		}

		public void ReplaceRange(System.Collections.Generic.IEnumerable<T> collection)
		{
			base.Items.Clear();
			foreach (T i in collection)
			{
				base.Items.Add(i);
			}
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void AddRange(System.Collections.Generic.IEnumerable<T> collection)
		{
			foreach (T i in collection)
			{
				base.Items.Add(i);
			}
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public System.Collections.Generic.List<T> FindAll(System.Predicate<T> matcher)
		{
			System.Collections.Generic.List<T> items = base.Items as System.Collections.Generic.List<T>;
			return items.FindAll(matcher);
		}

		public int RemoveAll(System.Predicate<T> match)
		{
			System.Collections.Generic.List<T> items = base.Items as System.Collections.Generic.List<T>;
			return items.RemoveAll(match);
		}

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			if (this.trackItemsPropChanges)
			{
				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Add:
				{
					System.Collections.IEnumerator enumerator = e.NewItems.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							T item = (T)((object)enumerator.Current);
							item.PropertyChanged += new PropertyChangedEventHandler(this.item_PropertyChanged);
						}
					}
					finally
					{
						System.IDisposable disposable = enumerator as System.IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					break;
				}
				case NotifyCollectionChangedAction.Remove:
				{
					System.Collections.IEnumerator enumerator = e.OldItems.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							T item = (T)((object)enumerator.Current);
							item.PropertyChanged -= new PropertyChangedEventHandler(this.item_PropertyChanged);
						}
					}
					finally
					{
						System.IDisposable disposable = enumerator as System.IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					break;
				}
				case NotifyCollectionChangedAction.Reset:
					foreach (T item in base.Items)
					{
						item.PropertyChanged += new PropertyChangedEventHandler(this.item_PropertyChanged);
					}
					break;
				}
			}
			base.OnCollectionChanged(e);
		}

		private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			EventHandlerTrigger.TriggerEvent<StringEventArgs>(this.onItemPropChanged, this, new StringEventArgs(e.PropertyName));
		}
	}
}
