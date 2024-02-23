using Patient_Information.BL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Patient_Information.BL.DTO
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        [Required, DisplayName("Patient Name")]
        public string? PatientName { get; set; }
        [Required, DisplayName("Diseases Name")]
        public int DiseasesId { get; set; }
        [Required]
        public Epilepsy Epilepsy { get; set; }
        public string NCDStringify { get; set; }
        public NCD[] NCDList { get; set; }
        public string AllergiesStringify { get; set; }
        public Allergies[] AllergiesList { get; set; }
    }
}
