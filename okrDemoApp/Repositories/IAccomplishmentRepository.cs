using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public interface IAccomplishmentRepository
	{
		void addUserPoc(AccomplishmentModel accomplishmentModel);
        void updateUserPoc(AccomplishmentModel accomplishmentModel);
        List<AccomplishmentModel> getUserPocs(int userId);
        void deleteUserPocById(AccomplishmentModel accomplishmentModel);
        AccomplishmentModel getUserPocById(Guid accomplishmentId);
    }
}

