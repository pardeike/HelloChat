using System;

namespace HelloChat
{
	public class ChatGroup
	{
		private static readonly Random random = new();

		public string GroupName { get; set; }
		public string LatestMessageText { get; set; }
		public DateTime LatestMessageDate { get; set; }
		public int UnreadCount { get; set; }

		public bool HasUnread => UnreadCount > 0;

		public ChatGroup()
		{
			GroupName = random.Next(0, 1) == 0 ? Faker.Address.UkCounty() : Faker.Name.First() + " " + Faker.Internet.DomainWord();
			LatestMessageText = Faker.Lorem.Sentence();
			LatestMessageDate = Next(new DateTime(2021, 1, 1), DateTime.Now);
			UnreadCount = random.Next(0, 20);
		}

		public static DateTime Next(DateTime start, DateTime? end = null)
		{
			end ??= new DateTime();
			var range = (end.Value - start).Days;
			return start.AddDays(random.Next(range));
		}
	}
}
