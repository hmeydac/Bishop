namespace Bishop.UI.Web.Tests.Controllers
{
    using AutoMapper;

    using Bishop.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Answer = Bishop.Model.Entities.Answer;
    using Question = Bishop.Model.Entities.Question;
    using Topic = Bishop.Model.Entities.Topic;

    [TestClass]
    public class HomeControllerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            // Create Maps for Model and ViewModel
            Mapper.CreateMap<Form, Models.Forms.UserForm>();
            Mapper.CreateMap<Topic, Models.Forms.Topic>();
            Mapper.CreateMap<Question, Models.Forms.Question>();
            Mapper.CreateMap<Answer, Models.Forms.Answer>();
        }
    }
}
