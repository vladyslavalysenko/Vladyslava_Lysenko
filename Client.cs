using RestSharp;

namespace HW_API
{
    public class Client
    {
        private readonly RestClient client;

        public static readonly string BaseUrl = "https://api.dropboxapi.com/";

        public static readonly string GetMetaDataUrl = "https://api.dropboxapi.com/2/files/get_metadata";

        public static readonly string DeleteFileUrl = "https://api.dropboxapi.com/2/files/delete_v2";

        public static readonly string UploadFileUrl = "https://content.dropboxapi.com/2/files/upload";

        public static readonly string GeneratedToken = "sl.BWMihUzoo5Xfgguq9yabsAwPCVgCK_3_Vx3WOeMEhktos_fTa71vC-EvQJ_eJd8La6J7e_Y5p1lBZlvyIrSqH0GFiWCVZqwwDEhRTwUZT-R1pZu-irFRocbSkEJkTjoTo3OlNCI";


        public Client()
        {
            var options = new RestClientOptions("https://content.dropboxapi.com/2");
            client = new RestClient(options);
            client.AddDefaultHeader("Authorization", "Bearer" + " " + GeneratedToken);
        }

        public async Task<RestResponse<MetaData>> GetFileMetadata(string filePath)
        {
            var request = Requests.BuildGetRequest(filePath);

            var response = await client.ExecutePostAsync<MetaData>(request);

            return response;
        }

        public async Task<RestResponse<DeleteFileMetaData>> DeleteFile(string filePath)
        {
            var request = Requests.BuildDeleteRequest(filePath);

            var response = await client.ExecutePostAsync<DeleteFileMetaData>(request);

            return response;
        }

        public async Task<RestResponse<MetaData>> UploadFile(string localFilePath)
        {
            var request = Requests.BuildPostRequest(localFilePath);

            var response = await client.ExecutePostAsync<MetaData>(request);

            return response;
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
