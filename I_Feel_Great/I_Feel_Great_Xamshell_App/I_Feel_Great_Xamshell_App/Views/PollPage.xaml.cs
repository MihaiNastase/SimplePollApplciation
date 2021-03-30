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
    public partial class PollPage : ContentPage
    {
        public PollPage()
        {
            InitializeComponent();
        }

        private void Color_OnFocused(Entry entry, EventArgs e)
        {
            entry.TextColor = Color.Black;
        }
        private void Color_OnUnfocused(Entry entry, EventArgs e)
        {
            entry.TextColor = Color.Black;
        }

        private async void CalculateResults_Clicked(object sender, EventArgs e)
        {
            uint MaleYes;
            uint MaleNo;
            uint FemaleYes;
            uint FemaleNo;
            bool AllFieldsValid = true;

            if (!uint.TryParse(maleYes.Text, out MaleYes))
            {
                maleYes.TextColor = Color.Red;
                AllFieldsValid = false;
            }
            if (!uint.TryParse(maleNo.Text, out MaleNo))
            {
                maleNo.TextColor = Color.Red;
                AllFieldsValid = false;
            }
            if (!uint.TryParse(femaleYes.Text, out FemaleYes))
            {
                femaleYes.TextColor = Color.Red;
                AllFieldsValid = false;
            }
            if (!uint.TryParse(femaleNo.Text, out FemaleNo))
            {
                femaleNo.TextColor = Color.Red;
                AllFieldsValid = false;
            }

            if (!AllFieldsValid)
            {
                InvalidValuesAlertButtonClicked(sender, e);
            }
            else if ( MaleNo + MaleYes + FemaleNo + FemaleYes == 0)
            {
                EmptyPollAlertButtonClicked(sender, e);
            } 
            else
            {
                
                await Navigation.PushAsync(new ResultsPage());
            }

            
        }

        async void EmptyPollAlertButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invalid Inputs", "The total count of responses must be greater than 0.", "OK");
        }

        async void InvalidValuesAlertButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invalid Inputs", "Please provide valid integers for poll numbers.", "OK");
        }
    }
}