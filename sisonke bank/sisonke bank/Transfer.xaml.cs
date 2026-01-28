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
    public partial class Transfer : ContentPage
    {
        public Transfer()
        {
            InitializeComponent();
        }

        // Button when you click it, it transfer money into different accounts.
        private async void Send_Clicked(object sender, EventArgs e)
        {
            int accTo = Convert.ToInt32(txtToAccountNumber.Text);
            int accFrom = Convert.ToInt32(txtFromAccountNumber.Text);
            double amount = Convert.ToDouble(txtTransferAmount.Text);

            bool isDeposited = await App.Database.Transfer(accFrom, accTo, amount);
            if (isDeposited == true)
            {

                await DisplayAlert("....", "Transfer Complete.", "Ok");
            }
            else
            {
                await DisplayAlert("....", "Something went wrong", "Ok");
            }
        }
    }
}