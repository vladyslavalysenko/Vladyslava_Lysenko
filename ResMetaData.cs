using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HW_API
{
    public class DeleteFileMetaData
    {
        public MetaData metadata { get; set; }
    }

    public class MetaData
    {
        [JsonPropertyName(".tag")]
        public string tag { get; set; }
        public DateTime client_modified { get; set; }
        public string content_hash { get; set; }
        public bool has_explicit_shared_members { get; set; }
        public string id { get; set; }
        public bool is_downloadable { get; set; }
        public string name { get; set; }
        public string path_display { get; set; }
        public string path_lower { get; set; }
        public string rev { get; set; }
        public DateTime server_modified { get; set; }
        public int size { get; set; }
    }
}
