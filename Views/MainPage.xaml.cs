using ElBarDePili.Views;
using ElBarDePili.ViewModels;

namespace ElBarDePili
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
