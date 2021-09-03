using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // for foreign keys
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Boolean State { get; set; }
        
        public int CityId { get; set; } // fk from City
        [JsonIgnore] public City City { get; set; }
        public int VehicleId { get; set; } // fk from Vehicle
        [JsonIgnore] public Vehicle Vehicle { get; set; }
       
    }
}
