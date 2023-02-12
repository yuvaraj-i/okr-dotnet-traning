using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
    public interface IActivityLogRepository
    {
        List<ActivityLog> GetUserActivityLog(int userId);
        List<ActivityLog> GetUserActivityLogsByLimit(int page, int userId, int skipLimit);
        void AddUserActivityLog(ActivityLog activityLog);
    }
}

