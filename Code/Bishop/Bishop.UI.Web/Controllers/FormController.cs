namespace Bishop.UI.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Framework.Exceptions;
    using Bishop.Model.Entities;
    using Bishop.Services;
    using Bishop.UI.Web.Models.Forms;

    public class FormController : Controller
    {
        public ActionResult Index()
        {
            // Does nothing.
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Template(Guid formId, Guid sid)
        {
            var formData = this.GetFormTemplate(formId);
            var session = this.GetSession(sid);
            var viewModel = this.ConstructViewModel(formData);
            return this.View(viewModel);
        }

        private FillingSession GetSession(Guid sid)
        {
            var fillingSessionService = DependencyLocator.Locator.Resolve<IFillingSessionService>();
            return fillingSessionService.Get(sid);
        }

        private Form GetFormTemplate(Guid formId)
        {
            var formService = DependencyLocator.Locator.Resolve<IFormService>();
            var formData = formService.Get(formId);
            if (formData == null)
            {
                throw new NotFoundException(string.Format("Can't find template with Id {0}", formId));
            }

            return formData;
        }

        private UserForm ConstructViewModel(Form formData)
        {
            var userForm = Mapper.Map<UserForm>(formData);
            return userForm;
        }
    }
}
