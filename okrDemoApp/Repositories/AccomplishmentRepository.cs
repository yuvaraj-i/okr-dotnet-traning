using System;
using okrDemoApp.DBContex;
using okrDemoApp.Migrations;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public class AccomplishmentRepository : IAccomplishmentRepository
	{
        private readonly AppDbContex _DbContext;

        public AccomplishmentRepository(AppDbContex DbContext)
		{
            _DbContext = DbContext;

        }

        public void AddUserPoc(AccomplishmentModel accomplishmentModel)
        {
            try
            {
                _DbContext.accomplishments.Add(accomplishmentModel);
                _DbContext.SaveChanges();
            }

            catch
            {
                throw;
            }

        }

        public void DeleteUserPocById(AccomplishmentModel accomplishmentModel)
        {
            try
            {

                _DbContext.accomplishments.Remove(accomplishmentModel);
            }

            catch
            {
                throw;
            }
        }

        public List<AccomplishmentModel> GetUserPocs(int id)
        {
            try
            {
                return _DbContext.accomplishments.Where(s => s.User.id == id).ToList();
            }

            catch
            {
                throw;
            }
        }

        public AccomplishmentModel GetUserPocById(Guid id)
        {
            try
            {

                return _DbContext.accomplishments.Find(id);
            }

            catch
            {
                throw;
            }
        }

        public void UpdateUserPoc(AccomplishmentModel accomplishmentModel)
        {
            try
            {
                _DbContext.accomplishments.Update(accomplishmentModel);
                _DbContext.SaveChanges();
            }

            catch
            {
                throw;
            }

        }

    }
}

