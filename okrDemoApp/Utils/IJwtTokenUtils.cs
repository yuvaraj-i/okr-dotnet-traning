using System;
using okrDemoApp.Models;

namespace okrDemoApp.Utils
{
	public interface IJwtTokenUtils
	{
		public string createToken(User user);
	}

}

