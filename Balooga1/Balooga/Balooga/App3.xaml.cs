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
	public partial class App3 : ContentPage
	{
		public App3 ()
		{
			InitializeComponent ();
		}

        private async void OpenFinancialInfo(object sender, EventArgs e)
        {
            var motherMName = this.mMaidenName.Text;
            var ssn = this.ssn.Text;
            var yearsThere = housedYears.Text;
            var ownVRent = houseStatus.Text;
            var payment = monthlyPayment.Text;

            if (motherMName == string.Empty || ssn == string.Empty || yearsThere == string.Empty || ownVRent == string.Empty || payment == string.Empty
                || motherMName == null || ssn == null || yearsThere == null || ownVRent == null || payment == null)
            {
                await DisplayAlert("Oops..", "Please fill out the entire form.", "Ok");
            }
            else if (ssn == null || ssn.Length != 9 || !int.TryParse(ssn, out int result))
            {
                await DisplayAlert("Oops..", "SSN must be 9 digits.", "Ok");
            }
            else
            {
                var last4ssn = ssn.Substring(5);
                //await DisplayAlert("hi", last4ssn, "ok");

                string url = $"https://ft-jlowis1.oraclecloud2.dreamfactory.com/api/v2/sql/_table/appdata?filter=ID={User.ID}";
                string jsonInsertString = $"{{ \"resource\": [ {{ \"motherMaidenName\": \"{motherMName}\", \"ssn\": \"{ssn}\", \"yearsAtAddress\": \"{yearsThere}\"," +
                    $" \"housingStatus\": \"{ownVRent}\", \"monthlyHousingPayment\": \"{payment}\", \"lastFourSSN\": \"{last4ssn}\" }} ] }}";
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
                        await DisplayAlert("Success", "Page 3 has been completed. On to page 4..!", "Ok");
                        ClearFields();
                        await Navigation.PushAsync(new FinancialInfo());
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
            mMaidenName.Text = string.Empty;
            this.ssn.Text = string.Empty;
            housedYears.Text = string.Empty;
            houseStatus.Text = string.Empty;
            monthlyPayment.Text = string.Empty;
        }
    }
}