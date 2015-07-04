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

            AddWidget(new Widgets.TimerWidget("Tot bekendmaking winnaar", new DateTime(2015, 07, 03, 21, 15, 00)));
            AddWidget(new Widgets.CijferLijstWidget());
		}

        public void AddWidget(BaseWidget widget)
        {
            WidgetLayout.Children.Add(widget);
        }
	}
}
