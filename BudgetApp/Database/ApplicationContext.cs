using BudgetApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Database
{
    public class ApplicationContext : DbContext //inherit from DbContext
    {
        //constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        //dbsets

        public DbSet<Transaction> Transactions { get; set; }
       

    }
}
