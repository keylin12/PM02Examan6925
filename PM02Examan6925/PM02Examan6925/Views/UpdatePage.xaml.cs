using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02Examan6925.Models;
using Xamarin.Essentials;


namespace PM02Examan6925.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void Modificar_Clicked(object sender, EventArgs e)
        {
            var ubicacion = new Models.Ubicacion
            {
                id = Convert.ToInt32(this.txtid.Text),
                latitud = Convert.ToDecimal(this.txtlatitud.Text),
                longitud = Convert.ToDecimal(this.txtlongitud.Text),
                descripcionubicacion = txtdescripcion.Text,
                descripcioncorta = txtdescripcioncorta.Text,

            };


            if (await App.BaseDatos.GrabarUbicacion(ubicacion) != 0)
                await DisplayAlert("Dato Actualizado", "El Dato se Actualizo", "Ok");
            else
                await DisplayAlert("Error", "El Dato no se Actualizo", "OK");

        }

        private async  void Eliminar_Clicked(object sender, EventArgs e)
        {
            var ubicacion = new Models.Ubicacion
            {
                id = Convert.ToInt32(this.txtid.Text),
                latitud = Convert.ToDecimal(this.txtlatitud.Text),
                longitud = Convert.ToDecimal(this.txtlongitud.Text),
                descripcionubicacion = txtdescripcion.Text,
                descripcioncorta = txtdescripcioncorta.Text,

            };

            if (await App.BaseDatos.EliminarUbicacion(ubicacion) != 0)
                await DisplayAlert("Dato Eliminado", "El Dato se Elimino", "Ok");
            else
                await DisplayAlert("Error", "El Dato no se Elimino", "OK");

        }

        private async void gps_Clicked(object sender, EventArgs e)
        {
            

            if (!double.TryParse(txtlatitud.Text, out double lat))
                return;
            if (!double.TryParse(txtlongitud.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            { 
                Name = txtdescripcion.Text,
                NavigationMode = NavigationMode.None
            });
           



        }
    }
}