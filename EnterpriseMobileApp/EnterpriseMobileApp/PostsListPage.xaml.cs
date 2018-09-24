using EnterpriseMobileApp.Data;
using EnterpriseMobileApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnterpriseMobileApp
{
    public partial class PostsListPage : ContentPage
    {
        public ObservableCollection<Post> PostsList { get; }

        // Create object of DataRetriever class
        DataRetriever dataRetriever;

        public PostsListPage()
        {
            InitializeComponent();

            Title = "Posts";
            PostsList = new ObservableCollection<Post>();
            PostsListView.ItemsSource = PostsList;
            
            PostsListView.ItemSelected += PostsListView_ItemSelected;

            dataRetriever = new DataRetriever();

            PostsListView.IsVisible = false;
            LoadingIndicator.IsVisible = true;

            // Load all the posts
            LoadPostsData();
        }

        // Navigate to the comments page when a post is selected
        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentsPage commentsPage = new CommentsPage(e.SelectedItem as Post);
                Navigation.PushAsync(commentsPage);
            }

            // Clear the selection
            PostsListView.SelectedItem = null;
        } 

        private async Task LoadPostsData()
        {
            PostsList.Clear();

            // Get the posts
            List<Post> posts = await dataRetriever.GetPosts();

            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            PostsListView.IsVisible = true;

            // Add each post to the list
            foreach (Post p in posts)
            {
                PostsList.Add(p);
            }
        }
    }

   
}
