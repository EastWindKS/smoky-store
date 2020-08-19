using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/tproduct")]
    [ApiController]
    public class TobaccoProductController : ControllerBase
    {
        private readonly ITobaccoProductRepository _repository;
        public TobaccoProductController(ITobaccoProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TobaccoProduct>> GetTobaccoProductsByNameCompany(int id)
        {
            var tobaccoList = _repository.GetAllProductsByCompany(id);
            if (tobaccoList != null)
            {
                return Ok(tobaccoList);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<TobaccoProduct> GetTobaccoProductById([FromQuery] int id)
        {
            return Ok(_repository.GetTobaccoProductById(id));
        }
    }
}
