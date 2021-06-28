using BudgetApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BudgetApp.Database
{
    public interface IRepository
    {
        IEnumerable<Transaction> GetTransactions();

        Transaction GetTransaction(int id);

        void AddTransaction(Transaction transaction);

        void DeleteTransaction(int id);

        void UpdateTransaction(Transaction transaction);


    }
}
