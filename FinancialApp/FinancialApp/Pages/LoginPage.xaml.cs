using FinancialApp.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{



		public LoginPage ()
		{
			InitializeComponent ();

            getHouseBtn.Clicked += GetHouseBtn_Clicked;
           
        }

        public async void GetHouseBtn_Clicked (object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
            if (!string.IsNullOrEmpty((string)houseEntry.Text))
            {

                //var household = await Core.GetLandingPage(houseEntry.Text);
                //var landingPage = new LandingPage();
                //landingPage.BindingContext = household;
                //await Navigation.PushAsync(landingPage);

                Debug.WriteLine("House Entry = " + houseEntry.Text);
                var household = await Core.GetLandingPage(houseEntry.Text);
                Debug.WriteLine("Household: " + household);

                await Navigation.PushAsync(new LandingPage());

            }

        }

    }
}