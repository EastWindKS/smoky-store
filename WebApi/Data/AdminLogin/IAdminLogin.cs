using System.Collections;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IAdminLogin
    {
        AdminLogin GetAccess(string login, string password);
        IEnumerable<StoreOrder> OrderList();
        StoreOrder GetOrderById(int id);
    }
}