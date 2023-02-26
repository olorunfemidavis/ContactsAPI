using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Backend.Interfaces;
using ContactsAPI.Backend.Repositories;
using ContactsAPI.Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;
        // GET: api/Contact
        public ContactController()
        {
            _contactRepository = new ContactRepository(new LiteDbService());
        }

        [HttpGet("List")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("Get/{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        [HttpPost("AddContact")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("SetPhone{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Contact/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}
