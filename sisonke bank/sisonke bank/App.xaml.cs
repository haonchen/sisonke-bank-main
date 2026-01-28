using sisonke_bank.Services;
using sisonke_bank.Views;
using Sisonke_Banking_App;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sisonke_bank
{
    public partial class App : Application
    {
        private static Database database;

        public static Database Database

        {
            get
            {
                if (database == null)
                {
                    database = new
                        Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bank_v2.db3"));

                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
