using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace connectr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutYou : ContentPage
	{
		public AboutYou ()
		{
			InitializeComponent ();
		}

        void SaveButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        void ContinueButtonClicked(object sender, EventArgs args)
        {

        }
    }
}
