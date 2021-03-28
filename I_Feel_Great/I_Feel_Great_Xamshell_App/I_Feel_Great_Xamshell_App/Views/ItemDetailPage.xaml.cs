using I_Feel_Great_Xamshell_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace I_Feel_Great_Xamshell_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}