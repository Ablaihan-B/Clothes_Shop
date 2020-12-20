using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Comments : IValidatableObject
    {
        public Comments(string Id, string Content, string Item , string Author)
        {
            this.Id = Id;
            this.Content = Content;
            this.ItemId = ItemId;
            this.Author = Author;
        }

        public Comments() { }

        
        public string Id { get; set; }
       
        
        [StringLength(300, MinimumLength = 1)]
        public string Content { get; set; }
       
       
        public string ItemId  { get; set; }
       
        
        public string Author { get; set; }


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
