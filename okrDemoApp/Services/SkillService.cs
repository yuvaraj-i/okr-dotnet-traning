using System;
using okrDemoApp.Models;
using okrDemoApp.Repositories;

namespace okrDemoApp.Services
{
	public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillSetMappingRepository _skillSetMappingRepository;
        private readonly IAccomplishmentRepository _accomplishmentRepository;
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly ILogger<SkillService> _logger;

        public SkillService(ISkillRepository skillRepository, IUserRepository userRepository, ISkillSetMappingRepository skillsetMappingRepository, IAccomplishmentRepository accomplishmentRepository, IActivityLogRepository activityLogRepository, ILogger<SkillService> logger)
		{
            _skillRepository = skillRepository;
            _userRepository = userRepository;
            _skillSetMappingRepository = skillsetMappingRepository;
            _accomplishmentRepository = accomplishmentRepository;
            _activityLogRepository = activityLogRepository;
            _logger = logger;
        }

        public void addSkill(List<SkillRequestModel> skills, int userId)
        {
            _logger.LogInformation("SkillService addSkill");

            try
            {
                foreach (SkillRequestModel s in skills)
                {
                    var currentSkill = _skillRepository.getSkill(s.skillDescription);
                    var userSkill = new Skill();
                    userSkill.skillDescription = s.skillDescription;

                    if (currentSkill == null)
                    {
                        _skillRepository.addSkill(userSkill);
                    }

                    var skill = _skillRepository.getSkill(s.skillDescription);
                    var user = _userRepository.getUserById(userId);


                    var skillSet = new SkillSetMapping();
                    skillSet.Skill = skill;
                    skillSet.User = user;
                    skillSet.rating = s.rating;

                    _skillSetMappingRepository.addSkillSet(skillSet);

                    var userActivityLog = new ActivityLog();
                    userActivityLog.acctivityAction = "Added a skill";
                    userActivityLog.user = user;
                    userActivityLog.topicType = s.skillDescription;
                    userActivityLog.date = DateTime.Today;

                    _activityLogRepository.addUserActivityLog(userActivityLog);
                }
            }

            catch
            {
                throw;
            }


        }

        public List<Skill> getUserSkills(int userId)
        {
            _logger.LogInformation("SkillService getUserSkills");
            try
            {
                return _skillSetMappingRepository.getSkillByUserId(userId);
            }

            catch
            {
                throw;
            }

        }

        public void editUserSkill(EditSkillRequestModel editSkillRequestModel, int userId)
        {
            _logger.LogInformation("SkillService editUserSkill");

            try
            {
                var skill = _skillSetMappingRepository.getUserSkillBySkill(userId, editSkillRequestModel.skillSetId);

                if (skill == null)
                {
                    _logger.LogInformation("SkillService {@editSkillRequestModel}", editSkillRequestModel);
                    throw new Exception($"given skill {editSkillRequestModel.skillId} not found for this {userId}");
                }

                var skillSet = _skillSetMappingRepository.getSkillSetById(userId, editSkillRequestModel.skillId);

                skillSet.rating = editSkillRequestModel.rating;

                _skillSetMappingRepository.updateSkillSet(skillSet);

                var user = _userRepository.getUserById(userId);

                var userActivityLog = new ActivityLog();
                userActivityLog.acctivityAction = "updated a skill";
                userActivityLog.user = user;
                userActivityLog.topicType = skillSet.Skill.skillDescription;
                userActivityLog.date = DateTime.Today;

                _activityLogRepository.addUserActivityLog(userActivityLog);
            }

            catch
            {
                throw;
            }

        }

