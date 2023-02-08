using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public interface ISkillRepository
	{
        public void addSkill(Skill skills);
        public Skill getSkill(string skillDescription);
        public void updateSkill(Skill skill);
        public Skill getSkillById(int id);
    }
}

