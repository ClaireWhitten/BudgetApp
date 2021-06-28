using BudgetApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BudgetApp.Database
{
    public class BudgetRepository : IRepository //implements repository interface
    {
        private readonly ApplicationContext ctx;


        public BudgetRepository(ApplicationContext ctx)
        {
            this.ctx = ctx;

        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return ctx.Transactions;
        }


        public Transaction GetTransaction(int id)
        {
            return ctx.Transactions.FirstOrDefault(t => t.Id == id);
        }

        public void AddTransaction(Transaction transaction)
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();
        }


        public void DeleteTransaction(int id)
        {
            Transaction transaction = GetTransaction(id);
            if (transaction != null)
            {
                ctx.Transactions.Remove(transaction);
            }
        }

        public void UpdateTransaction(Transaction transaction)
        {
            ctx.SaveChanges();
        }

        
    }
}
