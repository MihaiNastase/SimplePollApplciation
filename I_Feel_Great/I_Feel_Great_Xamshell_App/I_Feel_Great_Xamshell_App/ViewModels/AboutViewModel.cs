using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace I_Feel_Great_Xamshell_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}