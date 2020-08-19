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
    [Route("api/admlogin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminLogin _repo;
        public AdminController(IAdminLogin repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<bool> GetAccess([FromQuery] string login, [FromQuery] string password)
        {
            return Ok(_repo.GetAccess(login, password));
        }
    }
}
