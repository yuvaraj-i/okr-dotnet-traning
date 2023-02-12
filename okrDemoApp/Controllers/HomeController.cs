using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.RazorPages;
using okrDemoApp.Services;
using okrDemoApp.DBContex;
using okrDemoApp.Models;

namespace okrDemoApp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, AppDbContex appDbContex, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        [HttpPost("signup")]
        public ActionResult AddUser(UserModel user)
        {
            _logger.LogInformation("Processed in ms.");

            try
            { 
                var genericResponse = new ResponseModel<string>();
                _homeService.CreateUser(user);
                genericResponse.message = "Success";

                return Ok(genericResponse);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult Login(UserRequest request)
        {
            _logger.LogInformation("Processed in ms.");

            try
            {
                var genericResponse = new ResponseModel<string>();
                genericResponse.message = _homeService.VerifyUser(request);


                return Ok(genericResponse);
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("hello")]
        public ActionResult Hello()
        {
            Console.WriteLine("Hi");
            return Ok("Hello World!");
        }
    }

}

