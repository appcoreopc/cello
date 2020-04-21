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
        //[Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        //public async Task<ActionResult<IEnumerable<UsersDetails>>> Get([FromBody] UserGetRequest request) 
        public async Task<ActionResult<IEnumerable<UsersDetails>>> Get(UserGetRequest request) 
        {
            var result = await _userService.GetUserAsync(request);
            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [Consumes("application/json")]     
        public async Task<IActionResult> Post([FromBody] UserUpdateRequest request)
        {
            var service = new CreateUserService(new Data.InMemory.UserDataContext());
            await service.CreateUserAsync(new 
            User()
            { 
                 Id = 1, FirstName = "test",Last = "woo", Dob = System.DateTime.Now
            
             });

             return Ok();
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateRequest request)
        {
            var result = _userService.UpdateUserAsync(request);
            return CreatedAtAction("Save", result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
             var result = await _userService.DeleteUserAsync(id);
            return CreatedAtAction("Save", result);
            
        }
    }
}
