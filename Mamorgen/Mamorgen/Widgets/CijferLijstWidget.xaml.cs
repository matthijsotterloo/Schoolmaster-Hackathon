using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Mamorgen.Widgets
{
	public partial class CijferLijstWidget : BaseWidget
	{

        public struct CijferInfo
        {
            public string Cijfer
            {
                get;
                set;
            }

            public string Vak
            {
                get;
                set;
            }

            public string Datum
            {
                get;
                set;
            }
        }
		public CijferLijstWidget()
		{
			InitializeComponent ();

            CijferLijst.ItemsSource = new List<CijferInfo>()
            {
                new CijferInfo() { Cijfer = "7,6",  Vak = "Aardrijkskunde", Datum = "do 3 juli 10:09" }
            };
		}
	}
}
