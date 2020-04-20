namespace Celo.Service.Models.ServiceModels.Request
{
    public class UserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint StartPage { get; set; }
        public uint PageSize { get; set; }
    }
}