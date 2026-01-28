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
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        // Button to click to Log In into the App.
        private async void BtnLogInPage_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                await DisplayAlert("Invalid!!!", "Email or Password is not Entered", "Ok");


            }
            else
            {
                // Checks if the Email and Password exists from the registrations Entered.
                Registration LogInPerson = await App.Database.RegistrationLogIn(txtEmail.Text, txtPassword.Text);
                await DisplayAlert("Sucess", "user " + LogInPerson.FirstName, "Ok");
                if (LogInPerson.LastName.Equals( "Not Found"))
                {
                    await DisplayAlert("Invalid!!!", "Email or Password is Incorrect", "Ok");
                }
                else
                {
                    await DisplayAlert("Success", "You Have Successfully Log In", "Ok");
                    await Navigation.PushAsync(new HomePage());
                }
            }
        }

        // button tap returns you into the Welcome Page.
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WelcomePage());
        }
    }
}