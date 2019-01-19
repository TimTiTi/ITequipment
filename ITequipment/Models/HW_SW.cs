using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITequipment.Models
{
	
	public enum Status: byte
	{
		Active,
		Inactive
	}
	
    public class HW_SW
    {
        [StringLength(255)]
        public string Version { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4096)]
        public string Comments { get; set; }

        [Required]
        public Status Status { get; set; }

        [Key]
        public int HardwareId { get; set; }
        public virtual Hardware Hardware { get; set; }		
        [Key]
		public int SoftwareId { get; set; }
        public virtual Software Software { get; set; }
		
    }
}
