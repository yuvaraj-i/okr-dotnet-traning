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

        public void AddSkill(List<Skill> skills)
        {
            _objectiveReposistory.AddSkills(skills);
            
        }
    }
}

