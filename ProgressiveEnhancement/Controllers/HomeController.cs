using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgressiveEnhancement.Models;

namespace ProgressiveEnhancement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ContactUs()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ContactUs");
            }

            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUsInput input)
        {
            // Validate the model being submitted
            if (!ModelState.IsValid)
            {
                // If the incoming request is an Ajax Request 
                // then we just return a partial view (snippet) of HTML 
                // instead of the full page
                if (Request.IsAjaxRequest())
                    return PartialView("_ContactUs", input);

                return View(input);
            }

            // TODO: A real app would send some sort of email here

            if (Request.IsAjaxRequest())
            {
                // Same idea as above
                return PartialView("_ThanksForFeedback", input);
            }

            // A standard (non-Ajax) HTTP Post came in
            // set TempData and redirect the user back to the Home page
            TempData["Message"] = string.Format("Thanks for the feedback, {0}! We will contact you shortly.", input.Name);
            return RedirectToAction("Index");
        }

    }
}
