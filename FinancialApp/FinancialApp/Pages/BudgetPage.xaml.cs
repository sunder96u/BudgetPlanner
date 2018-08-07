
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
	public partial class BudgetPage : ContentPage
	{
		public BudgetPage ()
		{
			InitializeComponent ();

            homeBtn.Clicked += HomeBtn_Clicked;
        }

        public async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}