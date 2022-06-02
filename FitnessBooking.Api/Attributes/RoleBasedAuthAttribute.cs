using System.Linq;
using FitnessBooking.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FitnessBooking.Api.Attributes
{
    public class RoleBasedAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public Roles AllowedRoles { get; set; }

        public RoleBasedAuthAttribute(Roles allowedRoles)
        {
            AllowedRoles = allowedRoles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(AllowedRoles.ToString()))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var role = context.HttpContext.User.Claims.Where(c => c.Type == "grants").FirstOrDefault().Value;

            if (role == null || !AllowedRoles.ToString().Equals(role))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}