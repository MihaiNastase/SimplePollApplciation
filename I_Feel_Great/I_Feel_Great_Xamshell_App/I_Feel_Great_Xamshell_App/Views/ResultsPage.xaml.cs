using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PollClassLibrary;
using Microcharts;
using SkiaSharp;

namespace I_Feel_Great_Xamshell_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        //I apologise in advance for the messy code
        public ResultsPage(PollClass pollClass)
        {
            InitializeComponent();

            StatusLabel.Text = pollClass.ToString();

            //Adding entries for the chart:
            chartViewBar.Chart = new BarChart { Entries = new[] {
                 new ChartEntry((float)(pollClass.getPercentageMaleYesResponse()))
            {
                Label = "Male Yes",
                ValueLabel = String.Format("{0:0.##}%",(float)(pollClass.getPercentageMaleYesResponse())),
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry((float)(pollClass.getPercentageMaleNoResponse()))
            {
                Label = "Male No",
                ValueLabel = String.Format("{0:0.##}%",(float)(pollClass.getPercentageMaleNoResponse())),
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry((float)(pollClass.getPercentageFemaleYesResponse()))
            {
                Label = "Female Yes",
                ValueLabel = String.Format("{0:0.##}%",(float)(pollClass.getPercentageMaleYesResponse())),
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry((float)(pollClass.getPercentageFemaleNoResponse()))
            {
                Label = "Female No",
                ValueLabel = String.Format("{0:0.##}%",(float)(pollClass.getPercentageFemaleNoResponse())),
                Color = SKColor.Parse("#3498db")
            }
            }, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 30 };

            ResultsLabel.Text = String.Format("There is a {0:0.##}% probability that a 'No' answer comes from a male user.", pollClass.CalculateProbability());
        }
        private async void ReturnButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}