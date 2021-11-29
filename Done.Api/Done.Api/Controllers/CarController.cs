using Done.Api.Domain;
using Done.Api.Dtos;
using Done.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Done.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _carRepository.GetCars();
            var dtos = cars.Select(c => new CarDto()
            {
                AvailabilityPlace = c.AvailabilityPlace,
                AvailabilityTime = c.AvailabilityTime,
                CarModel = c.CarModel,
                Id = c.Id,
                WeightCapacity = c.WeightCapacity
            });
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarDto dto)
        {
            var car = new Car()
            {
                AvailabilityPlace = dto.AvailabilityPlace,
                AvailabilityTime = dto.AvailabilityTime,
                CarModel = dto.CarModel,
                WeightCapacity = dto.WeightCapacity
            };
            var id=await _carRepository.AddCar(car);
            var dtoResult = new CarDto()
            {
                Id = id,
                AvailabilityPlace = car.AvailabilityPlace,
                AvailabilityTime = car.AvailabilityTime,
                CarModel = car.CarModel,
                WeightCapacity = car.WeightCapacity
            };
            return CreatedAtAction(nameof(Add), dtoResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car =await  _carRepository.GetById(id);
            if (car is null) return NotFound();

            await _carRepository.DeleteCar(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateCarDto updateCarDto)
        {
            var car = await _carRepository.GetById(id);
            if (car is null) return NotFound();
            car.AvailabilityPlace = updateCarDto.AvailabilityPlace;
            car.AvailabilityTime = updateCarDto.AvailabilityTime;
            await _carRepository.UpdateCar(car);
            return NoContent();
        }
    }
}
