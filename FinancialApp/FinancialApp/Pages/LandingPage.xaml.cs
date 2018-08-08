using FinancialApp.Classes;
using FinancialApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LandingPage : ContentPage
	{


		public LandingPage ()
		{
			InitializeComponent ();
            
		}

        public async void AccountsButtonTapped (object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AccountPageInfo());
        }

        public async void BanksButtonTapped (object sender, EventArgs args)
        {

            await Navigation.PushAsync(new BanksPage(2.ToString()));
        }

        public async void BudgetButtonTapped (object sender, EventArgs args)
        {
            await Navigation.PushAsync(new BudgetPage());
        }

        public async void TransactionsButtonTapped (object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TransactionPageInfo());
        }
	}
}