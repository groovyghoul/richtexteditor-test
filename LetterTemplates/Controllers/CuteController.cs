using RTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LetterTemplates.Controllers
{
    public class CuteController : Controller
    {
        public ActionResult Index()
        {
            var edt = new Editor(System.Web.HttpContext.Current, "Editor1");
            edt.EncodeHiddenValue = true;
            edt.MvcInit();
            ViewBag.Editor = edt.MvcGetString();
            return View();
        }

        [HttpPost]
        public ActionResult SaveToPdf()
        {
            Editor edt = new Editor(System.Web.HttpContext.Current, "Editor1");
            edt.EncodeHiddenValue = true;
            string content = Request.Form["Editor1"];

            if (!string.IsNullOrEmpty(content))
            {
                edt.LoadFormData(content);
                edt.SavePDF(@"c:\temp\letter.pdf");
            }
            return Content("Everything is funky");
        }
    }
}