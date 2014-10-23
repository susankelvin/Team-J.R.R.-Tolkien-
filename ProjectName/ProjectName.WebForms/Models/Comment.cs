namespace Kupuvalnik.WebForms.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int ComodityId { get; set; }

        public virtual Comodity Comodity { get; set; }
    }
}