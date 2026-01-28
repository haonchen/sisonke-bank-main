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
    public partial class Deposit : ContentPage
    {
        public Deposit()
        {
            InitializeComponent();
        }

        // Button when you click it, it should Deposit new money into a Account.
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Account newAccount = new Account();
            newAccount.AccountNumber = Convert.ToInt32(txtAccountNumber.Text);
            newAccount.Balance = Convert.ToDouble(txtDepositAmount.Text);

            bool isDeposited = await App.Database.Deposit(newAccount.AccountNumber, newAccount.Balance);
            if (isDeposited == true)
            {

                await DisplayAlert("....", "Your Account Has Been deposited", "Ok");
            }
            else
            {
                await DisplayAlert("....", "Hmmm Something went wrong", "Try again... Ok");
            }
        }
    }
}