using System.ComponentModel.DataAnnotations;

namespace Evaluation.Dtos
{
    public class CustomerDto
    {
        public int CustomerNumber { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TransactionHistory { get; set; }
    }
}
