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
    public partial class TransferBetweenAccountsPage : ContentPage
    {
        public TransferBetweenAccountsPage()
        {
            InitializeComponent();
        }

        private void TransferMoney_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Transfer());
        }
    }
}