using System.ComponentModel.DataAnnotations.Schema;

namespace Patient_Information.Models
{
    public class AllergiesDetails
    {
        public int Id { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        [ForeignKey("Allergies")]
        public int AllergiesId { get; set; }
        public virtual Patient Patient { get; set; } = default!;
        public virtual Allergies Allergies { get; set; } = default!;
    }
}
