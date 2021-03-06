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
        [StringLength(127)]
        public string Serial { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1023)]
        public string Purpose { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2047)]
        public string Specs { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2047)]
        public string AdditionalInfo { get; set; }

        [DataType(DataType.Date)]
        public DateTime AcquiredDate { get; set; }

        [Required]
        public Condition Condition { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]        
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
		
		public int RoomId { get; set; }
        [Required]
        public virtual Room Room { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public virtual ICollection<HW_SW> HW_SWs { get; set; }
    }
}
