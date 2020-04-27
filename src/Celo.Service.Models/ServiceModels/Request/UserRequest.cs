namespace Celo.Service.Models.ServiceModels.Request
{
    public class UserGetRequest
    {
        public QueryRequestType QueryRequestType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartPage { get; set; }
        public int TotalRecordRequested { get; set; }
    }
}