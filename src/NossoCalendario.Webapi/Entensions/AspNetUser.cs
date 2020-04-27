using Microsoft.AspNetCore.Http;
using NossoCalendario.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NossoCalendario.WebApi.Entensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public AspNetUser(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAcessor = httpContextAcessor;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value : string.Empty;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) : Guid.Empty;
        }

        public string GetUserName()
        {
            return IsAuthenticated() ? _httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAcessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
