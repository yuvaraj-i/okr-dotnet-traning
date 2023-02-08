using System;
using okrDemoApp.DBContex;

namespace okrDemoApp.Repositories
{
    public class DashboardReposistory : IDashboardReposistory
    {
        private readonly AppDbContex _DbContext;

        public DashboardReposistory(AppDbContex okr_DbContext)
        {
            _DbContext = okr_DbContext;

        }
    }
}

