﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EnterpriseMobileApp.Data
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }
    }
}
