using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02Examan6925;

namespace PM02Examan6925.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listaUbicacion = await App.BaseDatos.ObtenerListaUbicacion();
            lsubicacion.ItemsSource = listaUbicacion;
        }

        private async void lsubicacion_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Ubicacion item = (Models.Ubicacion)e.Item;
           
            var page = new Views.UpdatePage();
            page.BindingContext = item;
            await Navigation.PushAsync(page);
            
           

           

        }

    
    }
}