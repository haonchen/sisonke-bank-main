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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // the button that where you have to create your account.
        private void CreateAccount_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccount());
        }

        // the button where you have to view your account balance.
        private void ViewAccountBalance_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewAccountBalancePage());
        }

        // the button sends you to the page where you have to transfer your accounts.
        private void TransferBetweenAccounts_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransferBetweenAccountsPage());
        }

        // click the button everytime when you done with the App, that's where you log out the App.
        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            
            await DisplayAlert("Successfull....", "user has been Log Out", "Ok");
            await Navigation.PushAsync(new WelcomePage());
        }

        private void BtnTransactions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Transactions());
        }
    }
}