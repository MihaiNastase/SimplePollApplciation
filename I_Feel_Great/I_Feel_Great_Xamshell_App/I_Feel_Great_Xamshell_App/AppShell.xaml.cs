using I_Feel_Great_Xamshell_App.ViewModels;
using I_Feel_Great_Xamshell_App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace I_Feel_Great_Xamshell_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
