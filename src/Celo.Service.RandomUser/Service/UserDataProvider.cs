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
using Celo.Service.RandomUser.ResponseUtil;

namespace Celo.Service.RandomUser.Service
{
    class UserDataProvider : IUserDataProvider
    {
        private const int DbOperationRecordAffected = 0;
        private readonly UserDataContext _context;
        private readonly ILogger<UserDataProvider> _logger;
        private readonly IQueryValidator _queryValidator;

        public UserDataProvider(UserDataContext context, ILogger<UserDataProvider> logger, IQueryValidator  validator)
         => (_context, _logger, _queryValidator) = (context, logger, validator);

        public async Task<IEnumerable<User>> GetUserAsync(UserGetRequest request)
        {
            var validatedRequest = _queryValidator.ValidateUserQueryRequest(request);
            IEnumerable<User> resultset = null; 

            switch (validatedRequest.QueryRequestType)
            {
                case QueryRequestType.NameQuery:
                    resultset =  await QueryBy((user) => (user.FirstName.Contains(validatedRequest.FirstName) 
                    || user.LastName.Contains(request.LastName)), AppConstant.DefaultStartPage, 
                    request.TotalRecordRequested);
                    break;

                case QueryRequestType.RandomQuery:
                    resultset = await QueryBy((user) => true, 
                    AppConstant.DefaultStartPage, request.TotalRecordRequested);
                    break;
            }

            return resultset ?? new List<User>();
        }

        public async Task<DataOperationStatus> UpdateUserAsync(UserUpdateRequest user)
        {
            DataOperationStatus status = DataOperationStatus.Unknown;
            try
            {
                var userExist = GetUserDetails(user.Id);

                if (userExist != null)
                {
                    var modifiedUser = user.MapElementToUserDataObject(userExist);
                    var updatedUser = _context.User.Update(modifiedUser);
                    var updateResult = await _context.SaveChangesAsync().ConfigureAwait(false);

                    if (updateResult > DbOperationRecordAffected)
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
                    var deleteResult = await _context.SaveChangesAsync().ConfigureAwait(false);

                    if (deleteResult > DbOperationRecordAffected)
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

         ////////////////////////////////////////////////////////////////////
        ///  For generating some fake data purposes
        ////////////////////////////////////////////////////////////////////
        public async Task CreateUserAsync(User user)
        {
            await _context.User.AddAsync(user).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task<IEnumerable<User>> QueryBy(Func<User, bool> UserQuery, int SkipNumber, int ReturnCount)
        {
            return _context.User.Where(UserQuery).Skip(SkipNumber).Take(ReturnCount);
        }
        
        private User GetUserDetails(int userId)
        {
            return _context.User.SingleOrDefault(x => x.Id == userId);
        }
    }
}