using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITequipment.Models
{
	
	public enum Status
	{
		Active,
		Inactive
	}
	
    public class HW_SW
    {

        public string Version { get; set; }
        [DataType(DataType.MultilineText)]
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
