using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSixSiegeHUD.Data;
using RSixSiegeHUD.Infrastructure;
using RSixSiegeHUD.ViewModel;

namespace RSixSiegeHUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Object
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Object/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Object
        [HttpPost(Name = "Match")]
        public void Post([FromBody] dynamic jsonObject)
        {
            GeneralObjectCreator generalObjectCreator = new GeneralObjectCreator();
            SiegeViewModel viewmodel = generalObjectCreator.SeperateObjects(jsonObject);

            if (_context.Matches.Where(x => x.MatchToken.Equals(viewmodel.CurrentMatch.MatchToken)).FirstOrDefault() != null)
            {
                _context.Add(viewmodel.CurrentRound);
            }
            else
            {
                _context.Add(viewmodel.CurrentMatch);
                _context.Add(viewmodel.CurrentRound);

                _context.SaveChanges();

            }
        }

        // PUT: api/Object/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
