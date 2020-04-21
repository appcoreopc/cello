using System.Threading.Tasks;
using Celo.Data.InMemory;
using System.Linq;
using System.Collections.Generic;

namespace Celo.Service.RandomUser.Service
{
    class UserDataProvider : IUserDataProvider
    {
        UserDataContext _context;
        public UserDataProvider(UserDataContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            var addedTask = await _context.User.AddAsync(new User {  

                Id = "1", 
                FirstName = "Jeremy", 
                LastName = "Woo"
            }); 

            await _context.SaveChangesAsync();

            var cnt = _context.User.Count();

            var searchResult = _context.User.Select(x => x.FirstName == "Jeremy").ToArray();

            return new List<User>();

        }

         public async Task UpdateUserAsync(User user)
        {
            var addedTask = await _context.User.AddAsync(new User {  

                Id = "1", 
                FirstName = "Jeremy", 
                LastName = "Woo"
            }); 

            await _context.SaveChangesAsync();

            var cnt = _context.User.Count();

            var searchResult = _context.User.Select(x => x.FirstName == "Jeremy").ToArray();

        }

         public async Task DeleteUserAsync(User user)
        {
            var addedTask = await _context.User.AddAsync(new User {  

                Id = "1", 
                FirstName = "Jeremy", 
                LastName = "Woo"
            }); 

            await _context.SaveChangesAsync();

            var cnt = _context.User.Count();

            var searchResult = _context.User.Select(x => x.FirstName == "Jeremy").ToArray();

        }

    }
}