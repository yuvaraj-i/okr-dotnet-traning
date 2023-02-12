using System;
using okrDemoApp.DBContex;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public class SkillSetMappingRepository : ISkillSetMappingRepository
    {
        private readonly AppDbContex _DbContext;

        public SkillSetMappingRepository(AppDbContex appDbContex)
		{
			_DbContext = appDbContex;

        }

		public void AddSkillSet(SkillSetMapping skillSet)
		{
			_DbContext.skillSetMappings.Add(skillSet);
			_DbContext.SaveChanges();
		}

        public SkillSetMapping GetSkillById(int skillSetId)
        {
            try
            {
                return _DbContext.skillSetMappings.Find(skillSetId);
            }

            catch
            {
                throw;
            }
        }

        public List<Skill> GetSkillByUserId(int userId)
        {
            try
            {
                var userSkill = _DbContext.skillSetMappings.Where(s => s.User.id == userId).Select(s => s.Skill).ToList();

                return userSkill;
            }
            catch
            {
                throw;
            }
        }

        public SkillSetMapping GetSkillSetById(int userId , int skillSetId)
        {
            try
            {
                var userSkillSet = _DbContext.skillSetMappings.Where(s => s.User.id == userId && s.Id == skillSetId).FirstOrDefault();

                return userSkillSet;
            }

            catch
            {
                throw;
            }

        }

        public Skill GetUserSkillBySkill(int userId, int skillId)
        {
            try
            {
                var userSkill = _DbContext.skillSetMappings.Where(s => s.User.id == userId && s.Id == skillId).Select(s => s.Skill).FirstOrDefault();

                return userSkill;
            }

            catch
            {
                throw;
            }

        }

        public void UpdateSkillSet(SkillSetMapping skillSet)
        {
            try
            {
                _DbContext.skillSetMappings.Update(skillSet);
                _DbContext.SaveChanges();
            }

            catch
            {
                throw;
            }
        }
    }
}

