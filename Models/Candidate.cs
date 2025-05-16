using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatosWebApp.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public ICollection<CandidateExperience>? CandidateExperiences { get; set; }
    }
}
