using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class BankController : Controller
    {

        //Static in memory list to store bank details

        private static List<Bank> banks = new List<Bank>();


        //GET: Display form and submitted bank accounts
        [HttpGet]
        public IActionResult Create()
        {
            var latestAccounts = banks.OrderByDescending(e => e.Id).ToList();

            var totalBalance = latestAccounts.Sum(p => p.Balance);

            var model = new BankViewModel
            {
                //Show latest bank accounts first
                Banks = latestAccounts,
                TotalBalance = totalBalance
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Bank bank)
        {
            if (ModelState.IsValid)
            {
                banks.Add(bank);
            }

            var latestAccounts = banks.OrderByDescending(e => e.Id).ToList();

            var totalBalance = latestAccounts.Sum(p => p.Balance);

            var model = new BankViewModel
            {
                Banks = latestAccounts,
                TotalBalance = totalBalance,
                LatestAccountId = bank.Id
            };
            return View(model);
        }
    }

    //View Model to combine form data and list of banks accounts
    public class BankViewModel
    {
        //Form Input
        public Bank Bank { get; set; } = new Bank();

        // List of accounts
        public List<Bank> Banks { get; set; } = new List<Bank>();

        public decimal TotalBalance { get; set; }

        //Id of the latest account for highlighting
        public int LatestAccountId { get; set; } = 0;
    }
}
