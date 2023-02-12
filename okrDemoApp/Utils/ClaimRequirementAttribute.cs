﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace okrDemoApp.Utils
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}

