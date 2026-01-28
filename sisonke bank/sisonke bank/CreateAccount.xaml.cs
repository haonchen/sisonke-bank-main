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
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Account newAccount = new Account();
            newAccount.HolderName = txtHolderName.Text;
            newAccount.Surname = txtSurname.Text;
            newAccount.Balance = Convert.ToDouble(txtBalance.Text);
            newAccount.SavingsAccountBalance = Convert.ToDouble(txtSavingsAccountBalance.Text);




            int rowAffected = await App.Database.setAccount(newAccount);


            listAccounts.ItemsSource = await App.Database.getAccount();

            await DisplayAlert("...", " Account Has Been Created", "Ok");
        }
    }
}