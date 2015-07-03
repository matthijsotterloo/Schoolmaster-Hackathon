using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mamorgen
{
	public class WidgetPage : ContentPage
	{
        private StackLayout WidgetLayout;

        public WidgetPage ()
		{
			Content = WidgetLayout = new StackLayout {
				Children = {},
                Padding = new Thickness(20),
                Spacing = 20
			};

            AddWidget(new Widgets.TimerWidget(new DateTime(2015, 07, 03, 17, 00, 00)));
		}

        public void AddWidget(BaseWidget widget)
        {
            WidgetLayout.Children.Add(widget);
        }
	}
}
