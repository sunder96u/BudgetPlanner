using FinancialApp.Classes;
using FinancialApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BanksPage : ContentPage
	{
        ObservableCollection<Banks> Bank = new ObservableCollection<Banks>();

		public BanksPage (string myHouseId)
		{

			InitializeComponent ();
            BanksView.ItemsSource = Bank;
            getBankDetails(myHouseId);
            homeBtn.Clicked += HomeBtn_Clicked;
        }

        public async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public async void getBankDetails(string Id)
        {
            List<Banks> bank = await Core.GetBanks(Id);
            foreach (var banks in bank)
            {
                Bank.Add(banks);
            }
        }
    }
}