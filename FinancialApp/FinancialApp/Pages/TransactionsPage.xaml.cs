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
	public partial class TransactionsPage : ContentPage
	{
        ObservableCollection<Transactions> Transaction { get; set; }

		public TransactionsPage ()
		{
            InitializeComponent ();

            Transaction = new ObservableCollection<Transactions>();

            homeBtn.Clicked += HomeBtn_Clicked;
            thisbtn.Clicked += Button_Clicked;
        }

        public async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LandingPage());
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            List<Transactions> trans = await Core.GetTransactions(AccountId.Text);
            foreach (var item in trans)
            {
                Transaction.Add(item);
            }
            TransactionsView.ItemsSource = Transaction;
        }
    }
}