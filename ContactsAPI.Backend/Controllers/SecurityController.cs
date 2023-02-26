using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Backend.Repositories;
using ContactsAPI.Backend.Services;
using ContactsAPI.Shared.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;
        public SecurityController()
        {
            _contactRepository = new ContactRepository(new LiteDbService());
        }
        
        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginRegisterPayload payload )
        {
            return Ok();
        }

        [HttpPost("Register")]
        public ActionResult Post([FromBody] LoginRegisterPayload payload)
        {
            return Ok();
        }
    }
}
