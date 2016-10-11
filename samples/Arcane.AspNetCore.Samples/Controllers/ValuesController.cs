using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcane.AspNetCore.Samples.Data;
using Microsoft.AspNetCore.Mvc;

namespace Arcane.AspNetCore.Samples.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IQueryContext _context;

        public ValuesController(IQueryContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _context.Query<Author>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _context.Query<Author>().FirstOrDefault(a => a.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Author value)
        {
            using (var dataStore = _context.StoreFactory.CreateStore())
            {
                dataStore.Insert(value);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Author value)
        {
            value.Id = id;

            using (var dataStore = _context.StoreFactory.CreateStore())
            {
                var test = _context.Query<Author>().Where(value.GetExpression());
                dataStore.Update(value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _context.Query<Author>().FirstOrDefault(a => a.Id == id);

            if (author != null)
            {
                using (var dataStore = _context.StoreFactory.CreateStore())
                {
                    dataStore.Delete(author);
                }
            }
        }
    }
}
