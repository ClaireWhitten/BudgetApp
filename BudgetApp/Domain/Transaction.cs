using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Domain
{

    public enum TransactionType
    {
        Incoming, Outgoing
    }

    public class Transaction
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        [MaxLength(200, ErrorMessage ="Maximum length of 200 characters.")]
        public string Description { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        public string ReceiptPhotoUrl { get; set; }



    }
}
