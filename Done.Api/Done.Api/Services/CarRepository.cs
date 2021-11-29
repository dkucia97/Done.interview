using Done.Api.Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;

namespace Done.Api.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly PostgresDbProvider _dbProvider;

        public CarRepository(PostgresDbProvider dbProvider)
        {
            this._dbProvider = dbProvider;
        }

        public async Task<int> AddCar(Car car)
        {
            var query = "INSERT INTO Cars(CarModel,WeightCapacity,AvailabilityTime,AvailabilityPlace) values(@CarModel,@WeightCapacity,@AvailabilityTime,@AvailabilityPlace)" +
                "  returning id";
            using var connection = _dbProvider.GetDbConnection();
            return await connection.QueryFirstAsync<int>(query, car);
        }

        public async Task DeleteCar(int carId)
        {
            var query = "DELETE FROM Cars WHERE Id=@carId";
            using var connection = _dbProvider.GetDbConnection();
            await connection.ExecuteAsync(query, new { carId });
        }

        public async  Task<Car> GetById(int id)
        {
            var query = "SELECT * FROM Cars Where Id=@id";
            using var connection = _dbProvider.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<Car>(query, new { id });
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            var query = "SELECT * FROM Cars";
            using var connection = _dbProvider.GetDbConnection();
            return await connection.QueryAsync<Car>(query);
        }

        public async  Task UpdateCar(Car car)
        {
            var query = "UPDATE Cars SET CarModel=@CarModel ,WeightCapacity=@WeightCapacity,AvailabilityTime=@AvailabilityTime,AvailabilityPlace=@AvailabilityPlace WHERE Id=@Id  ";
            using var connection = _dbProvider.GetDbConnection();
            await connection.ExecuteAsync(query, car);
        }
    }
}
