using System;
using System.Collections.Generic;
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


        public string Id { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Country { get; set; }

    }
}
