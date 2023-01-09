using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_API
{
    public static class Requests
    {
        public static RestRequest BuildGetRequest(string filePath)
        {
            var request = new BuildReq()
               .SetUrl(Client.GetMetaDataUrl)
               .SetHeader("Content-Type", "application/json")
               .SetBody<object>(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = filePath })
               .Build();

            return request;
        }

        public static RestRequest BuildPostRequest(string localFilePath)
        {
            var request = new BuildReq()
                .SetUrl(Client.UploadFileUrl)
                .SetHeader("Dropbox-API-Arg", "{\"path\":\"/file.txt\"}")
                .SetHeader("Content-Type", "application/octet-stream")
                .SetFile(localFilePath)
                .Build();

            return request;
        }

        public static RestRequest BuildDeleteRequest(string filePath)
        {
            var request = new BuildReq()
                .SetUrl(Client.DeleteFileUrl)
                .SetHeader("Content-Type", "application/json")
                .SetBody<object>(new { path = filePath })
                .Build();

            return request;
        }
    }
}
