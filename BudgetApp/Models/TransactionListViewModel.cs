using BudgetApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    public class TransactionListViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }





    }
}
