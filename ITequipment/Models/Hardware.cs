using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITequipment.Models
{

	public enum Condition: byte
	{
		Excelent,
		Good,
		Satisfactory,
		Poor,
		Broken
	}
	
    public class Hardware
    {
        [Key]
        public int HardwareId { get; set; }
        [Required]
        [StringLength(128)]
        public string Serial { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(1024)]
        public string Purpose { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(4096)]
        public string Specs { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(2048)]
        public string AdditionalInfo { get; set; }
        [DataType(DataType.Date)]
        public DateTime AcquiredDate { get; set; }
        [Required]
        public Condition Condition { get; set; }

        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
		
		public int RoomId { get; set; }
        [Required]
        public virtual Room Room { get; set; }
		
		public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public virtual ICollection<HW_SW> HW_SWs { get; set; }
    }
}
