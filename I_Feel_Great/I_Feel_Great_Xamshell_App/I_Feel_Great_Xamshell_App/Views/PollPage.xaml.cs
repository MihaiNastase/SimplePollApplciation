using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PollClassLibrary;

namespace I_Feel_Great_Xamshell_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PollPage : ContentPage
    {
        public PollPage()
        {
            InitializeComponent();
        }

        //Event handlers to change color to entryes in case of form validation
        private void Color_OnFocused(Entry entry, EventArgs e)
        {
            entry.TextColor = Color.Black;
        }
        private void Color_OnUnfocused(Entry entry, EventArgs e)
        {
            entry.TextColor = Color.Black;
        }

        //Event handler on button press for results page and form validation
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
                PollClass newPoll = new PollClass(MaleYes, MaleNo, FemaleYes, FemaleNo);
                await Navigation.PushAsync(new ResultsPage(newPoll));
            }

            
        }

        //Custom errors
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