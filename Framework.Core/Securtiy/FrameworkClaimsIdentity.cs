using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Framework.Core.Securtiy
{
    public class FrameworkClaimsIdentity
    {
        public FrameworkClaimsIdentity(Guid userId, IEnumerable<Claim> claimSet)
        {
            UserId = userId;
            ClaimSet = claimSet;
        }

        public FrameworkClaimsIdentity(Guid userId)
        {
            UserId = userId;
        }

        private IEnumerable<Claim> ClaimSet { get; }
        public Guid UserId { get; set; }

        public IEnumerable<Claim> Roles
        {
            get { return ClaimSet.Where(c => c.Type == ClaimTypes.Role); }
        }

        public Claim Name
        {
            get { return ClaimSet.FirstOrDefault(c => c.Type == ClaimTypes.Name); }
        }

        public Claim Email
        {
            get { return ClaimSet.FirstOrDefault(c => c.Type == ClaimTypes.Email); }
        }
    }
}