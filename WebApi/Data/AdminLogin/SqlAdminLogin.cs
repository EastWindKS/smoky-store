using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlAdminLogin : IAdminLogin
    {
        private readonly Context _context;
        public SqlAdminLogin(Context context)
        {
            _context = context;
        }
        public AdminLogin GetAccess(string login, string password)
        {
            
            var exist = _context.AdminLogins.Where(admin => admin.Login == login && admin.Password == password).ToList()
                .FirstOrDefault();
            return exist;
        }

       
    }
}