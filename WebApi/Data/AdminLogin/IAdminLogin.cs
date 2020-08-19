using WebApi.Models;

namespace WebApi.Data
{
    public interface IAdminLogin
    {
        bool GetAccess(string login, string password);
    }
}