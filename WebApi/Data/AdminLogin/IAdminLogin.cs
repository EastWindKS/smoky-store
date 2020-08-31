using WebApi.Models;

namespace WebApi.Data
{
    public interface IAdminLogin
    {
        AdminLogin GetAccess(string login, string password);
    }
}