using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Profiles;
using Xunit;

namespace BackendTests
{
    public class CompaniesControllerTest
    {
        [Fact]
        public void GetAllCompanies_WhenNoParameters_ReturnsAllCompanies()
        {
            var mockCompanies = new List<Company>();
            for (int i = 1; i < 11; i++)
            {

                mockCompanies.Add(new Company
                {
                    CompanyId = i,
                    ImgUrl = $"Test img URL {i}",
                    CompanyName = $"Test Name {i}",
                    Strengths = new List<Strength>()
                });
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CompanyProfile());
            }).CreateMapper();
            var mockDataRepository = new Mock<ICompanyRepository>();
            mockDataRepository.Setup(repo => repo.GetAllCompanies())
                .Returns(() => mockCompanies.AsEnumerable());
            var companiesController = new CompaniesController(mockDataRepository.Object, mapper);
            var result = companiesController.GetAllCompanies().Result as OkObjectResult;
            var model = result.Value as IEnumerable<Company>;
            Assert.Equal(10, model.Count());
            Assert.NotNull(model);
            mockDataRepository.Verify(mock => mock.GetAllCompanies(), Times.Once);
        }
        [Fact]
        public void GetCompanyById_WithId_ReturnCorrectCompany()
        {
            var mockCompany = new Company()
            {
                CompanyId = 1,
                ImgUrl = "test img url",
                CompanyName = "Test name",
            };
            var mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new CompanyProfile())).CreateMapper();
            var mockDataRepository = new Mock<ICompanyRepository>();
            mockDataRepository.Setup(repo => repo.GetCompanyById(1))
                .Returns((() => mockCompany ));
            var x = mapper.Map<CompanyReadDto>(mockCompany);
            var companiesController = new CompaniesController(mockDataRepository.Object, mapper);


            var result = companiesController.GetCompanyById(1).Result;
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<CompanyReadDto>(actionResult.Value);
            
        }
    }


}
