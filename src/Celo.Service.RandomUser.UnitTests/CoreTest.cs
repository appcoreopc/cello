using System.Collections.Generic;
using Celo.Data.InMemory;
using Celo.Service.Models.ServiceModel.Response;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Controllers;
using Celo.Service.RandomUser.Service;
using Celo.Service.RandomUser.UnitTests.Controllers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.UnitTests
{
    public class CoreTest
    {
        public const string fakeFirstName = "fakeFirstName";
        public string fakeLastName = "fakeLastName";
        public int fakeTotalRequested= 10;
        public int fakeUserId = 999;
        public string fakeUserEmail = "kepung@gmail.com";
        public string fakeUserTitle = "fakeUserTitle";
        public string fakeUserFirstName = "Jeremy";
        public string fakeUserLastName = "Woo";
        public string fakeUserFirstNameMar = "Mars";
        public string fakeUserLastNameMar = "John";

        public string fakeUserFirstNameJane = "Jane";
        public string fakeUserLastNameJane = "Allan";

        protected ControllerTestInstance CreateInstance()
        {
            return new ControllerTestInstance
            {
                LoggerInstance = Substitute.For<ILogger<UserController>>(),
                UserService = Substitute.For<IUserService>()
            };
        }

        protected UserGetRequest FakeUserGetRequest() 
        {
            return new UserGetRequest {
                
                FirstName = fakeFirstName, 
                LastName  = fakeLastName,
                TotalRecordRequested = fakeTotalRequested
            };
        }

        protected UserUpdateRequest FakeUserUpdateRequest() 
        {
            return new UserUpdateRequest {
                
                FirstName = fakeFirstName, 
                LastName  = fakeLastName,
                Email = fakeUserEmail
            };
        }

        protected UserResponse GetArrayUserResponse() 
        {
            return new UserResponse
            { 
                Users = new List<UsersDetails> {
                    this.CreateUserDetails(fakeUserFirstName, fakeUserLastName),
                    this.CreateUserDetails(fakeUserFirstNameMar, fakeUserLastNameMar),
                    this.CreateUserDetails(fakeUserFirstNameJane, fakeUserLastNameJane),
                    this.CreateUserDetails(fakeUserFirstName, fakeUserLastName)
                }
            };
        }

        protected UserResponse GetSingleUserResponse() 
        {
            return new UserResponse
            { 
                Users = new List<UsersDetails> {
                    this.CreateUserDetails(fakeUserFirstName, fakeUserLastName)
                }
            };
        }

        protected UserResponse GetUserResponse() 
        {
            return new UserResponse
            { 
                Users = new List<UsersDetails> {
                    this.CreateUserDetails(fakeUserFirstName, fakeUserLastName)
                }
            };
        }

        protected IEnumerable<User> GetFakeDatabaseUserData() 
        {
            return new List<User>
            {
                this.CreateDatabaseUserData(fakeFirstName, fakeLastName),
                this.CreateDatabaseUserData(fakeUserFirstNameMar, fakeUserLastNameMar)
            };
        }

        protected IEnumerable<User> GetFakeSingleDatabaseUserData() 
        {
            return new List<User>
            {
                this.CreateDatabaseUserData(fakeFirstName, fakeLastName)
            };
        }

        protected UsersDetails CreateUserDetails(string FirstName, string LastName)
        {
            return new UsersDetails { 

                Email = fakeUserEmail, 
                Name = new Name {
                    First = FirstName, 
                    Last = LastName,
                    Title = fakeUserTitle
                }
            };
        }

        protected IEnumerable<UsersDetails> GetUserDetailsList()
        {
           return new List<UsersDetails>() {
               CreateUserDetails(fakeUserFirstName, fakeUserLastName),
               CreateUserDetails(fakeUserFirstNameJane, fakeUserLastNameJane),
           };
        }

         protected IEnumerable<UsersDetails> GetEmptyUserDetailsList()
        {
           return new List<UsersDetails>();
        }

        protected ActionResult<IEnumerable<UsersDetails>> GetActionResultUserDetailsList()
        {
           var result = new List<UsersDetails>() {
               CreateUserDetails(fakeUserFirstName, fakeUserLastName),
               CreateUserDetails(fakeUserFirstNameJane, fakeUserLastNameJane),
           };

           return new OkObjectResult(result);
        }

        private User CreateDatabaseUserData(string UserFirstName, string UserLastName) 
        {    
            return new User {
                Email = fakeUserEmail,
                LastName = UserLastName,
                FirstName = UserFirstName
            };
        }
     }
}