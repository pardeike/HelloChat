using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;

namespace HelloChat
{
	public static class Database
	{
		public static ObservableCollection<ChatGroup> Chats;
		public static readonly ChatGroup DummyChat = new() { GroupName = "Some cool Test-Group", UnreadCount = 88, LatestMessageText = "Hello everyone, this is my first message. Have fun!", LatestMessageDate = DateTime.Now };

		static Database()
		{
			Chats = new();
			Chats.Add(new ChatGroup());

			var thread = new Thread(Adder);
			thread.Start();
		}

		static void Adder()
		{
			while (true)
			{
				_ = Application.Current.Dispatcher.BeginInvoke(new Action<ChatGroup>(gr => Chats.Add(gr)), new ChatGroup());
				Thread.Sleep(500);
			}
		}
	}

	/*
	public class Chats : List<ChatGroup>, INotifyPropertyChanged, INotifyCollectionChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public Chats()
		{
		}

		public void NotifyPropertyChanged(string propName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}

		public void AddAndNotify(ChatGroup element)
		{
			Add(element);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
		}

		public void RemoveAndNotify(ChatGroup element)
		{
			_ = Remove(element);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
		}
	}
	*/
}
