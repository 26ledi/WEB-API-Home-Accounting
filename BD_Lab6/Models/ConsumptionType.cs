﻿namespace BD_Lab6.Models
{
    public class ConsumptionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Consumption> Consumptions { get; set; }
    }
}
