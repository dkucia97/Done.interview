using DoneMobile.Models;
using DoneMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoneMobile.ViewModels
{
    public class AddCarViewModel : BindableObject
    {
        private readonly CarService _carService;

        public AddCarViewModel()
        {
            _carService = new CarService();
        }

        public string CarModel { get; set; }
        public double WeightCapacity { get; set; }
        public DateTime AvailabilityTimeDate { get; set; }
        public TimeSpan AvailabilityTime { get; set; }
        public string AvailabilityPlace { get; set; }

        public async Task AddCar()
        {
            var car = new Car();
            car.AvailabilityPlace = AvailabilityPlace;
            car.CarModel = CarModel;
            car.WeightCapacity = WeightCapacity;
            car.AvailabilityTime = AvailabilityTimeDate+AvailabilityTime;
            await _carService.AddCar(car);
        }
    }
}
