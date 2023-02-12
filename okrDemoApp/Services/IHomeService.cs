using System;
using okrDemoApp.Models;

namespace okrDemoApp.Services
{
	public interface IHomeService {

		public string VerifyUser(UserRequest userRequest);
        public void CreateUser(UserModel userRequest);

    }

}

