using DoneMobile.Models;
using DoneMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoneMobile.ViewModels
{
    
    public class CarsViewModel : BindableObject
    {
        private ObservableCollection<Car> _cars;
        private CarService _carService;

        public CarsViewModel()
        {
            _carService = new CarService();
        }

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set { _cars= value; OnPropertyChanged(); }
        }

        public ICommand OnItemDeleteCommand =>
         new Command<Car>( async  (car) => await OnItemDeleteExecute(car));

        private async Task OnItemDeleteExecute(Car car)
        {
            await _carService.DeleteCar(car.Id);
            Cars.Remove(car);
        }

        public void  InitializeAsync(object navigationData)
        {
            Cars = _carService.GetCars();
        }
    }
}
