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
    public partial class Transactions : ContentPage
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void Deposit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Deposit());
        }

        private void WithDrawal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WithDrawalPage());
        }
    }
}