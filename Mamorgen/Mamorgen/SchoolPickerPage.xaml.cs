using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading;

namespace Mamorgen
{
	public partial class SchoolPickerPage : ContentPage
	{
        public DateTime _PreviousGet;
        private SynchronizationContext _Context;
		public SchoolPickerPage (LoginPage page)
		{
			InitializeComponent ();

            _Context = SynchronizationContext.Current;
            Search.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if ((DateTime.Now - _PreviousGet).TotalSeconds < 4 && Search.Text.Length > 3)
                {
                    GetSchoolData();
                    _PreviousGet = DateTime.Now;
                }
            };

			Search.SearchButtonPressed += (object sender, EventArgs e) => {
                GetSchoolData();
                _PreviousGet = DateTime.Now;
			};

			var SchoolTemplate = new DataTemplate (typeof(Xamarin.Forms.TextCell));
			SchoolTemplate.SetBinding (TextCell.TextProperty, new Binding ("Name"));
			SchoolTemplate.SetBinding (TextCell.DetailProperty, new Binding ("Url"));
			Results.ItemTemplate = SchoolTemplate;

			Results.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				page.SelectSchool((Magister.School)e.Item);
				Navigation.PopModalAsync();
			};
		}

        public void GetSchoolData()
        {
            Magister.GetSchools(Search.Text).ContinueWith(a => {
                var schools = a.Result;
                _Context.Post((b) => {
                    Results.ItemsSource = schools;
                }, null);
            });
        }
	}
}

