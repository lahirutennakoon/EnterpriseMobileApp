using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EnterpriseMobileApp.Data
{
    public class Post
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
     
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
    }
}
