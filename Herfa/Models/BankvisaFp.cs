using System;
using System.Collections.Generic;

#nullable disable

namespace Herfa.Models
{
    public partial class BankvisaFp
    {
        public decimal Id { get; set; }
        public string Cardnumber { get; set; }
        public string Cardholdername { get; set; }
        public string Cvv { get; set; }
        public DateTime Expirationdate { get; set; }
        public decimal? Availablebalance { get; set; }
    }
}
