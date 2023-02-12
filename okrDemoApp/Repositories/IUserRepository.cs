using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public interface IUserRepository
	{
		public User GetUserByEmail(string email);
        public User GetUserById(int id);
        public void AddUser(User user);
    }
}

