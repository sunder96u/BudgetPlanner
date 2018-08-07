using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPageInfo : ContentPage
	{
		public AccountPageInfo ()
		{
			InitializeComponent ();
            getAccountBtn.Clicked += GetAccountBtn_Clicked;
            homeBtn.Clicked += HomeBtn_Clicked;
        }

        public async void GetAccountBtn_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AccountsPage());
        }

        public async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}