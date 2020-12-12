using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Comments : IValidatableObject
    {
        public Comments(string Id, string Content, Item Item , IdentityUser Author)
        {
            this.Id = Id;
            this.Content = Content;
            this.Item = Item;
            this.Author = Author;
        }

        public Comments() { }

        [Required]
        public string Id { get; set; }
       
        [Required]
        [StringLength(300, MinimumLength = 1)]
        public string Content { get; set; }
       
        [Required]
        public Item Item  { get; set; }
       
        [Required]
        public IdentityUser Author { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Content))
                errors.Add(new ValidationResult("Content is not written"));


            return errors;
            //throw new NotImplementedException();
        }
    }
}
