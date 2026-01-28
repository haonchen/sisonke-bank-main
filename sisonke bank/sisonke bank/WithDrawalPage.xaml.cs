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
    public partial class WithDrawalPage : ContentPage
    {
        public WithDrawalPage()
        {
            InitializeComponent();
        }

        // whenever you click the button it should withdraw money from a current account you choose from.
        private async void WithDraw_Clicked(object sender, EventArgs e)
        {
            Account newAccount = new Account();
            newAccount.AccountNumber = Convert.ToInt32(txtAccountNumber.Text);
            newAccount.Balance = Convert.ToDouble(txtAmount.Text);

            bool isDeposited = await App.Database.Withdraw(newAccount.AccountNumber, newAccount.Balance);
            if (isDeposited == true)
            {

                await DisplayAlert("....", " Withdraw Complete", "Ok");
            }
            else
            {
                await DisplayAlert("....", "Something went wrong", "Ok");
            }
        }
    }
}