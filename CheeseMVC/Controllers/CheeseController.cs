using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        //static private List<string> Cheeses = new List<string>();
        static private Dictionary<string,string> Cheeses = new Dictionary<string,string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            /*
             * List<string> cheeses = new List<string>();
            cheeses.Add("Cheddar");
            cheeses.Add("Munster");
            cheeses.Add("Parmesan");
            */

            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Del()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        public IActionResult DelMult()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }


        public IActionResult Index1()
        {
            return View("Index1");
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            // Add the new cheese to my existing cheeses
            if (ValidateCheese(name))
            {
                Cheeses.TryAdd(name, description);
                return Redirect("/Cheese");
            }

            ViewBag.inputError = " Input Error. Please use only Alphabetic characters and spaces.";
            return View("Add");
        }

        [HttpPost]
        [Route("/Cheese/Del")]
        public IActionResult DeleteCheese(string name)
        {
            // Add the new cheese to my existing cheeses
            Cheeses.Remove(name);

            return Redirect("/Cheese");
        }

        [HttpPost]
        [Route("/Cheese/DelMult")]
        public IActionResult DeleteMultipleCheeses(string[] list)
        {
            // Add the new cheese to my existing cheeses
            if(list.Length >= 0)
            {
                foreach (string chesse in list)
                {
                    Cheeses.Remove(chesse);
                }                    
            } 
                   
            return Redirect("/Cheese");
        }


        static public Boolean ValidateCheese(string input)
        {
            Regex rgx = new Regex(@"^[a-zA-Z ]*$");
            return rgx.IsMatch(input);
        }
    }
}
