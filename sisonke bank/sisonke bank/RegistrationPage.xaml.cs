using sisonke_bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sisonke_Banking_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        // Button that clicks to Register a new Person.
        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            var emailPattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\.(\\w){2,3})+)$";
            var emailAddress = txtEmailAddress.Text;


            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtGender.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtEmailAddress.Text) && !(Regex.IsMatch(emailAddress, emailPattern) || string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                await DisplayAlert("Invalid....", "Blank or WhiteSpace value is not Entered", "Ok");

                labelError.Text = "Email Verification Failed";

            }
            else
            {
                
                int RowAffected = await App.Database.CreatePersonAsync(new Registration
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Gender = txtGender.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    EmailAddress = txtEmailAddress.Text,
                    Password = txtPassword.Text
                });
                await Navigation.PushAsync(new WelcomePage());

            }
        }
    }
}