using System.ComponentModel.DataAnnotations;

namespace BD_Lab6.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Range(1,10,ErrorMessage ="The name cannot contain more than 10 letters")]
        [Required(ErrorMessage ="Enter the name please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the surname please")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter the Birthday")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Enter the family's ID")]
        public int FamilyId { get; set; }
        public Family ?family { get; set; }
        public List<Consumption> ?Consumptions { get; set; }
        public List<Income> ?Incomes { get; set; }
    }
}
