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
    public partial class ViewAccountBalancePage : ContentPage
    {
        public ViewAccountBalancePage()
        {
            InitializeComponent();
        }

        private void CurrentBalance_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CurrentBalance());
        }

        private void SavingsAccountBalance_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccount());
        }
    }
}