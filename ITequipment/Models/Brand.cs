using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITequipment.Models
{

    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(127)]
        public string Name { get; set; }
        [Column("Contanct full name")]
        public string ContactFullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.Url)]
        public string WebPage { get; set; }
		
        public virtual ICollection<Hardware> Hardware { get; set; }
		public virtual ICollection<Software> Software { get; set; }
    }
}

