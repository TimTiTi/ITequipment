using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITequipment.Models
{

    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
		public string ContactFullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string WebPage { get; set; }
		
        public ICollection<Hardware> Hardware { get; set; }
		public ICollection<Software> Software { get; set; }
    }
}

