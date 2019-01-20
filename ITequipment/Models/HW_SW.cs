using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HardwareId { get; set; }
        public virtual Hardware Hardware { get; set; }		
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoftwareId { get; set; }
        public virtual Software Software { get; set; }
		
    }
}
