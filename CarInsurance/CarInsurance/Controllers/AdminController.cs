using CarInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
           
            using (QuotesEntities1 db = new QuotesEntities1())
            {
                var DBquotes = db.QuoteModels.ToList();
                var QuoteList = new List<QuoteModel>();
                foreach (var q in DBquotes)
                {
                    var quotes = new QuoteModel();
                    quotes.FirstName = q.FirstName;
                    quotes.LastName = q.LastName;
                    quotes.EmailAddress = q.EmailAddress;
                    QuoteList.Add(quotes);
                }

                return View(QuoteList);

            }
            
        }
    }
}