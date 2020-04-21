using System.Collections.Generic;
using Celo.Data.InMemory;
using Celo.Service.Models.ServiceModels;
using System.Linq;

namespace Celo.Service.RandomUser.ResponseUtil
{
    public static class UserDetailsMapper
    {
        public static IEnumerable<UsersDetails> MapToUserDetails(this IEnumerable<User> users)
        {
            return (from item in users
                    select item.MapElementToUserDetails()).ToList();
        }

        public static UsersDetails MapElementToUserDetails(this User user)
        {
            return new UsersDetails
            {
                Id = user.Id,
                Email = user.Email,
                Name = new Name
                {
                    First = user.FirstName,
                    Last = user.LastName,
                    Title = user.Title
                },
                Phone = user.Phone,
                Picture = new Picture
                {
                    Large = user.LargePictureUrl,
                    Medium = user.MediumPictureUrl,
                    Thumbnail = user.ThumbNail
                },
                Dob = new DateofBirth
                {
                    Date = user.Dob,
                    Age = user.Age
                }
            };
        }

    }
}