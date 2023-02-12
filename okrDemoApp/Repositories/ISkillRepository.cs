using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public interface ISkillRepository
	{
        public void AddSkill(Skill skills);
        public Skill GetSkill(string skillDescription);
        public void UpdateSkill(Skill skill);
        public Skill GetSkillById(int id);
    }
}

