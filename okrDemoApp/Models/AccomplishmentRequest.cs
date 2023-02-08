using System;

namespace okrDemoApp.Models
{
	public class AccomplishmentRequest
	{
        public string accomplishmentTitle { get; set; }
        public string accomplishmentDescription { get; set; }
        public DateTime accomplishedDate { get; set; }
	}

    public class EditAccomplishmentRequest
    {
        public Guid accomplishmentId { get; set; }
        public string accomplishmentTitle { get; set; }
        public string accomplishmentDescription { get; set; }
        public DateTime accomplishedDate { get; set; }
    }
}

