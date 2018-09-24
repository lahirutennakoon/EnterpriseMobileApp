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
            Console.WriteLine("abcd");
            PostsListView.ItemSelected += PostsListView_ItemSelected;

            dataRetriever = new DataRetriever();
            AddToolbarItem();
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

        private void AddToolbarItem()
        {
            ToolbarItem toolbarItem = new ToolbarItem("Sync", null, () =>
            {
                LoadPostsData();
            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }

        private void LoadPostsData()
        {
            PostsList.Clear();

            List<Post> posts = dataRetriever.GetPosts();
            foreach (Post p in posts)
            {
                Console.WriteLine("Welcome to the C# Station Tutorial!");
                PostsList.Add(p);
            }
        }
    }

   
}
