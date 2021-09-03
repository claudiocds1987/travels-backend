using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace backend_api.Models
{
    public class City
    {

        public int Id { get; set; }
      
        [Required]
        public string Name { get; set; }

        // doing the relation with entity Country
        public int CountryId { get; set; } // this is FK from Country
        [JsonIgnore] public Country Country { get; set; }

    }
}
