using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    // api/companies
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repoData;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository repository, IMapper mapper)
        {
            _repoData = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetAllCompanies()
        {
            var companies = _repoData.GetAllCompanies();
            return Ok(companies);
        }


        [HttpGet("{id}", Name = "GetCompanyById")]
        public ActionResult<CompanyReadDto> GetCompanyById(int id)
        {
            var company = _repoData.GetCompanyById(id);
            if (company != null)
            {
                return Ok(_mapper.Map<CompanyReadDto>(company));
            }

            return NotFound();
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<Strength>> GetFilteredCompanies([FromQuery(Name = "soft")] bool soft,
            [FromQuery(Name = "middle")] bool middle,
            [FromQuery(Name = "rare")] bool rare)
        {
            return Ok(_repoData.GetFilteredCompanies(soft, middle, rare));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCompany(int id, CompanyUpdateDto companyUpdateDto)
        {
            var companyModelFromRepo = _repoData.GetCompanyById(id);
            if (companyModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(companyUpdateDto, companyModelFromRepo);
            _repoData.UpdateCompany(companyModelFromRepo);
            _repoData.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddCompany(CompanyAddDto addCompany)
        {

            var company = new Company
            {
                CompanyName = addCompany.CompanyName,
                ImgUrl = addCompany.ImgUrl,
                Strengths = new List<Strength>()
            };
            

            foreach (var str in addCompany.Strengths)
            {
                
                var addStrItem = new Strength { StrName = str };
                
                company.Strengths.Add(addStrItem);

            };
            _repoData.AddCompany(company);
            _repoData.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCompanyUpdate(int id, JsonPatchDocument<CompanyUpdateDto> patchDocument)
        {
            var companyFromRepo = _repoData.GetCompanyById(id);
            if (companyFromRepo == null)
            {
                return NotFound();
            }

            var companyToPatch = _mapper.Map<CompanyUpdateDto>(companyFromRepo);
            patchDocument.ApplyTo(companyToPatch, ModelState);
            if (!TryValidateModel(companyToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(companyToPatch, companyFromRepo);
            _repoData.UpdateCompany(companyFromRepo);
            _repoData.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(int id)
        {
            var companyFromRepo = _repoData.GetCompanyById(id);
            if (companyFromRepo == null)
            {
                NotFound();
            }
            _repoData.DeleteCompany(companyFromRepo);
            _repoData.SaveChanges();
            return NoContent();
        }
    }
}
