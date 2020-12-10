using System;
using System.Collections.Generic;
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


        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Features Features { get; set; }
        public Gender Gender { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

    }
}
