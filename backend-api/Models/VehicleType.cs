using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace backend_api.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        [JsonIgnore] public ICollection<Vehicle> Vehicles { get; set; }

    }
}
