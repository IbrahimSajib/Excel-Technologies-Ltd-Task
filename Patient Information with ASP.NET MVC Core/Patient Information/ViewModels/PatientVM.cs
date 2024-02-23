using Patient_Information.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Patient_Information.ViewModels
{
    public class PatientVM
    {
        public int PatientId { get; set; }
        [Required, DisplayName("Patient Name")]
        public string? PatientName { get; set; }
        [Required, DisplayName("Diseases Name")]
        [ForeignKey("Diseases")]
        public int DiseasesId { get; set; }
        [Required]
        public Epilepsy Epilepsy { get; set; }
        public List<int> NCDList { get; set; } = new List<int>();
        public List<int> AllergiesList { get; set; } = new List<int>();
    }
}
