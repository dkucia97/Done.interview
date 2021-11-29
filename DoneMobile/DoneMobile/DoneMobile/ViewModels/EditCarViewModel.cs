using DoneMobile.Models;
using DoneMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoneMobile.ViewModels
{
    public class EditCarViewModel : BindableObject
    {
        private readonly Car _car;
        private CarService _carService;

        public DateTime AvailabilityTimeDate { get; set; }
        public TimeSpan AvailabilityTime { get; set; }
        public string AvailabilityPlace { get; set; }

        public EditCarViewModel(Car car)
        {
            this._car = car;
            _carService = new CarService();
            AvailabilityTimeDate = car.AvailabilityTime;
            AvailabilityTime = car.AvailabilityTime.TimeOfDay;
            AvailabilityPlace = car.AvailabilityPlace;
        }

        public async Task Update()
        {
            var model = new UpdateCarModel()
            {
                AvailabilityTime = AvailabilityTimeDate + AvailabilityTime,
                AvailabilityPlace = AvailabilityPlace
            };
            await _carService.UpdateCar(model, _car.Id);
        }
    }
}
