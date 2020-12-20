using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Gender
    {
        public Gender(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
          
        }
        public Gender() { }

        //[Required]
        public string Id { get; set; }

        //[Required]
        //[StringLength(300, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
