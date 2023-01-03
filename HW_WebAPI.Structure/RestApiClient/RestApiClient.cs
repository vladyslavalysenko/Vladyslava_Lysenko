using System;
using RestSharp;
using HW_WebAPI.Structure.Responses;
using HW_WebAPI.Structure.Services;

namespace HW_WebAPI.Structure.RestApiClient
{
    public class RestApiClient 
    {
        private readonly RestClient client;

        public RestApiClient()
        {
            var options = new RestClientOptions("https://content.dropboxapi.com/2");

            client = new RestClient(options)
            {

            };

            client.AddDefaultHeader("Authorization", Constants.Constants.TokenType + " " + Constants.Constants.GeneratedToken);
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
            GC.SuppressFinalize(this);
        }
    }
}

