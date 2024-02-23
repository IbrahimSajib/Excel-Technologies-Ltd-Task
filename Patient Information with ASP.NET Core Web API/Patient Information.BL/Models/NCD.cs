using System.ComponentModel.DataAnnotations;

namespace Patient_Information.BL.Models
{
    public class NCD
    {
        public int NCDId { get; set; }
        [Required]
        public string? NCDName { get; set; }
        public virtual ICollection<NCD_Details> NCD_Details { get; set; }=new List<NCD_Details>();
    }
}