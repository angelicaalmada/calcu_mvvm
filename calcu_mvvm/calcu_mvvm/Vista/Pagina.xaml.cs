using calcu_mvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calcu_mvvm.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina : ContentPage
    {
        public Pagina()
        {
            InitializeComponent();
            BindingContext = new VMcalculadora();
        }
    }
}