using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace okrDemoApp.Utils
{
	public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

		public ClaimRequirementFilter(Claim claim)
		{
            _claim = claim;
		}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);

            var email = context.HttpContext.User.FindFirstValue(ClaimTypes.Email);

            Console.WriteLine(email);

            if (email == null)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

