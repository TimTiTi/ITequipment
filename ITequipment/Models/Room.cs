using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITequipment.Models
{

    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Purpose { get; set; }

        [Range(-255,255)]
		public short Floor { get; set; }     
        
		public uint? Size { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}

