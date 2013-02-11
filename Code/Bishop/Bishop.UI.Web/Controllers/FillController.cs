namespace Bishop.UI.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Bishop.Services;

    public class FillController : Controller
    {
        // GET: /Fill/
        public ActionResult Back()
        {
            return this.RedirectToAction("Index", "Home");
        }

        // GET: /Fill/:id
        public ActionResult Index(Guid? id)
        {
            if (!id.HasValue)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var sessionService = DependencyLocator.Locator.Resolve<IFillingSessionService>();
            var session = sessionService.StartNewSession();
            return this.RedirectToAction("Template", "Form", new { formId = id, sid = session.Id });
        }
    }
}
