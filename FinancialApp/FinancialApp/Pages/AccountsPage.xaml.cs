using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialApp.Classes;
using FinancialApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountsPage : ContentPage
	{
        ObservableCollection<Accounts> Account = new ObservableCollection<Accounts>();

        public AccountsPage (string myBankId)
		{
			InitializeComponent ();
            AccountsView.ItemsSource = Account;
            GetTransactionDetail(myBankId);
            homeBtn.Clicked += HomeBtn_Clicked;
        }

        public async void GetTransactionDetail(string id)
        {
            var myAccounts = await Core.GetAccounts(id);

            foreach (var acct in myAccounts)
            {
                Account.Add(acct);
            }
            
        }

        public async void HomeBtn_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LandingPage());
        }
     
	}
}