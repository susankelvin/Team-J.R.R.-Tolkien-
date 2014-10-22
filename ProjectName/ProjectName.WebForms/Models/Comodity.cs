namespace Kupuvalnik.WebForms.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Comodity
    {
        private ICollection<Comment> comments;
        
        public Comodity()
        {
            this.comments = new HashSet<Comment>();
        }

        public int ComodityId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
