using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        //will return the View with the exact name as the method ()
        public IActionResult Expenses() 
        {
            //goes to the db. goes to the Expense table. puts all of the values
            //into a c# list
            var allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x => x.Value);
            ViewBag.Expenses = totalExpenses;

            return View(allExpenses); 
        }
        public IActionResult CreateEditExpense(int? id)
        {
            if(id != null)
            {
                //editing -> load an expense by id
                var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
                return View(expenseInDb);
            }
            return View();
        }

        public IActionResult DeleteExpense (int id)
        {
            //take the first expense where the id compares to the one we sent
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        //sends the form to Index
        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                //create
                //when it says context, always think of the database
                _context.Expenses.Add(model);
            } else
            {
                //editing
                _context.Expenses.Update(model);
            }

            //if(model.Description == null)
            //{
            //    ModelState.AddModelError("Description", "Description is required.");
            //    return RedirectToAction("CreateEditExpense"); // Stay on the same page and display the form again with the validation message.
            //}
            //else
            //{
//
            //}
            //not only do we need to add, but also SAVE the changes
            _context.SaveChanges();
            return RedirectToAction("Expenses");


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
