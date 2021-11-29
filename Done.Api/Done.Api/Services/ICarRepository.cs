using Done.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Done.Api.Services
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetById(int id);
        Task<int> AddCar(Car car);
        Task DeleteCar(int carId);
        Task UpdateCar(Car car);
    }
}
