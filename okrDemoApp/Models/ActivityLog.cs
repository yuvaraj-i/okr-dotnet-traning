using System;
namespace okrDemoApp.Models
{
	public class ActivityLog
	{
		public Guid id { get; set; }
		public User user { get; set; } = null!;
		public string acctivityAction { get; set; } = null!;
		public string topicType { get; set; } = null!;
		public DateTime date { get; set; }
    }
}

