using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.RandomUser.Service;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserControllerController : ControllerBase
    {
        private readonly UserService _userService;

        public UserControllerController()
        {
        }

        public UserControllerController(UserService userService)
        {
            _userService = userService;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
        {
            return new List<UserResponse>() { 
                new UserResponse()
            };
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {

        }
    }
}
