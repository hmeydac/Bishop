namespace Bishop.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bishop.Model.Entities;

    public class HomeController : Controller
    {
        // GET: /Home/
        public ActionResult Index()
        {
            var fake = this.GetFakeSurveyData();
            return View(fake);
        }

        private Survey GetFakeSurveyData()
        {
            var survey = new Survey { Title = "Performance Review" };

            // Competencias Core
            var coreTopic = new Topic { Title = "Competencias Core" };

            var question = new Question { Id = 1, Text = "Comunicación con el Cliente" };
            var answers = new List<Answer>
                              {
                                  new Answer { Text = "1" },
                                  new Answer { Text = "2" },
                                  new Answer { Text = "3" },
                                  new Answer { Text = "4" },
                                  new Answer { Text = "5" },
                              };

            answers.ForEach(question.AddAnswer);

            coreTopic.AddQuestion(question);

            question = new Question { Id = 2, Text = "Autonomía en el trabajo" };
            answers = new List<Answer>
                              {
                                  new Answer { Text = "1" },
                                  new Answer { Text = "2" },
                                  new Answer { Text = "3" },
                                  new Answer { Text = "4" },
                                  new Answer { Text = "5" },
                              };

            answers.ForEach(question.AddAnswer);
            coreTopic.AddQuestion(question);

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

            answers.ForEach(question.AddAnswer);
            technicalTopic.AddQuestion(question);

            question = new Question { Id = 4, Text = "Indique los últimos 3 proyectos que ha trabajado", QuestionType = QuestionTypes.FreeText };

            technicalTopic.AddQuestion(question);

            // Topics
            var topics = new List<Topic>
                             {
                                coreTopic,
                                technicalTopic
                             };

            topics.ForEach(survey.AddTopic);
            return survey;
        }
    }
}
