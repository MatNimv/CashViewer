using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class Expense
    {
        public int Id { get; set; }

        //Value CAN be 0
        public decimal Value { get; set; }

        [Required] //HAVE to enter a value. description
        //can't be empty. ? means nullable
        public string? Description { get; set; } 
    }
}
