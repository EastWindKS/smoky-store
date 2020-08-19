using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlTobaccoProductRepository : ITobaccoProductRepository
    {
        private readonly Context _context;
        public SqlTobaccoProductRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<TobaccoProduct> GetAllProductsByCompany(int id)
        {
            return _context.Products.Where(tobacco => tobacco.CompanyId == id).ToList();

        }

        public TobaccoProduct GetTobaccoProductById(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).ToList().FirstOrDefault();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}