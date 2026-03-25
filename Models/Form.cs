using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPLOCAL1.Models
{
    public class Form
    {
        [Required(ErrorMessage ="Ce champ est obligatoire")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string? Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string? Genre { get; set;}

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(100, MinimumLength = 5,ErrorMessage ="L'adresse doit être comprise entre 10 et 100 caractères")]
        public string? Adresse {  get; set;}

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Il faut 5 numéros"),  ]
        public string? CodePostal { get; set; }
        
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string? Ville { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)", ErrorMessage = "Ce n'est pas un email")]
        public string? AdresseCourriel { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Date,ErrorMessage = "Ce n'est pas une date")]
        [Range(typeof(DateTime),"01/01/0001","01/01/2021",ErrorMessage = "La date n'est pas prise en charge")]
        
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string? Formation { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string? AvisMainframe { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string? AvisCs {  get; set; }
    }
}
