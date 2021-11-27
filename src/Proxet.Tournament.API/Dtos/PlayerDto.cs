using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Dtos
{
    public class PlayerDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [Range(1, 3)]
        public int VehicleType { get; set; }
    }
}
