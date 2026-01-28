using sisonke_bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sisonke_Banking_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentBalance : ContentPage
    {
        public CurrentBalance()
        {
            InitializeComponent();
        }

        // it must show the balance you selected to be shown.
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var allAccounts = await App.Database.getAccount();
            accountShowID.Text = allAccounts.Last<Account>().AccountNumber.ToString();
            accountShowBalance.Text = allAccounts[0].Balance.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}