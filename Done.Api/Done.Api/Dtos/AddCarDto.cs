using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Done.Api.Dtos
{
    public class AddCarDto
    {
        public string CarModel { get; set; }
        public double WeightCapacity { get; set; }
        public DateTime? AvailabilityTime { get; set; }
        public string AvailabilityPlace { get; set; }
    }
}
