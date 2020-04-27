using System.Threading.Tasks;
using Celo.Data.InMemory;
using System.Linq;
using System.Collections.Generic;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Validations;
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
            return await ExecuteQueryAsync(validatedRequest);
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
                    var updateResult = await _context.SaveChangesAsync();

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
                    var deleteResult = await _context.SaveChangesAsync();

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

        private async Task<IEnumerable<User>> ExecuteQueryAsync(UserGetRequest request)
        {
            switch (request.QueryRequestType)
            {
                case QueryRequestType.FirstNameQuery:
                    return _context.User.Where(x => x.FirstName.Contains(request.FirstName)).Skip(request.StartPage).Take(request.TotalRecordRequested);
             
                case QueryRequestType.LastNameQuery:
                    return _context.User.Where(x => x.LastName.Contains(request.LastName)).Skip(request.StartPage).Take(request.TotalRecordRequested);
             
                case QueryRequestType.NameQuery:
                    return _context.User.Where(x => x.FirstName.Contains(request.FirstName) &&
                    x.LastName.Contains(request.LastName)).Skip(request.StartPage).Take(request.TotalRecordRequested);
             
                case QueryRequestType.RandomQuery:
                   return _context.User.Skip(request.StartPage).Take(request.TotalRecordRequested);
             
            }
            return new List<User>();;
        }
        
        private User GetUserDetails(int userId)
        {
            return _context.User.SingleOrDefault(x => x.Id == userId);
        }
    }
}