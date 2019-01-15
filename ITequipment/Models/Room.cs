using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITequipment.Models
{

    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
		public short Floor { get; set; }
		public uint Size { get; set; }

        //public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}

