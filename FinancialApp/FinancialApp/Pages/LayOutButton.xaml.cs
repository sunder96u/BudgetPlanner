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
    public partial class LayOutButton : ContentView
    {
        public LayOutButton()
        {
            InitializeComponent();
        }

        public ImageSource Icon
        {
            get { return LayoutIcon.Source; }
            set { LayoutIcon.Source = value; }
        }

        public string Label
        {
            get { return LayoutLabel.Text; }
            set { LayoutLabel.Text = value; }
        }

        public string Data
        {
            get { return LayoutId.Text; }
            set { LayoutId.Text = value; }
        }

	}
}