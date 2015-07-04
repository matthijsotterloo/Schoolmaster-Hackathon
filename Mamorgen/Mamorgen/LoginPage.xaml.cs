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
			schoolSelect.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushModalAsync(new SchoolPickerPage(this), true);
			};
		}

        private void LogIn(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new WidgetPage(), this);
            Navigation.PopAsync(true);
        }

        public string apiEndpoint;

		public void SelectSchool(Magister.School school)
		{
            apiEndpoint = school.Url + "/api";
            schoolName.Text = school.Name;
		}
    }
}

