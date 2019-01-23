using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITequipment.Models
{

    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        [StringLength(511)]
        public string Address { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        [Required]
        [StringLength(255)]
        public string Country { get; set; }
		
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
