using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EnterpriseMobileApp.Data
{
    public class Comment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public int Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "postId")]
        public string PostId { get; set; }
    }
}
