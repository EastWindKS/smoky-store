using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<StoreOrder> OrderList()
        {
            return _context.StoreOrders;
        }

        public StoreOrder GetOrderById(int id)
        {
            return _context.StoreOrders.Find(id);
        }
    }
}