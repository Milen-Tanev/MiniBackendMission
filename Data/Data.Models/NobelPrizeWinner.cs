namespace Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models.Enums;

    public class NobelPrizeWinner : IComparable<NobelPrizeWinner>
    {
        public NobelPrizeWinner()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1900, 9999)]
        public int Year { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string BirthDate { get; set; }
        
        [MaxLength(100)]
        public string BirthPlace { get; set; }
        
        [MaxLength(100)]
        public string Country {get; set; }
        
        [MaxLength(100)]
        public string Residence { get; set; }
        
        [MaxLength(100)]
        public string FieldLanguage { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(120)]
        public string PrizeName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(600)]
        public string Motivation { get; set; }

        public int CompareTo(NobelPrizeWinner other)
        {
            if (this.Year == other.Year
                && this.Category == other.Category
                && this.Name == other.Name
                && this.BirthDate == other.BirthDate
                && this.BirthPlace == other.BirthPlace
                && this.Country == other.Country
                && this.Residence == other.Residence
                && this.FieldLanguage == other.FieldLanguage
                && this.PrizeName == other.PrizeName
                && this.Motivation == other.Motivation)
            {
                return 0;
            }
            return -1;
        }
    }
}
