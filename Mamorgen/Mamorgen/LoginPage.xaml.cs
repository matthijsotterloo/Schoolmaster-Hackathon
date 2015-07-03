using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mamorgen
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            loginButton.Clicked += LogIn;
		}

        private void LogIn(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new WidgetPage(), this);
            Navigation.PopAsync(true);
        }
    }
}

