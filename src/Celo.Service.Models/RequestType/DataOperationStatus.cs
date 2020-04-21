namespace Celo.Service.Models.ServiceModels.Request
{
    public enum DataOperationStatus
    {
        Unknown = 0,

        DeleteSuccess = 1,

        DeleteFailedError = 2,

        NoDeleteCarriedOut = 3,

        UpdateSuccess = 4,

        UpdateFailedError = 5,

        NoUpdateCarriedOut = 6,

    }
}