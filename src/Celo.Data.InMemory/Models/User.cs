using System;

namespace Celo.Data.InMemory
{
    public class User
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string LargePictureUrl { get; set; }

         public string MediumPictureUrl { get; set; }

        public string ThumbNail { get; set; }

        public uint Age { get; set; }

    }

}