﻿namespace BD_Lab6.Models
{
    public class Consumption
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ConsumptionTypeId { get; set; }
        public ConsumptionType ConsumptionType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
