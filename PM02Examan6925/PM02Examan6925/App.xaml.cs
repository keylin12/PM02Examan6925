using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02Examan6925.Controller;
using System.IO;

namespace PM02Examan6925
{
    public partial class App : Application
    {
        static DataBaseSQLite basedatos;

        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {

                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02.db"));
                }

                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
