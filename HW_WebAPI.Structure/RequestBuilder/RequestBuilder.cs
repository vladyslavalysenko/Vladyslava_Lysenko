using System;
using System.IO;
using RestSharp;
using HW_WebAPI.Structure.Constants;
using static System.Net.Mime.MediaTypeNames;

namespace HW_WebAPI.Structure.RequestBuilder
{
	public class RequestBuilder
	{
		private RestRequest request;

		public RequestBuilder SetUrl(string url)
		{
			request = new RestRequest(url, Method.Post);
			return this;
        }

        public RequestBuilder SetHeader(string key, string value)
		{
            request.AddHeader(key, value);
            return this;
        }


        public RequestBuilder SetBody<T>(T body) where T : class
		{
			request.AddJsonBody(body);
            return this;
        }

        public RequestBuilder SetFile(string filePath)
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

