using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        //public string Type { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        // doing the relation with entity Brand
        public int BrandId { get; set; } // this is FK
        [JsonIgnore] public Brand Brand { get; set; }

        // doing the relation with entity VehicleType
        public int VehicleTypeId { get; set; } // this is FK from VehicleType
        [JsonIgnore] public VehicleType VehicleType { get; set; }

    }
}
