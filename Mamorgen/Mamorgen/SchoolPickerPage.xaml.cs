using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading;

namespace Mamorgen
{
	public partial class SchoolPickerPage : ContentPage
	{
		public SchoolPickerPage (LoginPage page)
		{
			InitializeComponent ();

			SynchronizationContext context = SynchronizationContext.Current;
			Search.SearchButtonPressed += (object sender, EventArgs e) => {
				Magister.GetSchools(Search.Text).ContinueWith(a => {
					var schools = a.Result;
					context.Post((b) => {
						Results.ItemsSource = schools;
					}, null);
				});
			};

			var SchoolTemplate = new DataTemplate (typeof(Xamarin.Forms.TextCell));
			SchoolTemplate.SetValue (TextCell.TextColorProperty, "White");
			SchoolTemplate.SetValue (TextCell.DetailColorProperty, "White");
			SchoolTemplate.SetBinding (TextCell.TextProperty, new Binding ("Name"));
			SchoolTemplate.SetBinding (TextCell.DetailProperty, new Binding ("Url"));
			Results.ItemTemplate = SchoolTemplate;

			Results.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				page.SelectSchool((Magister.School)e.Item);
				Navigation.PopModalAsync();
			};
		}
	}
}

