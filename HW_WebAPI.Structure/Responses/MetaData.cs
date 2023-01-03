﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAPI.Structure.Responses
{
    public class MetaData
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string path_lower { get; set; }
        public string path_display { get; set; }
        public string id { get; set; }
        public DateTime client_modified { get; set; }
        public DateTime server_modified { get; set; }
        public string rev { get; set; }
        public int size { get; set; }
        public bool is_downloadable { get; set; }
        public string content_hash { get; set; }
    }
}
