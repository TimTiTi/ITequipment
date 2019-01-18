using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITequipment.Models
{

    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }
		
        public virtual ICollection<Hardware> Hardware { get; set; }
    }
}
