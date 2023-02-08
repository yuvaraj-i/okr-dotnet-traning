using System;
using okrDemoApp.Models;

namespace okrDemoApp.Services
{
	public interface IDashboardService
	{
        public List<ActivityLog> getAllActivity(int userId);
        public List<ActivityLog> getAllActivity(int page, int userId);

    }
}

