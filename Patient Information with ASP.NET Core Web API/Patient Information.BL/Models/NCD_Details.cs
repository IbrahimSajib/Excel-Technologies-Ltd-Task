using System.ComponentModel.DataAnnotations.Schema;

namespace Patient_Information.BL.Models
{
    public class NCD_Details
    {
        public int Id { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        [ForeignKey("NCD")]
        public int NCDId { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual NCD? NCD { get; set; }
    }
}