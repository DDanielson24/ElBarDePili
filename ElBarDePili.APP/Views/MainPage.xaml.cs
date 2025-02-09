using ElBarDePili.Views;
using ElBarDePili.ViewModels;
using DevExpress.Maui.Controls;
using ElBarDePili.API.ClassLibraryAPI;

namespace ElBarDePili.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ElBarDePiliAPI elBarDePiliAPI = new ElBarDePiliAPI();
            var response = await elBarDePiliAPI.HolaMundo();
        }

    }

}
