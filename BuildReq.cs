using RestSharp;

namespace HW_API
{
    internal class BuildReq
    {
        private RestRequest request;

        public BuildReq SetUrl(string url)
        {
            request = new RestRequest(url, Method.Post);
            return this;
        }

        public BuildReq SetHeader(string key, string value)
        {
            request.AddHeader(key, value);
            return this;
        }


        public BuildReq SetBody<T>(T body) where T : class
        {
            request.AddJsonBody(body);
            return this;
        }

        public BuildReq SetFile(string filePath)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            request.AddParameter("application/octet-stream", fileData, ParameterType.RequestBody);
            return this;
        }

        public RestRequest Build()
        {
            return request;
        }

    }
}
