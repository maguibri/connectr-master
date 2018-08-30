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
	public partial class App2 : ContentPage
	{
		public App2 ()
		{
			InitializeComponent ();
		}

        private async void OpenApp3(object sender, EventArgs e)
        {
            var address = this.address.Text;
            var apt = aptNum.Text;
            var city = this.city.Text;
            var state = this.state.Text;
            var zip = this.zip.Text;
            var phone = phoneNumber.Text;

            if (address == string.Empty || city == string.Empty || state == string.Empty || zip == string.Empty || phone == string.Empty
                || address == null || city == null || state == null || zip == null || phone == null)
            {
                await DisplayAlert("Oops..", "Please fill out the required fields: \n\nAddress\nCity\nState\nZip\nPhone Number", "Ok");
            }
            else
            {
                string url = $"https://ft-jlowis1.oraclecloud2.dreamfactory.com/api/v2/sql/_table/appdata?filter=ID={User.ID}";
                string jsonInsertString = $"{{ \"resource\": [ {{ \"address\": \"{address}\", \"city\": \"{city}\", \"state\": \"{state}\", \"zip\": \"{zip}\", \"phone\": \"{phone}\" }} ] }}";
                //await DisplayAlert("hi", jsonInsertString, "ok");
                var jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonInsertString);
                var jsonContent = new ByteArrayContent(jsonBytes);
                jsonContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var creds = "amxvd2lzMUBhc3UuZWR1OkVhc3QyMDEz";
                        httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", creds));
                        var response = httpClient.PutAsync(new Uri(url), jsonContent).Result;
                        //await DisplayAlert("hi", response.ToString(), "Ok");
                        await DisplayAlert("Success", "Page 2 has been completed. On to page 3..!", "Ok");
                        ClearFields();
                        await Navigation.PushAsync(new App3());
                    }
                }
                catch (Exception err)
                {
                    await DisplayAlert("hi", err.ToString(), "ok");
                }
            }

        }

        private void ClearFields()
        {
            address.Text = string.Empty;
            aptNum.Text = string.Empty;
            city.Text = string.Empty;
            state.Text = string.Empty;
            zip.Text = string.Empty;
            phoneNumber.Text = string.Empty;
        }
    }
}