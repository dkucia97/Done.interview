using DoneMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoneMobile.Services
{
    // Of course, we should also handle errors
    public class CarService
    {
        private HttpClient _client;

        public CarService()
        {
            _client = new HttpClient();
        }

        public ObservableCollection<Car> GetCars()
        {
            var response = _client.GetAsync(Settings.BaseApiUrl + "car").Result;
            return JsonConvert.DeserializeObject<ObservableCollection<Car>>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task DeleteCar(int id)
        {
            var result=await  _client.DeleteAsync(Settings.BaseApiUrl + $"car/{id}");
            
        }

        public async Task AddCar(Car car)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(Settings.BaseApiUrl + "car/", httpContent);
        }

        public async Task UpdateCar(UpdateCarModel updateCarModel,int id)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(updateCarModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(Settings.BaseApiUrl + $"car/{id}", httpContent);
        }
    }
}
