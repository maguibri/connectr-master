using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace connectr
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void JoinButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CreateAnAccount());
        }

        void LoginButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new AboutYou());
        }
    }
}
