using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using WebApi.Controllers;
using WebApi.Data;
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
            var mockDataRepository = new Mock<ICompanyRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CompanyProfile());
            });
            var mapper = mockMapper.CreateMapper();
            mockDataRepository.Setup(repo => repo.GetAllCompanies())
                .Returns(() => mockCompanies.AsEnumerable());
            var companiesController = new CompaniesController(mockDataRepository.Object, mapper);

            var result = companiesController.GetAllCompanies().Result as OkObjectResult;
            var model = result.Value as IEnumerable<Company>;
            Assert.Equal(10, model.Count());
            Assert.NotNull(model);
            mockDataRepository.Verify(mock => mock.GetAllCompanies(), Times.Once);
        }
    }

}
