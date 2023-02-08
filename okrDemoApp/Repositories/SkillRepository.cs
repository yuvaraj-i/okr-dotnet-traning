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

        public void addSkill(Skill skills)
        {
            _appDbContext.skills.Add(skills);
            _appDbContext.SaveChanges();
        }

        public Skill getSkill(string skillDescription)
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

        public Skill getSkillById(int id)
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

        public void updateSkill(Skill skill)
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

