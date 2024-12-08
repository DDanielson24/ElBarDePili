using ElBarDePili.Views;
using ElBarDePili.ViewModels;
using DevExpress.Maui.Controls;

namespace ElBarDePili.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
    }

}
