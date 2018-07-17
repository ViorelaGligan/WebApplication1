using Foolproof;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    using System;

    public class BankAccount
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "This field must be 24 characters")]
        public string IBAN { get; set; }
        
        [Required]
        public CurencyEnum Curency { get; set; }

        [Required]
        [StringLength(100)]
        public string Alias { get; set; }

        public bool PersoanaJuridica { get; set; }

        [RequiredIfTrue("PersoanaJuridica")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "This field must be 12 characters")]
        public string CIF { get; set; }
    }

    public enum CurencyEnum
    {
    RON,
    EUR,
    USD

    }
}