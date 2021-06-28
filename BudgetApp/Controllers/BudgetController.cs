using BudgetApp.Database;
using BudgetApp.Domain;
using BudgetApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IRepository budgetRepository;

        private readonly IWebHostEnvironment hostEnvironment;


        //CONSTRUCTOR
        public BudgetController(IRepository budgetRepository, IWebHostEnvironment hostEnvir)
        {
            this.budgetRepository = budgetRepository;
            this.hostEnvironment = hostEnvir;
        }



        
        // ACTIONS
        //Overview of transactions
        public IActionResult Index()
        {
            var vm = budgetRepository.GetTransactions().Select(t => new TransactionListViewModel
            {
                Id = t.Id,
                Date = t.Date,
                Amount = t.Amount,
                TransactionType = t.TransactionType,

            });
            
            return View(vm);
        }

        // show add form
        public IActionResult Add()
        {
            return View();
        }



        // add new transaction from form
        [HttpPost]
        public IActionResult Add([FromForm] TransactionAddViewModel vm)
        {
            if(TryValidateModel(vm))
            {
                Transaction newTransaction = new Transaction
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    Date = vm.Date,
                    Amount = vm.Amount,
                    TransactionType = vm.TransactionType,
                    //not working: value not saving  - fix https://www.youtube.com/watch?v=ycSvlOFobgY
                };
                if (CheckPhotoUploaded(vm.Photo))
                {
                    newTransaction.ReceiptPhotoUrl = SetPhotoUrl(newTransaction,vm.Photo);
                }

                budgetRepository.AddTransaction(newTransaction);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }






        //Methods 
        private bool CheckPhotoUploaded(IFormFile photo)
        {
            if (photo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private string SetPhotoUrl(Transaction transaction, IFormFile photo)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

            string path = Path.Combine("/Photos", fileName);

            transaction.ReceiptPhotoUrl = path;

            return path;

        }
    }
}
