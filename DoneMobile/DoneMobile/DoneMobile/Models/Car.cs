using System;
using System.Collections.Generic;
using System.Text;

namespace DoneMobile.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public double WeightCapacity { get; set; }
        public DateTime AvailabilityTime { get; set; }
        public string AvailabilityPlace { get; set; }
    }
}
