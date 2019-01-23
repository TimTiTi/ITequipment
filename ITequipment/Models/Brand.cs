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

        [Column("Contact full name")]
        [StringLength(255, MinimumLength = 2),]
        public string ContactFullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(127, MinimumLength= 5)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(63, MinimumLength= 10)]
        public string Phone { get; set; }

        [DataType(DataType.Url)]
        [StringLength(255)]
        public string WebPage { get; set; }
		
        public virtual ICollection<Hardware> Hardware { get; set; }
		public virtual ICollection<Software> Software { get; set; }
    }
}

