using System.Collections.Generic;
using Celo.Service.Models.ServiceModels;

namespace Celo.Service.Models.ServiceModel.Response
{
    public class UserResponse
    {
        public IEnumerable<UsersDetails> Users { get; set; }

    }
}
