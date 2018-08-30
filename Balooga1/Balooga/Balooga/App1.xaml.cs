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
	public partial class App1 : ContentPage
	{
		public App1 ()
		{
			InitializeComponent ();
		}

        private async void OpenApp2(object sender, EventArgs e)
        {
            //await DisplayAlert("hi", User.ID, "ok");

            var fname = firstName.Text;
            var middle = midInitial.Text;
            var lname = lastName.Text;
            var suffix = this.suffix.Text;
            var birthDate = this.birthDate.Text;

            if (fname == string.Empty || middle == string.Empty || lname == string.Empty || suffix == string.Empty || birthDate == string.Empty
                || fname == null || middle == null || lname == null || suffix == null || birthDate == null)
            {
                await DisplayAlert("Oops..", "Please fill out the entire form.", "Ok");
            }
            else
            {
                string url = $"https://ft-jlowis1.oraclecloud2.dreamfactory.com/api/v2/sql/_table/appdata?filter=ID={User.ID}";
                string jsonInsertString = $"{{ \"resource\": [ {{ \"DOB\": \"{birthDate}\" }} ] }}";
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
                        await DisplayAlert("Success", "Page 1 has been completed. On to page 2..!", "Ok");
                        ClearFields();
                        await Navigation.PushAsync(new App2());
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
            firstName.Text = string.Empty;
            midInitial.Text = string.Empty;
            lastName.Text = string.Empty;
            this.suffix.Text = string.Empty;
            this.birthDate.Text = string.Empty;
        }
	}
}