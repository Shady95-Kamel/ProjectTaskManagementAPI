using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Security.JWT
{
    public interface IJwtService
    {
        string GenerateToken(User user);

        public string GenerateRefreshToken();
    }
}
