using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Patient_Information.BL.Models
{
    public class Diseases
    {
        public int DiseasesId { get; set; }
        [Required,DisplayName("Diseases Name")]
        public string? DiseasesName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }=new List<Patient>();
    }
}