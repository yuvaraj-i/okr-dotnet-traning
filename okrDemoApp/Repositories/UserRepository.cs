using System;
using System.Linq;
using okrDemoApp.DBContex;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly AppDbContex _DbContext;

        public UserRepository(AppDbContex appDbContex)
		{
            _DbContext = appDbContex;

        }

        public void AddUser(User user)
        { 
            _DbContext.users.Add(user);
            _DbContext.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            try
            {

                return _DbContext.users.Where(s => s.email == email).FirstOrDefault<User>();
            }

            catch
            {
                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {

             return _DbContext.users.Find(id);
            }

            catch
            {
                throw;
            }

        }
    }
}

