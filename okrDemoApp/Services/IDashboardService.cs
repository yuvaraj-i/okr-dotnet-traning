using System;
using okrDemoApp.Models;

namespace okrDemoApp.Services
{
	public interface IDashboardService
	{
        public List<ActivityLog> GetAllActivity(int userId);
        public List<ActivityLog> GetAllActivity(int page, int userId);

    }
}

