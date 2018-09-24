using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseMobileApp.Data;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseMobileApp.Net
{
    public class DataRetriever
    {
        public DataRetriever()
        {
        }

        // Get all the posts
        public async Task<List<Post>> GetPosts()
        {
            List<Post> posts = new List<Post>();

            using (WebClient webClient = new WebClient())
            {
                string json = await webClient.DownloadStringTaskAsync("https://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(json))
                {
                    // Deserialize the JSON objects
                    posts = JsonConvert.DeserializeObject<Post[]>(json).ToList();
                }            
            }

            return posts;
        }

        // Get all the comments for a specific post
        public async Task<List<Comment>> GetCommentsForPost(int PostId)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient webClient = new WebClient())
            {
                string json = await webClient.DownloadStringTaskAsync("https://jsonplaceholder.typicode.com/comments?postId=" + PostId);

                if (!string.IsNullOrEmpty(json))
                {
                    // Deserialize the JSON objects
                    comments = JsonConvert.DeserializeObject<Comment[]>(json).ToList();
                }
            }

            return comments;
        }

        // Get user details
        public User GetUserById(int userId)
        {
            User user = new User();

            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString("https://jsonplaceholder.typicode.com/users/" + userId);

                if (!string.IsNullOrEmpty(json))
                {
                    // Deserialize the JSON object
                    user = JsonConvert.DeserializeObject<User>(json);
                }
            }

            return user;
        }
    }
}
