using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSDocker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        public SampleController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok("Docker");
        }
             
    }
}
