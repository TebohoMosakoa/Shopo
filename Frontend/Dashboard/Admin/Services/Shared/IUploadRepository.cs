namespace Admin.Services.Shared
{
    public interface IUploadRepository
    {
        Task<string> UploadImage(MultipartFormDataContent content);
    }
}
