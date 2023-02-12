using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using okrDemoApp.Models;
using okrDemoApp.Services;
using okrDemoApp.Utils;

namespace okrDemoApp.Controllers
{
    /**
     * multi line comment
     **/ 
    [ApiController]
    [Authorize]
    public class DashboardController: ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }

        [HttpGet("activities")]
        public IActionResult GetAllActivity()
        {
            _logger.LogInformation("Processed in ms.");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);
                var genericResponse = new ResponseModel<List<ActivityLog>>();

                genericResponse.message = _dashboardService.GetAllActivity(userId);
                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("activity")]
        [ClaimRequirementAttribute("user", "CanReadResource")]
        public IActionResult GetAllActivity(int page)
        {
            _logger.LogInformation("Processed in ms.");

            try
            {
                var genericResponse = new ResponseModel<List<ActivityLog>>();
                var userId = Int32.Parse(User?.Identity?.Name);
                genericResponse.message = _dashboardService.GetAllActivity(page, userId);
                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

