using System;
using okrDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace okrDemoApp.Repositories
{
	public interface ISkillSetMappingRepository
	{
        public void AddSkillSet(SkillSetMapping skillSet);
        public List<Skill> GetSkillByUserId(int userId);
        public Skill GetUserSkillBySkill(int userId, int skillId);
        public SkillSetMapping GetSkillById(int skillSetId);
        public SkillSetMapping GetSkillSetById(int skillSetId, int userId);
        void UpdateSkillSet(SkillSetMapping skillSet);
    }
}

