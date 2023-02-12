using System;
using okrDemoApp.Models;

namespace okrDemoApp.Utils
{
	public interface IJwtTokenUtils
	{
		public string CreateToken(User user);
	}

}

