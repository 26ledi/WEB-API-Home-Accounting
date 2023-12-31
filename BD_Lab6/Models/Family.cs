namespace BD_Lab6.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string? FamilyName { get; set; }
        public List<Member>? FamilyMember { get; set; }
    }
}
