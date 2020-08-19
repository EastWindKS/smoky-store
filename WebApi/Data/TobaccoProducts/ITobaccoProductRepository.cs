using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface ITobaccoProductRepository
    {

        IEnumerable<TobaccoProduct> GetAllProductsByCompany(int companyId);

        TobaccoProduct GetTobaccoProductById(int id);
        bool SaveChanges();
    }
}