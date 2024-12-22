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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                // Si estás usando un certificado autofirmado, puedes deshabilitar la validación del certificado (solo para desarrollo)
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

                    var response = await client.GetAsync("https://10.0.2.2:7062/Recetas/GetRecetas");

                    if (response.IsSuccessStatusCode)
                    {
                        string resp = await response.Content.ReadAsStringAsync();
                    }
                }
            }
        }

    }

}
