using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Balooga
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FinancialInfo : ContentPage
	{
		public FinancialInfo ()
		{
			InitializeComponent ();
		}

        private async void OpenViewAppStatus(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewAppStatus());
        }
    }
}