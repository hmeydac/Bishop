namespace Bishop.UI.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Framework.Exceptions;
    using Bishop.Model;
    using Bishop.Model.Entities;
    using Bishop.Repositories;
    using Bishop.Services;
    using Bishop.UI.Web.Models.Forms;

    public class FormController : Controller
    {
        private readonly FormService formService;

        public FormController()
            : this(new FormService(new EntityFrameworkUnitOfWork(new FormsContext())))
        {
        }

        public FormController(FormService formService)
        {
            this.formService = formService;
        }

        public ActionResult Index()
        {
            // Does nothing.
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Template(Guid formId)
        {
            var formData = this.GetFormTemplate(formId);
            var viewModel = this.ConstructViewModel(formData);
            return this.View(viewModel);
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
