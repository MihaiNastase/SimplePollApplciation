using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_Feel_Great_Xamshell_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
        }

        private async void ReturnButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}