using System;
using okrDemoApp.DBContex;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public class ActivityLogRepository : IActivityLogRepository
	{
        private readonly AppDbContex _DbContext;
        private readonly int LIMIT = 10;

        public ActivityLogRepository(AppDbContex DbContext)
		{
            _DbContext = DbContext;
        }

        public void addUserActivityLog(ActivityLog activityLog)
        {
            _DbContext.activityLogs.Add(activityLog);
            _DbContext.SaveChanges();
        }

        public List<ActivityLog> getUserActivityLog(int userId)
        {
            try
            {
                return _DbContext.activityLogs.Where(s => s.user.id == userId).ToList();
            }

            catch
            {
                throw;
            }
        }

        public List<ActivityLog> getUserActivityLogsByLimit(int page, int userId, int skipLimit)
        {
            try
            {
                return _DbContext.activityLogs.Where(s => s.user.id == userId).OrderByDescending(s => s.date).Skip(skipLimit).Take(LIMIT).ToList();
            }

            catch
            {
                throw;
            }
        }
    }
}

