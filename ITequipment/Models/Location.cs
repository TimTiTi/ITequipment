using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITequipment.Models
{

    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
		public string Place { get; set; }
		public string Country { get; set; }
		
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
