using sisonke_bank.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace sisonke_bank.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}