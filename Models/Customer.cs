using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TransactionHistory { get; set; }
    }

}
