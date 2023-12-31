namespace BD_Lab6.Models
{
    public class Income
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; }
        public int SourceIncomeId { get; set; }
        public SourceIncome? SourceIncome { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
