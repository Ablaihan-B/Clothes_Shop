using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Item
    {
        public Item(string Id, string Name, Category Category, Features Features, Gender Gender, double Price, string Image)
        {
            this.Id = Id;
            this.Name = Name;
            this.Category = Category;
            this.Features = Features;
            this.Gender = Gender;
            this.Price = Price;
            this.Image = Image;
        }

        public Item() { }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Features Features { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Image { get; set; }

    }
}
