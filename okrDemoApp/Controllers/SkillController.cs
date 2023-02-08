using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using okrDemoApp.Controllers;
using okrDemoApp.Models;
using okrDemoApp.Services;

namespace helloWorld.Controllers
{
	[ApiController]
	[Route("skill")]
	public class SkillController : ControllerBase
	{
		private readonly ISkillService _skillService;
        private readonly ILogger<DashboardController> _logger;

        public SkillController(ISkillService skillService, ILogger<DashboardController> logger)
		{
			_skillService = skillService;
            _logger = logger;

        }

		[HttpGet, Authorize]
		public IActionResult getUserSkills()
		{
            _logger.LogInformation("SkillController getUserSkills");

			try
			{
				var userId = Int32.Parse(User?.Identity?.Name);
				var skills = _skillService.getUserSkills(userId);

                var genericResponse = new ResponseModel<List<Skill>>();
				genericResponse.message = skills;

				return Ok(genericResponse);
            }

			catch(Exception e)
			{
				return BadRequest(e.Message);
			}

        }


		[HttpPost, Authorize]
		public IActionResult addUserSkills(List<SkillRequestModel> skills)
		{
            _logger.LogInformation("SkillController addUserSkills");

            try
			{
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.addSkill(skills, userId);
                genericResponse.message = "success";

                return Ok(genericResponse);
            }
			catch(Exception e)
			{
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
		}

        [HttpPut, Authorize]
        public IActionResult editUserSkills(EditSkillRequestModel skills)
        {
            _logger.LogInformation("SkillController editUserSkills");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.editUserSkill(skills, userId);
                genericResponse.message = "success";

                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult deleteUserSkills(int id)
        {
            _logger.LogInformation("SkillController deleteUserSkills");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.deleteUserSkill(id, userId);
                genericResponse.message = "success";

                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
        }

        [HttpPost("poc"), Authorize]
        public IActionResult addPocSkill(AccomplishmentRequest accomplishmentRequest)
        {
            _logger.LogInformation("SkillController addPocSkill");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.addUserPoc(accomplishmentRequest, userId);
                genericResponse.message = "success";

                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
        }

        [HttpPut("poc"), Authorize]
        public IActionResult updateUserPoc(EditAccomplishmentRequest accomplishmentRequest)
        {
            _logger.LogInformation("SkillController updateUserPoc");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.editUserPoc(accomplishmentRequest, userId);
                genericResponse.message = "success";

                return Ok(genericResponse);

            }
            catch (Exception e)
            {
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("poc/{id}"), Authorize]
        public IActionResult deleteUserPoc(Guid id)
        {
            _logger.LogInformation("SkillController updateUserPoc");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);
                var genericResponse = new ResponseModel<string>();
                _skillService.deleteUserPoc(id, userId);
                genericResponse.message = "success";

                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("poc"), Authorize]
        public IActionResult getUserPoc()
        {
            _logger.LogInformation("SkillController getUserPoc");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);
                var genericResponse = new ResponseModel<List<AccomplishmentModel>>();
                
                genericResponse.message = _skillService.getUserPoc(userId);
                return Ok(genericResponse);
            }
            catch (Exception e)
            {
                _logger.LogTrace($"SkillController {e}");
                return BadRequest(e.Message);
            }
        }

    }
}

