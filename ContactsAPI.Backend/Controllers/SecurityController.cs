using ContactsAPI.Backend.Interfaces;
using ContactsAPI.Backend.Repositories;
using ContactsAPI.Backend.Services;
using ContactsAPI.Shared.Models.DbModels;
using ContactsAPI.Shared.Models.DTOs;
using ContactsAPI.Shared.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Backend.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IJwtAuthentication _jwt;
        public SecurityController(IJwtAuthentication jwt)
        {
            _jwt = jwt;
            _userRepository = new UserRepository(new LiteDbService());
        }
        
         /// <summary>
        /// Login the User. 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody ]LoginRegisterPayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.UserName) || string.IsNullOrWhiteSpace(payload.Password))
                return BadRequest("Invalid Username or Password");
            
            //Normalize the UserName
            payload.UserName = payload.UserName.ToLower();

            var user = await _userRepository.GetUserByUserNameAsync(payload.UserName);
            if(user is not {})
                return BadRequest("Account does not Exist");
            
            //Verify Password
            var passwordHasher = new PasswordHasher<User>();
            var hashResult = passwordHasher.VerifyHashedPassword(user, user.Password, payload.Password);
            if(hashResult == PasswordVerificationResult.Failed)
                return BadRequest("Invalid Password");
            
            //Find the user type.
            var tokenResult = await _jwt.Authenticate(user);
            if(string.IsNullOrWhiteSpace(tokenResult.Item1))
                return BadRequest("Error Occured. Try Again");

            var response = new LoginResponse() { Token = tokenResult.Item1, ExpiryDate = tokenResult.Item2};
            return Ok(response);
        }

        /// <summary>
        /// Register a New User
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser([FromBody]LoginRegisterPayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.UserName) || string.IsNullOrWhiteSpace(payload.Password))
                return BadRequest("Invalid Username or Password");
            
            //Normalize the UserName
            payload.UserName = payload.UserName.ToLower();

            //check if the user exists already.
            if(await _userRepository.UserExistsByUserNameAsync(payload.UserName))
                return BadRequest("Account with UserName exists");

            var newUser = new User()
            {
                UserName = payload.UserName,
                DateAdded = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            //Create Password. 
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(newUser, payload.Password);

            newUser.Password = hashedPassword;

            return Ok("Account Created Successfully");
        }
    }
}
