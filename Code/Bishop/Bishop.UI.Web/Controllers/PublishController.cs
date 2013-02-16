using System.Web.Mvc;

namespace Bishop.UI.Web.Controllers
{
    using System.Linq;

    using AutoMapper;

    using Bishop.Services;
    using Bishop.UI.Web.Models.Forms;

    public class PublishController : Controller
    {
        private readonly IPublishedFormService publishedFormService;

        public PublishController(IPublishedFormService publishedFormService)
        {
            this.publishedFormService = publishedFormService;
        }

        // GET: /Publish/
        public ActionResult Index()
        {
            var forms = this.publishedFormService.GetAllActive();
            var viewModel = forms.Select(Mapper.Map<PublicationViewModel>).ToArray();
            return View(viewModel);
        }

    }
}
