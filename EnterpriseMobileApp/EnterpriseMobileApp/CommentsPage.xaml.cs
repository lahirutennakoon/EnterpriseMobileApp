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

            dataRetriever = new DataRetriever();
            AddToolbarItem(post.Id);
        }

        private void AddToolbarItem(int PostId)
        {
            ToolbarItem toolbarItem = new ToolbarItem("Sync", null, () =>
            {
                LoadCommentsData(PostId);
            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }

        // Get the list of comments for the specified post id
        private void LoadCommentsData(int PostId)
        {
            CommentsList.Clear();

            List<Comment> comments = dataRetriever.GetCommentsForPost(PostId);
            foreach (Comment c in comments)
            {
                CommentsList.Add(c);
            }
        }
    }
}