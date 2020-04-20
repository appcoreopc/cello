using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            System.Console.WriteLine("userService");
            _userService = userService;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> Get([FromBody] UserRequest request) {
            var result = await _userService.GetUserAsync(request);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]         
        public async Task Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Delete(int id)
        {

        }
    }
}
