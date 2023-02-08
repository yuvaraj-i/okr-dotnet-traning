using System;
using okrDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace okrDemoApp.Repositories
{
	public interface ISkillSetMappingRepository
	{
        public void addSkillSet(SkillSetMapping skillSet);
        public List<Skill> getSkillByUserId(int userId);
        public Skill getUserSkillBySkill(int userId, int skillId);
        public SkillSetMapping getSkillById(int skillSetId);
        public SkillSetMapping getSkillSetById(int skillSetId, int userId);
        void updateSkillSet(SkillSetMapping skillSet);
    }
}

