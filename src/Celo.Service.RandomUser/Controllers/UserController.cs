using System.Collections.Generic;
using System.Threading.Tasks;
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
        [Consumes("application/json")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> Get([FromBody] UserGetRequest request) {
            _ilogger.LogInformation("GetUserService");
            var result = await _userService.GetUserAsync(request);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [Consumes("application/json")]     
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok("");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateRequest request)
        {
            return CreatedAtAction("Save", request);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {

            return await Task.FromResult(NoContent());// if unsuccessful;


        }
    }
}
