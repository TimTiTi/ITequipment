using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]        
        public int SoftwareId { get; set; }
        [Required]        
        [StringLength(100)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Purpose { get; set; }
        [Column("Licence")]
        public LicenceType LicenceType { get; set; }		

        //public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<HW_SW> HW_SWs { get; set; }
    }
}
