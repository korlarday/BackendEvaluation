using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Merchant
    {
        [Key]
        public int MerchantNumber { get; set; }
        public int BusinessID { get; set; }
        [MaxLength(500)]
        public string BusinessName { get; set; }
        [MaxLength(255)]
        public string ContactName { get; set; }
        [MaxLength(255)]
        public string ContactSurname { get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public string AverageTransactionVolume { get; set; }
    }

    
}
