using System.Security.Claims;
using AutoMapper;
using ContactsAPI.Backend.Repositories;
using ContactsAPI.Backend.Services;
using ContactsAPI.Shared.Models.DbModels;
using ContactsAPI.Shared.Models.DTOs;
using ContactsAPI.Shared.Models.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ContactsAPI.Backend.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ContactController(IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _contactRepository = new ContactRepository(new LiteDbService());
            _userRepository = new UserRepository(new LiteDbService());
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Get a list of contacts for a User. 
        /// <remarks>
        /// Remarks 1
        /// </remarks>
        /// </summary>
        /// <remarks>
        /// Remarks 2
        /// </remarks>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("List/{page},{pageSize}")]
        public async Task<ActionResult<IEnumerable<ContactResponse>>> Get(uint page, uint pageSize)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(UserId))
                return Unauthorized();

            if (!await _userRepository.ItemExistsAsync(UserId))
                return Unauthorized();
            
            var result = await _contactRepository.GetItemsAsync(page, pageSize, UserId);
            var finalResult = _mapper.Map<List<ContactResponse>>(result);
            return Ok(finalResult);
        }

        /// <summary>
        /// Get a Contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}", Name = "Get")]
        public async  Task<ActionResult<ContactResponse>> Get(string id)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(UserId))
                return Unauthorized();
            
            if (!await _userRepository.ItemExistsAsync(UserId))
                return Unauthorized();
            
            var result = await _contactRepository.GetItemByIdAsync(id);
            if (result.UserId != UserId)
                return Unauthorized();
            
            var finalResult = _mapper.Map<ContactResponse>(result);
            return Ok(finalResult);
        }

        /// <summary>
        /// Add a new Contact
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("AddContact")]
        public async Task<IActionResult> Post([FromBody] CreateContactDto payload)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(UserId))
                return Unauthorized();

            if (string.IsNullOrWhiteSpace(payload.Name))
                return BadRequest($"Invalid {nameof(payload.Name)}");
            
            if (string.IsNullOrWhiteSpace(payload.Phone))
                return BadRequest($"Invalid {nameof(payload.Phone)}");
            
            if (!await _userRepository.ItemExistsAsync(UserId))
                return Unauthorized();

            //Create a new instance of Contact from map
            var newContact = _mapper.Map<Contact>(payload);
            newContact.UserId = UserId;
            newContact.DateAdded = DateTime.UtcNow;
            newContact.DateUpdated = DateTime.UtcNow;
            
            //Insert Contact
            await _contactRepository.InsertItemAsync(newContact);

            return Ok($"{nameof(Contact)} Created");

        }

        /// <summary>
        /// Update Contact Phone
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        [HttpPut("SetPhone/{id}")]
        public async Task<IActionResult> SetPhone(string id, [FromBody] SetPhonePayload payload)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(UserId))
                return Unauthorized();

            if (string.IsNullOrWhiteSpace(payload.Phone))
                return BadRequest($"Invalid {nameof(payload.Phone)}");

            var existingContact = await _contactRepository.GetItemByIdAsync(id);
            if (existingContact is null)
                return BadRequest($"{nameof(Contact)} Not Found");
            
            if (existingContact.UserId != UserId)
                return Unauthorized();
            
            if (!await _userRepository.ItemExistsAsync(UserId))
                return Unauthorized();

            existingContact.Phone = payload.Phone;
            existingContact.DateUpdated = DateTime.UtcNow;
            
            //Update contact. 
            await _contactRepository.UpdateItemAsync(existingContact);

            return Ok($"{nameof(Contact)} Updated");
        }

        /// <summary>
        /// Delete a Contact by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(UserId))
                return Unauthorized();

            var existingContact = await _contactRepository.GetItemByIdAsync(id);
            if (existingContact is null)
                return BadRequest($"{nameof(Contact)} Not Found");
            
            if (existingContact.UserId != UserId)
                return Unauthorized();
            
            if (!await _userRepository.ItemExistsAsync(UserId))
                return Unauthorized();

            //Set deletion
            existingContact.IsDeleted = true;
            existingContact.DateUpdated = DateTime.UtcNow;
            existingContact.TTL = _appSettings.EntityDeleteTtlValue;
            
            //Update contact. 
            await _contactRepository.UpdateItemAsync(existingContact);

            return Ok($"{nameof(Contact)} Deleted");
        }
    }
}
