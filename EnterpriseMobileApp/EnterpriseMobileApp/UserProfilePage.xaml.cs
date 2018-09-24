using EnterpriseMobileApp.Data;
using EnterpriseMobileApp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnterpriseMobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfilePage : ContentPage
	{
		public UserProfilePage ()
		{
			InitializeComponent ();
		}

        public UserProfilePage(User user) : this()
        {
            BindingContext = user;
        }
    }
}