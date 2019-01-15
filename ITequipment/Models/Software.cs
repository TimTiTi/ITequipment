using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITequipment.Models
{

	public enum LicenceType
	{
		PublicDomain,
		NonProtective,
		Protective,
		Proprietary,
		TradeSecret
	}
	
    public class Software
    {
        public int SoftwareId { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
		public LicenceType LicenceType { get; set; }		

        //public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<HW_SW> HW_SWs { get; set; }
    }
}
