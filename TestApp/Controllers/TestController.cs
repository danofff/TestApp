using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Help;
using TestApp.Infrastructure;

namespace TestApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ContextHandler DbHandler = new ContextHandler();
            var subjects = DbHandler.GetSubjects();
            return View(subjects);
        }

        [HttpPost]
        public JsonResult GetTestList(int subjectId)
        {
            ContextHandler DbHandler = new ContextHandler();
            var tests = DbHandler.GetTestsBySubjectId(subjectId);
            return Json(tests);

        }
    }
}