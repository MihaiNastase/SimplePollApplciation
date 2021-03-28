using I_Feel_Great_Xamshell_App.Services;
using I_Feel_Great_Xamshell_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_Feel_Great_Xamshell_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
