using System;
using Microsoft.EntityFrameworkCore;

namespace Celo.Data.InMemory
{
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

}