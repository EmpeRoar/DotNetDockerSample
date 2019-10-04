using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSDocker.Api.InputModel;
using VSDocker.EFCore;
using VSDocker.Model;

namespace VSDocker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public CompanyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _appDbContext.Companies.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyInputmodel companyInputmodel)
        {
            var company = new Company()
            {
                 Name = companyInputmodel.Name
            };
            await _appDbContext.Companies.AddAsync(company);
            await _appDbContext.SaveChangesAsync();
            return Ok(company.Id);
        }
    }
}
