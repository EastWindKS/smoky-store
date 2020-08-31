using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Services
{
    public class AuthOptions
    {
        public string Issuer { get; set; } // who generate token
        public string Audience { get; set; }// fro whom token
        public string Secret { get; set; } // key for generate
        public int TokenLifeTime { get; set; } // sec

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }

    }
}
