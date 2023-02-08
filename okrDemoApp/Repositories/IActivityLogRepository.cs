using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
    public interface IActivityLogRepository
    {
        List<ActivityLog> getUserActivityLog(int userId);
        List<ActivityLog> getUserActivityLogsByLimit(int page, int userId, int skipLimit);
        void addUserActivityLog(ActivityLog activityLog);
    }
}