        public void deleteUserSkill(int skillId, int userId)
        {
            _logger.LogInformation("SkillService editUserSkill");

            try
            {
                var skillSet = _skillSetMappingRepository.getSkillSetById(userId, skillId);

                if (skillSet == null)
                {
                    _logger.LogError("SkillService {@skillId} invalid id", skillId);
                    throw new Exception("given skill not found for this user");
                }

                if (skillSet.isDeleted)
                {
                    _logger.LogError("SkillService {@skillId} already deleted", skillId);
                    throw new Exception("given skill is already deleted");
                }

                skillSet.isDeleted = true;

                _skillSetMappingRepository.updateSkillSet(skillSet);
                var user = _userRepository.getUserById(userId);

                if(user == null)
                {
                    throw new Exception("User id not found");
                }

                var userActivityLog = new ActivityLog();
                userActivityLog.acctivityAction = "Deleted a skill";
                userActivityLog.user = user;
                userActivityLog.topicType = skillSet.Skill.skillDescription;
                userActivityLog.date = DateTime.Today;

                _activityLogRepository.addUserActivityLog(userActivityLog);
            }

            catch
            {
                throw;
            }


        }

        public void addUserPoc(AccomplishmentRequest accomplishmentRequest, int userId)
        {
            _logger.LogInformation("SkillService addUserPoc");

            try
            {
                var user = _userRepository.getUserById(userId);

                if (user == null)
                {
                    _logger.LogError("SkillService {@userId} not found", userId);
                    throw new Exception($"user with {userId} not found");
                }

                var accomplishment = new AccomplishmentModel();
                accomplishment.accomplishmentType = Common.AccomplishmentType.POC;
                accomplishment.accomplishmentTitle = accomplishmentRequest.accomplishmentTitle;
                accomplishment.accomplishmentDescription = accomplishmentRequest.accomplishmentDescription;
                accomplishment.User = user;
                accomplishment.accomplishedDate = accomplishmentRequest.accomplishedDate;

                _accomplishmentRepository.addUserPoc(accomplishment);

                var userActivityLog = new ActivityLog();
                userActivityLog.acctivityAction = "Added a POC";
                userActivityLog.user = user;
                userActivityLog.topicType = accomplishment.accomplishmentTitle;
                userActivityLog.date = DateTime.Today;

                _activityLogRepository.addUserActivityLog(userActivityLog);
            }

            catch
            {
                throw;
            }


        }

        public void editUserPoc(EditAccomplishmentRequest accomplishmentRequest, int userId)
        {
            _logger.LogInformation("SkillService editUserPoc");

            try
            {
                var userPoc = _accomplishmentRepository.getUserPocById(accomplishmentRequest.accomplishmentId);
                userPoc.accomplishmentTitle = accomplishmentRequest.accomplishmentTitle;
                userPoc.accomplishmentDescription = accomplishmentRequest.accomplishmentDescription;
                userPoc.accomplishedDate = accomplishmentRequest.accomplishedDate;

                _accomplishmentRepository.updateUserPoc(userPoc);

                var user = _userRepository.getUserById(userId);

                var userActivityLog = new ActivityLog();
                userActivityLog.acctivityAction = "Updates a POC";
                userActivityLog.user = user;
                userActivityLog.topicType = accomplishmentRequest.accomplishmentTitle;
                userActivityLog.date = DateTime.Today;

                _activityLogRepository.addUserActivityLog(userActivityLog);
            }

            catch
            {
                throw;
            }

        }

        public void deleteUserPoc(Guid id, int userId)
        {
            _logger.LogInformation("SkillService deleteUserPoc");

            try
            {
                var userPoc = _accomplishmentRepository.getUserPocById(id);

                if (userPoc == null)
                {
                    _logger.LogError("SkillService {@id} not found", id);
                    throw new Exception($"invalid request Poc not found with given {id}");
                }

                _accomplishmentRepository.deleteUserPocById(userPoc);

                var user = _userRepository.getUserById(userId);


                var userActivityLog = new ActivityLog();
                userActivityLog.acctivityAction = "deleted a POC";
                userActivityLog.user = user;
                userActivityLog.topicType = userPoc.accomplishmentTitle;
                userActivityLog.date = DateTime.Today;

                _activityLogRepository.addUserActivityLog(userActivityLog);
            }

            catch
            {
                throw;
            }


        }

        public List<AccomplishmentModel> getUserPoc(int userId)
        {
            try
            {
                return _accomplishmentRepository.getUserPocs(userId);
            }

            catch
            {
                throw;
            }

        }
    }
}

