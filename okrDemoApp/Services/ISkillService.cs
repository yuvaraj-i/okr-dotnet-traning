using System;
using okrDemoApp.Models;

namespace okrDemoApp.Services
{
	public interface ISkillService
	{
        public void AddSkill(List<SkillRequestModel> skills, int userId);
        public List<Skill> GetUserSkills(int userId);
        public void EditUserSkill(EditSkillRequestModel editSkillRequestModel, int userId);
        void DeleteUserSkill(int skillId, int userId);
        void AddUserPoc(AccomplishmentRequest accomplishmentRequest, int userId);
        void EditUserPoc(EditAccomplishmentRequest accomplishmentRequest, int userId);
        void DeleteUserPoc(Guid id, int userId);
        List<AccomplishmentModel> GetUserPoc(int userId);
    }
}

