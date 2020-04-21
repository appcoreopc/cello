using System.Collections.Generic;
using Celo.Service.Models.ServiceModel.Response;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Controllers;
using Celo.Service.RandomUser.Service;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class CoreTest
    {
        public const string fakeFirstName = "fakeusername";
        public string fakeLastName = "fakeLastName";
        public int fakeTotalRequested= 10;
        public int fakeUserId = 999;
        public string fakeUserEmail = "kepung@gmail.com";
        public string fakeUserTitle = "fakeUserTitle";
        private string fakeUserFirstName = "Jeremy";
        private string fakeUserLastName = "Woo";
        private string fakeUserFirstNameMar = "Mars";
        private string fakeUserLastNameMar = "John";

        private string fakeUserFirstNameJane = "Jane";
        private string fakeUserLastNameJane = "Allan";

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
                
                Id = fakeUserId,
                Email = fakeUserEmail,
                
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

        private UsersDetails CreateUserDetails(string FirstName, string LastName)
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
     }
}