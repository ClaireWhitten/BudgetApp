using BudgetApp.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    public class TransactionAddViewModel
    {
       
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        [MaxLength(200, ErrorMessage = "Maximum length of 200 characters.")]
        public string Description { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Display(Name ="Receipt/Photo")]
        public IFormFile Photo { get; set; }



    }
}
