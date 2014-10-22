namespace Kupuvalnik.WebForms.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Comodity> comodities;

        public Category()
        {
            this.comodities = new HashSet<Comodity>();
        }

        public int CategoryId { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Comodity> Comodities
        {
            get
            {
                return this.comodities;
            }

            set
            {
                this.comodities = value;
            }
        }
    }
}