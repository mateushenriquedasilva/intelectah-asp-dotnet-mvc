using Intelectah.Data;
using Intelectah.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelectah.Controllers
{
    [ApiController]
    [Route(template:"v1")]
    public class IntelectahController : ControllerBase
    {
        //actions
        [HttpGet]
        [Route(template: "pacientes")]
        public async Task<IActionResult> Get(
            [FromServices] AppDbContext context)
        {
            var pacientes = await context
                .Pacientes
                .AsNoTracking()
                .ToListAsync();

            return Ok(pacientes);
        }
    }
}
