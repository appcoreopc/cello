using System.Threading.Tasks;
using Celo.Data.InMemory;
using System.Linq;
using System.Collections.Generic;
using System;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Validations;
using Celo.Service.RandomUser.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Celo.Service.RandomUser.Service
{
    class UserDataProvider : IUserDataProvider
    {
        private readonly UserDataContext _context;
        private readonly ILogger<UserDataProvider> _logger;
        private readonly IQueryValidator _queryValidator = new QueryValidator();

        public UserDataProvider(UserDataContext context, ILogger<UserDataProvider> logger) => (_context, _logger) = (context, logger);

        public async Task<IEnumerable<User>> GetUserAsync(UserGetRequest request)
        {
            var validatedRequest = _queryValidator.ValidateUserQueryRequest(request);

            switch (validatedRequest.QueryRequestType)
            {
                case QueryRequestType.NameQuery:
                    return await QueryBy((user) => (user.FirstName.Contains(validatedRequest.FirstName) || user.LastName.Contains(request.LastName)), AppConstant.DefaultStartPage, request.TotalRecordRequested);

                case QueryRequestType.RandomQuery:
                    return await QueryBy((user) => true, AppConstant.DefaultStartPage, request.TotalRecordRequested);
            }

            return new List<User>();
        }

        public async Task<DataOperationStatus> UpdateUserAsync(UserUpdateRequest user)
        {
            DataOperationStatus status = DataOperationStatus.Unknown;
            try
            {
                var userExist = GetUserDetails(user.Id);

                if (userExist != null)
                {
                    var updatedUser = _context.User.Update(userExist);
                    var updateResult = await _context.SaveChangesAsync();

                    if (updateResult > 0)
                        status = DataOperationStatus.UpdateSuccess;
                }

            }
            catch (DbUpdateException dbe)
            {
                _logger.LogError(dbe.Message);
                status = DataOperationStatus.UpdateFailedError;
            }

            return status;
        }

        public async Task<DataOperationStatus> DeleteUserAsync(int userId)
        {
            DataOperationStatus status = DataOperationStatus.NoDeleteCarriedOut;

            try
            {
                var userExist = GetUserDetails(userId);

                if (userExist != null)
                {
                    var deleteUser = _context.User.Remove(userExist);
                    var deleteResult = await _context.SaveChangesAsync();

                    if (deleteResult > 0)
                        status = DataOperationStatus.UpdateSuccess;
                }
            }
            catch (DbUpdateException dbe)
            {
                _logger.LogError(dbe.Message);
                status = DataOperationStatus.DeleteFailedError;
            }

            return status;
        }

        private async Task<IEnumerable<User>> QueryBy(Func<User, bool> UserQuery, int SkipNumber, int ReturnCount)
        {
            return _context.User.Where(UserQuery).Skip(SkipNumber).Take(ReturnCount);
        }

        private User GetUserDetails(int userId)
        {
            return _context.User.SingleOrDefault(x => x.Id == userId);
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}