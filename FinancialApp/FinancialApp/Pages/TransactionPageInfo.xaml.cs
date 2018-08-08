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
	public partial class TransactionPageInfo : ContentPage
	{
		public TransactionPageInfo ()
		{
			InitializeComponent ();
            getTransactionBtn.Clicked += GetTransactionBtn_Clicked;
            homeBtn.Clicked += HomeBtn_Clicked;
        }

        public async void GetTransactionBtn_Clicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(accountEntry.Text))
                {
                var transaction = await Core.GetTransactions(accountEntry.Text);
                var page = new TransactionsPage();
                page.BindingContext = transaction;
                await Navigation.PushAsync(page);
                Debug.WriteLine(transaction);
            }
        }

        public async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}