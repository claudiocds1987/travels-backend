using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class CountryCode
    {
        [Key]
        public string Code { get; set; }
        public int CountryId { get; set; } // this is FK
        [JsonIgnore] public Country Country{ get; set; }

    }
}
