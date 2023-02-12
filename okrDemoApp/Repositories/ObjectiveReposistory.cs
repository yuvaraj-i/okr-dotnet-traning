using System;
using okrDemoApp.DBContex;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
    public class ObjectiveReposistory : IObjectiveReposistory
    {
        private readonly AppDbContex _appDbContext;

        public ObjectiveReposistory(AppDbContex appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public void AddSkills(List<Skill> skills)
        {
            //_appDbContext.
        }
    }
}

