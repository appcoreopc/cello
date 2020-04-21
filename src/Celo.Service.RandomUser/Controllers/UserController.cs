using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Celo.Data.InMemory;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Celo.Service.RandomUser.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _ilogger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _ilogger = logger;
        }
        
        // GET api/values
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<UsersDetails>>> Get(UserGetRequest request) 
        {
            var result = await _userService.GetUserAsync(request);
            return Ok(result);
        }
        
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateRequest request)
        {
            var result = _userService.UpdateUserAsync(request);
            return CreatedAtAction("Save", result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
             var result = await _userService.DeleteUserAsync(id);
            return CreatedAtAction("Save", result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [Consumes("application/json")]     
        public async Task<IActionResult> Post([FromBody] UserUpdateRequest request)
        {
            
            await _userService.CreateUser(new 
            User()
            { 
                 Id = 1, FirstName = "test1",Last = "woo", Dob = System.DateTime.Now
            
             });

            await _userService.CreateUser(new 
            User()
            { 
                 Id = 2, FirstName = "test2",Last = "woo", Dob = System.DateTime.Now
            
             });

            await _userService.CreateUser(new 
            User()
            { 
                 Id = 3, FirstName = "test3",Last = "woo", Dob = System.DateTime.Now
            
             });

             await _userService.CreateUser(new 
            User()
            { 
                 Id = 4, FirstName = "test4",Last = "woo", Dob = System.DateTime.Now
            
             });

             await _userService.CreateUser(new 
            User()
            { 
                 Id = 5, FirstName = "test5",Last = "woo", Dob = System.DateTime.Now
            
             });

             return Ok();
            
        }

    }
}
