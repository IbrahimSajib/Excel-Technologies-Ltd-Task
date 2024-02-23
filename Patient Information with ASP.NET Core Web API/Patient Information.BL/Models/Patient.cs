using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient_Information.BL.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required,DisplayName("Patient Name")]
        public string? PatientName { get; set; }
        [Required,DisplayName("Diseases Name")]
        [ForeignKey("Diseases")]
        public int DiseasesId { get; set; }
        [Required]
        public Epilepsy Epilepsy { get; set; }
        public virtual Diseases? Diseases { get; set;}
        public virtual ICollection<NCD_Details> NCD_Details { get; set; } = new List<NCD_Details>();
        public virtual ICollection<AllergiesDetails> AllergiesDetails { get; set; } = new List<AllergiesDetails>();
    }
}