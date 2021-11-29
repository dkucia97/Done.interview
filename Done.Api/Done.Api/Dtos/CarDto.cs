using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Done.Api.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public double WeightCapacity { get; set; }
        public DateTime? AvailabilityTime { get; set; }
        public string AvailabilityPlace { get; set; }
    }
}
