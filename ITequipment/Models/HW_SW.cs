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
		public string Comments { get; set; }
        public Status Status { get; set; }

		[Key]
        public int HardwareId { get; set; }
        public Hardware Hardware { get; set; }
		[Key]
		public int SoftwareId { get; set; }
        public Software Software { get; set; }
		
    }
}
