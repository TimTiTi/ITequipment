using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITequipment.Models
{

    public class Owner
    {
        public int OwnerId { get; set; }
        public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		
        public ICollection<Hardware> Hardware { get; set; }
    }
}
