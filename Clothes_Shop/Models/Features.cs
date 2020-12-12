using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Features
    {

        public Features(string Id, string Description, string Size, string Color, string Material, string Country)
        {
            this.Id = Id;
            this.Description = Description;
            this.Size = Size;
            this.Color = Color;
            this.Material = Material;
            this.Country = Country;
        }

        public Features() { }

        [Required]
        public string Id { get; set; }
       
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
        
        [Required]
        public string Size { get; set; }
        
        [Required]
        public string Color { get; set; }
        
        [Required]
        public string Material { get; set; }
       
        [Required]
        public string Country { get; set; }

    }
}
