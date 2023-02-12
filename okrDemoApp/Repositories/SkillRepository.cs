using System;
using okrDemoApp.DBContex;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContex _appDbContext;

        public SkillRepository(AppDbContex appDbContext)
		{
            _appDbContext = appDbContext;
		}

        public void AddSkill(Skill skills)
        {
            _appDbContext.skills.Add(skills);
            _appDbContext.SaveChanges();
        }

        public Skill GetSkill(string skillDescription)
        {
            try
            {

                return _appDbContext.skills.Where(s => s.skillDescription == skillDescription).FirstOrDefault();
            }

            catch
            {
                throw;
            }
        }

        public Skill GetSkillById(int id)
        {
            try
            {
                return _appDbContext.skills.Find(id);
            }

            catch
            {
                throw;
            }
        }

        public void UpdateSkill(Skill skill)
        {
            try
            {
                _appDbContext.skills.Update(skill);
                _appDbContext.SaveChanges();
            }

            catch
            {
                throw;
            }
        }
    }
}

