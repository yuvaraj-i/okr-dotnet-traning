using System;
using okrDemoApp.Models;
using okrDemoApp.Repositories;
using okrDemoApp.Utils;

namespace okrDemoApp.Services
{
	public class HomeService : IHomeService
    {
        private readonly IJwtTokenUtils _jwtTokenUtils;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<HomeService> _logger;

        public HomeService(IJwtTokenUtils jwtTokenUtils, IUserRepository userRepository, ILogger<HomeService> logger)
		{
            _jwtTokenUtils = jwtTokenUtils;
            _userRepository = userRepository;
            _logger = logger;

        }

        public string VerifyUser(UserRequest userRequest)
        {
            _logger.LogInformation("HomeService verifyUser");

            try
            {
                User user = _userRepository.GetUserByEmail(userRequest.email);

                if (user == null)
                {
                    _logger.LogError("{@userRequest} not found", userRequest);
                    throw new Exception("User with given email not found");
                }

                if (user.email != userRequest.email)
                {
                    _logger.LogError("{@userRequest} given email not found", userRequest);
                    throw new Exception("invaild credentials");
                }

                if(user.password != userRequest.password)
                {
                    _logger.LogError("{@userRequest} invalid password!", userRequest);
                    throw new Exception("invaild credentials");
                }

                return _jwtTokenUtils.CreateToken(user);

            }

            catch
            {
                throw;
            }
        }

        public void CreateUser(UserModel userRequest)
        {
            _logger.LogInformation("HomeService createUser in ms.");

            try
            {
                User user = _userRepository.GetUserByEmail(userRequest.email);
                if (user != null)
                {
                    _logger.LogError("{@userRequest} given not found", userRequest);
                    throw new Exception("User with given email already exist");
                }

                var userModel = new User();
                userModel.email = userRequest.email;
                userModel.name = userRequest.name;
                userModel.password = userRequest.password;

                _userRepository.AddUser(userModel);
            }

            catch
            {
                throw;
            }
        }
    }
}

