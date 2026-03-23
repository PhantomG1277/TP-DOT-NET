using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class Form
    {
        [Required]
        public string? Nom { get; set; }

        [Required]
        public string? Prenom { get; set; }

        [Required]
        public string? Genre { get; set;}

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string? Adresse {  get; set;}

        [Required]
        [RegularExpression(@"^\d{5}$")]
        public int? CodePostal { get; set; }
        
        [Required]
        public string? Ville { get; set; }

        [Required]
        [EmailAddress]
        public string? AdresseCourriel { get; set; }

        [Required]
        [DataType(DataType.Date)]

        public DateTime? DateDebut { get; set; }

        [Required]
        public string? Formation { get; set; }

        [Required]
        public string? AvisMainframe { get; set; }

        [Required]
        public string? AvisCs {  get; set; }
    }
}
