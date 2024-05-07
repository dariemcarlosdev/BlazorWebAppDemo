using BlazingPizza.DAL;
using BlazingPizza.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazingPizza.Controllers
{
    [Route("api/specials")]
    [ApiController]
    public class PizzaSpecialsController(PizzaStoreDemoContext dbcontext) : ControllerBase
    {
        private readonly PizzaStoreDemoContext dbcontext = dbcontext;

        // GET: api/<PizzaSpecialsController>
        [HttpGet]
        public async Task<IEnumerable<PizzaSpecial>> Get()
        {
            return [.. (await dbcontext.Specials.ToListAsync()).OrderByDescending(x => x.BasePrice)];
        }

        //// GET api/<PizzaSpecialsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PizzaSpecialsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PizzaSpecialsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PizzaSpecialsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
