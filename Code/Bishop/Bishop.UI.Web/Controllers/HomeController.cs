namespace Bishop.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Model.Entities;
    using Bishop.UI.Web.Models.Forms;

    using Answer = Bishop.Model.Entities.Answer;
    using Question = Bishop.Model.Entities.Question;
    using QuestionTypes = Bishop.Model.Entities.QuestionTypes;
    using Topic = Bishop.Model.Entities.Topic;

    public class HomeController : Controller
    {
        // GET: /Home/
        public ActionResult Index()
        {
            var formData = this.GetFakeSurveyData();
            var viewModel = this.ConstructViewModel(formData);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UserForm formData)
        {
            // TODO: Save form data into database.

            // Remove: Re-loading form with same data
            var data = this.GetFakeSurveyData();
            var viewModel = this.ConstructViewModel(data);
            return this.View(viewModel);
        }

        private UserForm ConstructViewModel(Form formData)
        {
            var userForm = Mapper.Map<UserForm>(formData);
            return userForm;
        }

        private Form GetFakeSurveyData()
        {
            var survey = new Form { Title = "Performance Review" };

            // Competencias Core
            var coreTopic = new Topic { Title = "Competencias Core" };

            var question = new Question { Id = 1, Text = "Comunicación con el Cliente" };
            var answers = new List<Answer>
                              {
                                  new Answer { Id = 1, Text = "1" },
                                  new Answer { Id = 2, Text = "2" },
                                  new Answer { Id = 3, Text = "3" },
                                  new Answer { Id = 4, Text = "4" },
                                  new Answer { Id = 5, Text = "5" },
                              };

            answers.ForEach(question.Answers.Add);

            coreTopic.Questions.Add(question);

            question = new Question { Id = 2, Text = "Autonomía en el trabajo" };
            answers = new List<Answer>
                          {
                              new Answer { Id = 6, Text = "1" },
                              new Answer { Id = 7, Text = "2" },
                              new Answer { Id = 8, Text = "3" },
                              new Answer { Id = 9, Text = "4" },
                              new Answer { Id = 10, Text = "5" },
                          };

            answers.ForEach(question.Answers.Add);
            coreTopic.Questions.Add(question);

            // Competencias Tecnicas
            var technicalTopic = new Topic { Title = "Competencias Técnicas" };

            question = new Question { Id = 3, Text = "Qué versiones de .NET ha trabajado?", QuestionType = QuestionTypes.MultipleChoice };
            answers = new List<Answer>
                              {
                                  new Answer { Text = "1.1" },
                                  new Answer { Text = "2.0" },
                                  new Answer { Text = "3.5" },
                                  new Answer { Text = "4" },
                                  new Answer { Text = "4.5" },
                              };

            answers.ForEach(question.Answers.Add);
            technicalTopic.Questions.Add(question);

            question = new Question { Id = 4, Text = "Indique los últimos 3 proyectos que ha trabajado", QuestionType = QuestionTypes.FreeText };

            technicalTopic.Questions.Add(question);

            // Topics
            var topics = new List<Topic>
                             {
                                coreTopic,
                                technicalTopic
                             };

            topics.ForEach(survey.Topics.Add);
            return survey;
        }
    }
}
