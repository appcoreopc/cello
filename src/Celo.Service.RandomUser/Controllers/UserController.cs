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
        
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<UsersDetails>>> GetUsers(UserGetRequest request) 
        {
            var result = await _userService.GetUserAsync(request);
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateRequest request)
        {
            var updateResult = _userService.UpdateUserAsync(request);
            return CreatedAtAction("Save", updateResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
             var deleteResult = await _userService.DeleteUserAsync(id);
            return CreatedAtAction("Save", deleteResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [Consumes(MediaTypeNames.Application.Json)]  
        public async Task<IActionResult> CreateAsync([FromBody] UserUpdateRequest request)
        {
             var service = new CreateUserService(_userService);
             await service.CreateUserAsync();
             return Ok();
        }
    }
}
