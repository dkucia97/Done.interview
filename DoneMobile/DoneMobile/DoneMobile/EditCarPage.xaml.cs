using DoneMobile.Models;
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
    public partial class EditCarPage : ContentPage
    {
        public EditCarPage(Car car)
        {
            InitializeComponent();
            BindingContext = new EditCarViewModel(car);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as EditCarViewModel).Update();
            await Navigation.PopAsync();
        }
    }
}