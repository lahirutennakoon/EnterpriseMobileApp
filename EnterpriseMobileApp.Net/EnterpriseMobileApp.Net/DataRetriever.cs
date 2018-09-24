using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseMobileApp.Data;
using System.Net;
using Newtonsoft.Json;
using System.Linq;

namespace EnterpriseMobileApp.Net
{
    public class DataRetriever
    {
        public DataRetriever()
        {
        }

        // Get all the posts
        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(json))
                {
                    posts = JsonConvert.DeserializeObject<Post[]>(json).ToList();
                }            
            }

            return posts;
        }

        // Get all the comments for a specific post
        public List<Comment> GetCommentsForPost(int PostId)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString("https://jsonplaceholder.typicode.com/comments?postId=" + PostId);

                if (!string.IsNullOrEmpty(json))
                {
                    comments = JsonConvert.DeserializeObject<Comment[]>(json).ToList();
                }
            }

            return comments;
        }

        // Get user details by email
        public User GetUserByEmail(string email)
        {
            User user = new User();

            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString("https://jsonplaceholder.typicode.com/users?email=" + email);

                if (!string.IsNullOrEmpty(json))
                {
                    user = JsonConvert.DeserializeObject<User>(json);
                }
            }

            return user;
        }
    }
}
