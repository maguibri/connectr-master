using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Balooga
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPage : ContentPage
	{
        public AccountPage ()
		{
			InitializeComponent ();
            NavigationPage.SetTitleIcon(this, "connectrAlpha.png");
        }

        private async void CreateAccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new App1());
        }

        private async void CreateAccountt(object sender, EventArgs e)
        {
            var username = this.username.Text;
            var pass1 = password.Text;
            var pass2 = password2.Text;
            var email1 = this.email.Text;
            var email2 = this.email2.Text;
            var fname = this.fname.Text;
            var lname = this.lname.Text;

            if (email1 != email2 || pass1 != pass2)
            {
                await DisplayAlert("Oops..", "Emails or passwords do not match!", "Ok");
            }
            else if (username == string.Empty || pass1 == string.Empty || email1 == string.Empty || fname == string.Empty || lname == string.Empty
                || username == null || pass1 == null || email1 == null || fname == null || lname == null)
            {
                await DisplayAlert("Oops..", "Please fill out the entire form.", "Ok");
            }
            else
            {
                string url = $"https://ft-jlowis1.oraclecloud2.dreamfactory.com/api/v2/sql/_table/appdata";
                string jsonInsertString = $"{{ \"resource\": [ {{ \"username\": \"{username}\", \"password\": \"{pass1}\", \"email\": \"{email1}\", \"firstName\": \"{fname}\", \"lastName\": \"{lname}\" }} ] }}";
                //var jsonObject = JObject.Parse(jsonInsertString);
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
                        var response = httpClient.PostAsync(new Uri(url), jsonContent).Result;
                        //var response = httpClient.GetStringAsync(new Uri(url)).Result;
                        //await DisplayAlert("hi", response.ToString(), "Ok");
                        await DisplayAlert("Success", "Congratulations! Your account has been created. You'll now be taken to the login screen.", "Ok");
                        ClearFields();
                        await Navigation.PushAsync(new Blocky());
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
            username.Text = string.Empty;
            email.Text = string.Empty;
            email2.Text = string.Empty;
            password.Text = string.Empty;
            password2.Text = string.Empty;
            fname.Text = string.Empty;
            lname.Text = string.Empty;
        }
    }
}