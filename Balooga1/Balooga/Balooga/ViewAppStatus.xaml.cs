using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Balooga
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewAppStatus : ContentPage
	{
		public ViewAppStatus ()
		{
			InitializeComponent ();
		}

        private void ShowPopup(object sender, EventArgs e)
        {
            DisplayAlert("Congratulations!", "You have successfully submitted your application! We will get back to you soon with a decision.", "Ok");
        }

        private async void GetAppStatus(object sender, EventArgs e)
        {
            string url = $"https://ft-jlowis1.oraclecloud2.dreamfactory.com/api/v2/sql/_table/appdata?fields=appStatus&filter=(phone={homePhone.Text})and(lastFourSSN={lastFourSSN.Text})and(zip={zipcode.Text})";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var creds = "amxvd2lzMUBhc3UuZWR1OkVhc3QyMDEz";
                    httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", creds));
                    var response = httpClient.GetStringAsync(new Uri(url)).Result;
                    var jsonData = JObject.Parse(response);

                    //await DisplayAlert("hi", jsonData["resource"].Count<JToken>().ToString(), "ok");
                    if (jsonData["resource"].Count<JToken>() == 0)
                    {
                        await DisplayAlert("Oops..", "Couldn't find your application status. Please check the information you entered.", "Ok");
                    }
                    else
                    {
                        var dbAppStatus = (string)jsonData["resource"][0]["appStatus"];
                        await DisplayAlert("App Status", $"Status of your application: {dbAppStatus}", "Ok");
                        ClearFields();
                    }
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("hi", err.ToString(), "ok");
            }
        }

        private void ClearFields()
        {
            zipcode.Text = string.Empty;
            lastFourSSN.Text = string.Empty;
            homePhone.Text = string.Empty;
        }
    }
}