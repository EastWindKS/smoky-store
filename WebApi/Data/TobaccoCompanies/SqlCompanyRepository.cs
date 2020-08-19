using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlCompanyRepository : ICompanyRepository
    {
        private readonly Context _context;

        public SqlCompanyRepository(Context context)
        {
            _context = context;
        }

        public void AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            _context.Companies.Add(company);
        }

        public void AddStr(Strength strength)
        {
            _context.Strengths.Add(strength);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }


        public IEnumerable<Filter> GetFilteredCompanies(bool soft, bool middle, bool rare)
        {
            if (soft && !middle && !rare)
            {
                return (from company in _context.Companies
                        join str in _context.Strengths on company.CompanyId equals str.CompanyId
                        where EF.Functions.Like(str.StrName, "soft")
                        select new Filter
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName,
                            ImgUrl = company.ImgUrl
                        }
                    ).Distinct().ToList();
            }
            if (middle && !soft && !rare)

            {
                return (from company in _context.Companies
                        join str in _context.Strengths on company.CompanyId equals str.CompanyId
                        where EF.Functions.Like(str.StrName, "middle")
                        select new Filter
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName,
                            ImgUrl = company.ImgUrl
                        }
                    ).Distinct().ToList();
            }
            if (rare && !soft && !middle)
            {
                return (from company in _context.Companies
                        join str in _context.Strengths on company.CompanyId equals str.CompanyId
                        where EF.Functions.Like(str.StrName, "middle") ||
                              EF.Functions.Like(str.StrName, "rare")
                        select new Filter
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName,
                            ImgUrl = company.ImgUrl
                        }
                    ).Distinct().ToList();
            }
            if (soft && middle && !rare)
            {
                return (from company in _context.Companies
                        join str in _context.Strengths on company.CompanyId equals str.CompanyId
                        where EF.Functions.Like(str.StrName, "middle") ||
                              EF.Functions.Like(str.StrName, "soft")
                        select new Filter
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName,
                            ImgUrl = company.ImgUrl
                        }
                    ).Distinct().ToList();
            }
            if (soft && rare && !middle)

            {
                return (from company in _context.Companies
                        join str in _context.Strengths on company.CompanyId equals str.CompanyId
                        where EF.Functions.Like(str.StrName, "soft") ||
                              EF.Functions.Like(str.StrName, "rare")
                        select new Filter
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName,
                            ImgUrl = company.ImgUrl
                        }
                    ).Distinct().ToList();
            }
            if (!soft && rare && middle)

            {
                return (from company in _context.Companies
                        join str in _context.Strengths on company.CompanyId equals str.CompanyId
                        where EF.Functions.Like(str.StrName, "middle") ||
                              EF.Functions.Like(str.StrName, "rare")
                        select new Filter
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName,
                            ImgUrl = company.ImgUrl
                        }
                    ).Distinct().ToList();
            }


            return (from company in _context.Companies
                    join str in _context.Strengths on company.CompanyId
                        equals str.CompanyId
                    select new Filter
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        ImgUrl = company.ImgUrl
                    }).Distinct().ToList();
        }


        public Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(company => company.CompanyId == id);
        }

        public Company GetCompanyByName(string name)
        {
            return _context.Companies.FirstOrDefault(company => company.CompanyName == name);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCompany(Company company)
        {
            //nothing Why?
        }

        public void DeleteCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            _context.Remove(company);
        }
    }
}