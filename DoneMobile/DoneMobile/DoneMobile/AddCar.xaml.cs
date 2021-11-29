using DoneMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoneMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCar : ContentPage
    {
        public AddCar()
        {
            InitializeComponent();
            BindingContext = new AddCarViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var bc=BindingContext as AddCarViewModel;
            await bc.AddCar();
            await Navigation.PopAsync();
        }
    }
}