using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PM02Examan6925.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void toolbar01_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListPage());
        }



        private async void btnGuardarubicacion_Clicked(object sender, EventArgs e)
        {

            try
            {
                var ubicacion = new Models.Ubicacion
                {
                    
                    latitud = Convert.ToDecimal(this.txtlatitud.Text),
                    longitud = Convert.ToDecimal(this.txtlongitud.Text),
                    descripcionubicacion = txtdescripcion.Text,
                    descripcioncorta = txtdescripcioncorta.Text,

                };

                var resultado = await App.BaseDatos.GrabarUbicacion(ubicacion);

                if (resultado == 1)
                {
                    await DisplayAlert("Agredado", "Ingresado Exitosamente", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "No se guardar la ubicacion", "OK");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }

        }
    

        
        private void ClearScreen()
        {
            this.txtlatitud.Text = String.Empty;
            this.txtlongitud.Text = String.Empty;
            this.txtdescripcion.Text = String.Empty;
            this.txtdescripcioncorta.Text = String.Empty;
        }

       
    }
}