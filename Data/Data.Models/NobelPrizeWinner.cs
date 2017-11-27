namespace Data.Models
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NobelPrizeWinner
    {
        public NobelPrizeWinner()
        {
        }

        [Required]
        public ushort Year { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Country {get; set; }

        public string Residence { get; set; }

        public string FieldLanguage { get; set; }

        [Required]
        public PrizeName PrizeName { get; set; }

        [Required]
        public string Motivation { get; set; }
    }
}
