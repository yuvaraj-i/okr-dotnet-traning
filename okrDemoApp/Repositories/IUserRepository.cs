using System;
using okrDemoApp.Models;

namespace okrDemoApp.Repositories
{
	public interface IUserRepository
	{
		public User getUserByEmail(string email);
        public User getUserById(int id);
        public void addUser(User user);
    }
}

