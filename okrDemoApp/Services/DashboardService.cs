using System;
using okrDemoApp.Models;
using okrDemoApp.Repositories;

namespace okrDemoApp.Services
{
	public class DashboardService : IDashboardService
    {
        private readonly int LIMIT = 10;
        private readonly IDashboardReposistory _dashboardReposistory;
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly ILogger<DashboardService> _logger;

        public DashboardService(IDashboardReposistory dashboardReposistory, IActivityLogRepository activityLogRepository, ILogger<DashboardService> logger)
		{
            _dashboardReposistory = dashboardReposistory;
            _activityLogRepository = activityLogRepository;
            _logger = logger;
        }

        public List<ActivityLog> getAllActivity(int page, int userId)
        {
            _logger.LogInformation("DashboardService getAllActivity");

            try
            {
                int skip = (page - 1) * LIMIT;

                List<ActivityLog> activityList = _activityLogRepository.getUserActivityLogsByLimit(page, userId, skip);

                return activityList;
            }

            catch
            {
                throw;
            }
        }

        public List<ActivityLog> getAllActivity(int userId)
        {
            _logger.LogInformation("DashboardService getAllActivity");

            try
            {
                return _activityLogRepository.getUserActivityLog(userId);
            }

            catch
            {
                throw;
            }
        }

    }
}

