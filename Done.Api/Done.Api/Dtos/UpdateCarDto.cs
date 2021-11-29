using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Done.Api.Dtos
{
    public class UpdateCarDto
    {
        public DateTime AvailabilityTime { get; set; }
        public string AvailabilityPlace { get; set; }
    }
}
