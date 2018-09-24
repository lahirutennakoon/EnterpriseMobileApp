using EnterpriseMobileApp.Data;
using EnterpriseMobileApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnterpriseMobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentsPage : ContentPage
	{
        public ObservableCollection<Comment> CommentsList { get; }

        // Create object of DataRetriever class
        DataRetriever dataRetriever;

        public CommentsPage ()
		{
			InitializeComponent ();
		}

        public CommentsPage(Post post) : this()
        {
            Title = "Comments";
            CommentsList = new ObservableCollection<Comment>();
            CommentsListView.ItemsSource = CommentsList;

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;
            dataRetriever = new DataRetriever();

            CommentsListView.IsVisible = false;
            LoadingIndicator.IsVisible = true;

            LoadCommentsData(post.Id);
            AddToolbarItem(post.UserId);
        }

        // Add the user icon
        private void AddToolbarItem(int userId)
        {
            ToolbarItem toolbarItem = new ToolbarItem(Icon, "/Resources/drawable/userIcon.png", () =>
            {
                UserIcon_Clicked(userId);
            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }

        // Get the list of comments for the specified post id
        private async void LoadCommentsData(int PostId)
        {
            CommentsList.Clear();

            List<Comment> comments = await dataRetriever.GetCommentsForPost(PostId);

            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            CommentsListView.IsVisible = true;

            foreach (Comment c in comments)
            {
                CommentsList.Add(c);
            }
        }

        // Launch the email client
        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Comment comment = e.SelectedItem as Comment;
                string urlToLaunch = "mailto:" + comment.Email;
                Device.OpenUri(new System.Uri(urlToLaunch));
            }

            // Clear selection
            CommentsListView.SelectedItem = null;
        }

        // Go to user profile page on user icon click
        private void UserIcon_Clicked(int userId)
        {
            User user = dataRetriever.GetUserById(userId);

            UserProfilePage userProfilePage = new UserProfilePage(user);
            Navigation.PushAsync(userProfilePage);
        }
    }
}