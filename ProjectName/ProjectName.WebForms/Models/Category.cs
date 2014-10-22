namespace Kupuvalnik.WebForms.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Comodity> comodities;

        public Category()
        {
            this.comodities = new HashSet<Comodity>();
        }

        public int CategoryId { get; set; }

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