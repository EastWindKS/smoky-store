using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        void AddStr(Strength strength);
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Filter> GetFilteredCompanies(bool soft, bool middle, bool rare);
        Company GetCompanyById(int id);
        Company GetCompanyByName(string name);
        bool SaveChanges();
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
