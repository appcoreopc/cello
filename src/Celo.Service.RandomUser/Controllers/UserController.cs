using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Service;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserControllerController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserControllerController()
        {
        }

        public UserControllerController(IUserService userService)
        {
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
