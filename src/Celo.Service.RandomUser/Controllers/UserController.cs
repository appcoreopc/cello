﻿using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Celo.Service.RandomUser.ResponseUtil;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Celo.Service.RandomUser.UnitTests")]

namespace Celo.Service.RandomUser.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string UpdateActionName = "UpdateUserAsync";
        private const string DeleteActionName = "DeleteAsync";
        private const string CreatedActionName = "CreateAsync";
        private const string GetUsersAsyncText = "GetUsersAsync";
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _ilogger;
        private readonly ICreateUserService _createUserService;

        public UserController(IUserService userService, ILogger<UserController> logger, ICreateUserService createUserService) 
        => (_userService, _ilogger, _createUserService ) = (userService, logger, createUserService);
    
        [HttpGet()]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<UsersDetails>>> GetUsersAsync(UserGetRequest request) 
        {
            var result = await _userService.GetUserAsync(request);
            return Ok(result);
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateRequest request)
        {
            var updateResult = await _userService.UpdateUserAsync(request);
            return updateResult.MapResponse(GetUsersAsyncText, request);
           
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            var deleteResult = await _userService.DeleteUserAsync(userId);
            return deleteResult.MapResponse(DeleteActionName, new object{});
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [Consumes(MediaTypeNames.Application.Json)]  
        public async Task<IActionResult> CreateAsync([FromBody] UserUpdateRequest request)
        {
             var service = new CreateUserService(_userService);
             await service.CreateUserAsync();
             return CreatedAtAction(GetUsersAsyncText, request);
        }

        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT");
            return Ok();
        }
    }
}
