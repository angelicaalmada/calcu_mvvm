using calcu_mvvm.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calcu_mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pagina();
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
