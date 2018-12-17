using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quote(string FirstName, string LastName, string EmailAddress, DateTime DOB, string CarYear, string CarMake, string CarModel, string DUI, string Tickets, string coverage)
        {
            //try
           // {
                
                decimal cost = 50;
                var quotes = new List<QuoteModel>();
                var q = new CarInsurance.Models.QuoteModel();
                q.FirstName = FirstName;
                q.LastName = LastName;
                q.EmailAddress = EmailAddress;
                q.cost = 50;


                var AgeCheck = DateTime.Now.Year - DOB.Year;

                if (AgeCheck < 18)
                {
                    cost += 100;
                }
                else if (AgeCheck < 25)
                {
                    cost += 25;
                }
                else if (AgeCheck > 100)
                {
                    cost += 25;
                }

                if (Convert.ToInt32(CarYear) < 2000)
                {
                    cost += 25;
                }
                else if (Convert.ToInt32(CarYear) > 2015)
                {
                    cost += 25;
                }
                var make = CarMake.ToLower();
                if (make == "porche")
                {
                    cost += 25;
                }
                var model = CarModel.ToLower();
                if (make == "porche" && model == "911 carrera")
                {
                    cost += 25;
                }

                for (int i = 0; i < Convert.ToInt32(Tickets); i++)
                {
                    cost += 10;
                }
                var dui = DUI.ToLower();
                if (dui == "yes")
                {
                    cost = cost + (cost / 4);
                }
                var cov = coverage.ToLower();
                if (cov == "a")
                {
                    cost = cost + (cost / 2);
                }
                cost = TruncateDecimal(cost, 2);
                q.cost = Convert.ToDouble(cost);
                quotes.Add(q);
                using (QuotesEntities1 db = new QuotesEntities1())
                {
                    var Q = new QuoteModel();
                    Q.FirstName = FirstName;
                    Q.LastName = LastName;
                    Q.EmailAddress = EmailAddress;
                    db.QuoteModels.Add(Q);
                    db.SaveChanges();
                }
                return View(quotes);
           // }
            //catch
           // {
                //return View("Error");
            //}

        }
        private decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }
    }
}