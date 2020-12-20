using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Item
    {
        public Item(string Id, string Name, String CategoryId, String FeaturesId, Features Features, String GenderId, double Price, string Image)
        {
            this.Id = Id;
            this.Name = Name;
            this.CategoryId = CategoryId;
            this.Features = Features;
            this.GenderId = GenderId;
            this.Price = Price;
            this.Image = Image;
            this.FeaturesId = FeaturesId;
        }

        public Item() { }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        public string CategoryId { get; set; }

        public String FeaturesId { get; set; }
        public Features Features { get; set; }

        
        public string GenderId { get; set; }

       
        public double Price { get; set; }

        [Required]
        public string Image { get; set; }

    }
}
