﻿using System.Collections.Generic;
using System.Security.Claims;
using SampleOneDDD.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace SampleOneDDD.Domain.Models
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return  _accessor.HttpContext.User.Claims;
        }
    }
}
