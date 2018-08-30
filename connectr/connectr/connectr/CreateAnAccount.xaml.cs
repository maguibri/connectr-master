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
	public partial class CreateAnAccount : ContentPage
	{
		public CreateAnAccount ()
		{
			InitializeComponent ();
		}

        void CreateButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}