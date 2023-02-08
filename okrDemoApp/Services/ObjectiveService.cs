using System;
using okrDemoApp.Models;
using okrDemoApp.Repositories;

namespace okrDemoApp.Services
{
	public class ObjectiveService : IObjectiveService
    {
        private readonly IObjectiveReposistory _objectiveReposistory;

        public ObjectiveService(IObjectiveReposistory objectiveReposistory)
		{
            _objectiveReposistory = objectiveReposistory;

        }

        public void addSkill(List<Skill> skills)
        {
            _objectiveReposistory.addSkills(skills);
            
        }
    }
}

