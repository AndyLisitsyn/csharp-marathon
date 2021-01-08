using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskAuthenticationAuthorization.Services
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
        public IsAdminRequirement() { }
    }

    public class MyAuthorizationService : AuthorizationHandler<IsAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;

            var name = context.User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;
            if (name != null && name == "admin")
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }

    }
}
