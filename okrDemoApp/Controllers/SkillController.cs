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
        private readonly ILogger<SkillController> _logger;

        public SkillController(ISkillService skillService, ILogger<SkillController> logger)
		{
			_skillService = skillService;
            _logger = logger;

        }

		[HttpGet, Authorize]
		public IActionResult GetUserSkills()
		{
            _logger.LogInformation("SkillController getUserSkills");

			try
			{
				var userId = Int32.Parse(User?.Identity?.Name);
				var skills = _skillService.GetUserSkills(userId);

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
		public IActionResult AddUserSkills(List<SkillRequestModel> skills)
		{
            _logger.LogInformation("SkillController addUserSkills");

            try
			{
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.AddSkill(skills, userId);
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
        public IActionResult EditUserSkills(EditSkillRequestModel skills)
        {
            _logger.LogInformation("SkillController editUserSkills");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.EditUserSkill(skills, userId);
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
        public IActionResult DeleteUserSkills(int id)
        {
            _logger.LogInformation("SkillController deleteUserSkills");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.DeleteUserSkill(id, userId);
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
        public IActionResult AddPocSkill(AccomplishmentRequest accomplishmentRequest)
        {
            _logger.LogInformation("SkillController addPocSkill");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.AddUserPoc(accomplishmentRequest, userId);
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
        public IActionResult UpdateUserPoc(EditAccomplishmentRequest accomplishmentRequest)
        {
            _logger.LogInformation("SkillController updateUserPoc");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);

                var genericResponse = new ResponseModel<string>();
                _skillService.EditUserPoc(accomplishmentRequest, userId);
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
        public IActionResult DeleteUserPoc(Guid id)
        {
            _logger.LogInformation("SkillController updateUserPoc");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);
                var genericResponse = new ResponseModel<string>();
                _skillService.DeleteUserPoc(id, userId);
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
        public IActionResult GetUserPoc()
        {
            _logger.LogInformation("SkillController getUserPoc");

            try
            {
                var userId = Int32.Parse(User?.Identity?.Name);
                var genericResponse = new ResponseModel<List<AccomplishmentModel>>();
                
                genericResponse.message = _skillService.GetUserPoc(userId);
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

