using DatingAPI.Data.DataContext;
using DatingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DatingAPI.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DateApiContext context;
        public ValuesController(DateApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Value>> GetValues()
        {
            return await context.Values.ToListAsync();
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleValue(int id)
        {
            var vals = await context.Values.FirstOrDefaultAsync(x => x.Id == id);
            if(vals == null)
            {
                return NotFound();
            }

            return Ok(vals);    
        }

        [HttpPost("add-value")]
        public IActionResult AddValue(Value value)
        {
            context.Values.Add(value);
            context.SaveChanges();
            return StatusCode(201);
        }

    }
}
