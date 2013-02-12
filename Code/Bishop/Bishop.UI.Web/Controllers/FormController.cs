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
        private IFillingSessionService fillingSessionService;

        private IFormService formService;

        public FormController(IFormService formService, IFillingSessionService fillingSessionService)
        {
            this.fillingSessionService = fillingSessionService;
            this.formService = formService;
        }

        public ActionResult Index()
        {
            // Does nothing.
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Template(Guid formId, Guid sid)
        {
            var formData = this.GetFormTemplate(formId);
            var session = this.GetSession(sid);
            
            // TODO: Use the Session to Save Data or Validate Expiration
            var viewModel = this.ConstructViewModel(formData);
            return this.View(viewModel);
        }

        private FillingSession GetSession(Guid sid)
        {
            return this.fillingSessionService.Get(sid);
        }

        private Form GetFormTemplate(Guid formId)
        {
            var formData = this.formService.Get(formId);
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
