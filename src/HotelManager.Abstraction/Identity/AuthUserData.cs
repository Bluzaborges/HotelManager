using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Abstraction.Identity.Abstractions;

namespace HotelManager.Abstraction.Identity
{
    public class AuthUserData : IAuthUserData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthUserData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid IdUser => GetIdUser();
        public int UserRole => GetRole();

        private Guid GetIdUser()
        {
            ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;

            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            {
                throw new UserPermissionException();
            }

            return Guid.Parse(user.Claims.First(c => c.Type == "UserId").Value);
        }

        private int GetRole()
        {
            ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;

            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            {
                throw new UserPermissionException();
            }

            return Convert.ToInt32(user.Claims.First(c => c.Type == ClaimTypes.Role).Value);
        }
    }
}