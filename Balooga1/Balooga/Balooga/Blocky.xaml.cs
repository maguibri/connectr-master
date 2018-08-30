using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Balooga
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Blocky : ContentPage
	{
		public Blocky ()
		{
			InitializeComponent ();
            NavigationPage.SetTitleIcon(this, "connectrAlpha.png");
        }

        private async void GotoAccountPage(object sender, EventArgs e)
        {
            //DisplayAlert("Title", "working method", "Ok");
            //AccountPage accountPage = new AccountPage();
            await Navigation.PushAsync(new AccountPage());
        }

        private async void Login(object sender, EventArgs e)
        {
            string url = $"https://ft-jlowis1.oraclecloud2.dreamfactory.com/api/v2/sql/_table/appdata?fields=username,password,ID&filter=username={username.Text}";

            try
            {
                //var data = await url.GetJsonAsync();
                //await DisplayAlert("hi", data, "ok");
                //Console.Out.WriteLine(data);

                using (var httpClient = new HttpClient())
                {
                    var creds = "amxvd2lzMUBhc3UuZWR1OkVhc3QyMDEz";
                    httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", creds));
                    var response = httpClient.GetStringAsync(new Uri(url)).Result;
                    var data = JsonConvert.DeserializeObject(response);
                    var data2 = JObject.Parse(response);

                    //await DisplayAlert("hi", data2["resource"].Count<JToken>().ToString(), "ok");
                    if (data2["resource"].Count<JToken>() == 0)
                    {
                        await DisplayAlert("Oops..", "Couldn't log you in. Please check your username and password.", "Ok");
                    }
                    else
                    {
                        var dbPassword = (string)data2["resource"][0]["password"];
                        //await DisplayAlert("hi", dbPassword, "ok");
                        if (password.Text == dbPassword)
                        {
                            await DisplayAlert("Success", "Successfully logged in!", "Ok");
                            //await DisplayAlert("Success", (string)data2["resource"][0]["ID"], "Ok");
                            User.ID = ((string)data2["resource"][0]["ID"]);
                            //await DisplayAlert("hi", User.ID, "ok");
                            username.Text = string.Empty;
                            password.Text = string.Empty;
                            await Navigation.PushAsync(new App1());
                        }
                        else
                        {
                            await DisplayAlert("Uh oh..", "Incorrect username or password.", "Ok");
                        }
                    }
                    //var data4 = JArray.Parse(response);

                    //await DisplayAlert("hi", response, "ok");
                    //await DisplayAlert("hi", data.ToString(), "ok");
                    //await DisplayAlert("hi", data2.ToString(), "ok");
                    //await DisplayAlert("hi", data3, "ok");
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("hi", err.ToString(), "ok");
            }
        }

        private async void GotoAppStatusPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewAppStatus());
        }
    }
}