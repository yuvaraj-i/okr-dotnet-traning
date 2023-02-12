using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public interface IAccomplishmentRepository
	{
		void AddUserPoc(AccomplishmentModel accomplishmentModel);
        void UpdateUserPoc(AccomplishmentModel accomplishmentModel);
        List<AccomplishmentModel> GetUserPocs(int userId);
        void DeleteUserPocById(AccomplishmentModel accomplishmentModel);
        AccomplishmentModel GetUserPocById(Guid accomplishmentId);
    }
}

