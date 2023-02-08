using System;
using okrDemoApp.Models;

namespace okrDemoApp.Services
{
	public interface IHomeService {

		public string verifyUser(UserRequest userRequest);
        public void createUser(UserModel userRequest);

    }

}

