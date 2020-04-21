using System.Threading.Tasks;
using Celo.Data.InMemory;

namespace Celo.Service.RandomUser.Service
{
    public class CreateUserService
    {
       
        private readonly UserDataContext _context;
     
        public CreateUserService(UserDataContext context) => _context = context;


        public async Task CreateUserAsync(User user)
        {
             await _context.User.AddAsync(user);
             await _context.SaveChangesAsync();
        }
    }
}