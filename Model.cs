using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDatabase
{
    public class CarMake
    {
        public int ID { get; set; }
        [Required]
        public string Make { get; set; }
        public List<CarModel> CarModels { get; set; }
    }
    public class CarModel
    {
        public int ID { get; set; }
        public int CarMakeId { get; set; }
        [Required]
        public CarMake CarMake { get; set; }
        public string Model { get; set; }
        public List<Ownership> Ownerships { get; set; }
    }
    public class Ownership
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
        public int CarModelId { get; set; }
        [Required]
        public CarModel CarModel { get; set; }
        [Required]
        public string VehicleIdentificationNumber { get; set; }
    }
    public class Person
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<Ownership> Ownerships { get; set; }
    }
}
