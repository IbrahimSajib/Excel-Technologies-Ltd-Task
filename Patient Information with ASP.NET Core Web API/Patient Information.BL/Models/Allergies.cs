using System.ComponentModel.DataAnnotations;

namespace Patient_Information.BL.Models
{
    public class Allergies
    {
        public int AllergiesId { get; set; }
        [Required]
        public string? AllergiesName { get; set; }
        public virtual ICollection<AllergiesDetails> AllergiesDetails { get; set; }=new List<AllergiesDetails>();
    }
}
