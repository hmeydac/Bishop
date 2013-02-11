namespace Bishop.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Model;
    using Bishop.Model.Entities;
    using Bishop.Services;
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
            var viewModel = this.GetViewModel();
            return this.View(viewModel);
        }

        public IEnumerable<UserForm> GetViewModel()
        {
            var formService = DependencyLocator.Locator.Resolve<IFormService>();
            return formService.GetList().Select(Mapper.Map<UserForm>).ToArray();
        }

        public ActionResult GenerateData()
        {
            // Act
            var context = new FormsContext();

            // Clear existing data
            context.Answers.ToList().ForEach(answer => context.Answers.Remove(answer));
            context.Questions.ToList().ForEach(question => context.Questions.Remove(question));
            context.Topics.ToList().ForEach(topic => context.Topics.Remove(topic));
            context.Forms.ToList().ForEach(form => context.Forms.Remove(form));

            // Add Default Sample Data
            this.SaveData(context);

            return this.View();
        }

        private void SaveData(FormsContext context)
        {
            var form = new Form { Title = "Performance Review" };
            var topic = new Topic { Title = "Competencias Core" };
            form.Topics.Add(topic);
            topic.Questions.Add(this.GetQuestion("Comunicación con sus pares"));
            topic.Questions.Add(this.GetQuestion("Comunicación con el cliente"));
            topic.Questions.Add(this.GetQuestion("Administración de sus tareas"));
            topic.Questions.Add(this.GetQuestion("Cumplimiento de tareas"));

            topic = new Topic { Title = "Competencias Técnicas" };
            form.Topics.Add(topic);
            topic.Questions.Add(this.GetQuestion("Conocimiento Técnico"));
            topic.Questions.Add(this.GetQuestion("Resolución de Problemas Complejos"));
            topic.Questions.Add(this.GetNetChoiceQuestion("Versiones de .NET Trabajadas"));
            topic.Questions.Add(this.GetPlatformChoiceQuestion("Plataformas Trabajadas"));

            topic = new Topic { Title = "Feedback" };
            form.Topics.Add(topic);
            topic.Questions.Add(this.GetFreeTextQuestion("Relación con el manager"));
            topic.Questions.Add(this.GetFreeTextQuestion("Relación con sus pares"));
            topic.Questions.Add(this.GetFreeTextQuestion("Qué opinas de la empresa?"));

            context.Forms.Add(form);
            context.SaveChanges();
        }

        private Question GetFreeTextQuestion(string questionText)
        {
            var question = new Question { Text = questionText, QuestionType = QuestionTypes.FreeText };
            return question;
        }

        private Question GetPlatformChoiceQuestion(string questionText)
        {
            var question = new Question { Text = questionText, QuestionType = QuestionTypes.MultipleChoice };
            question.Answers.Add(new Answer { Text = "Desktop" });
            question.Answers.Add(new Answer { Text = "Web" });
            question.Answers.Add(new Answer { Text = "Mainframe" });
            question.Answers.Add(new Answer { Text = "Mobile" });
            question.Answers.Add(new Answer { Text = "Otros" });
            return question;
        }

        private Question GetNetChoiceQuestion(string questionText)
        {
            var question = new Question { Text = questionText, QuestionType = QuestionTypes.MultipleChoice };
            question.Answers.Add(new Answer { Text = "1.1" });
            question.Answers.Add(new Answer { Text = "2.0" });
            question.Answers.Add(new Answer { Text = "3.5" });
            question.Answers.Add(new Answer { Text = "4" });
            question.Answers.Add(new Answer { Text = "4.5" });
            return question;
        }

        private Question GetQuestion(string questionText)
        {
            var question = new Question { Text = questionText };
            this.SetDefaultAnswers(question);
            return question;
        }

        private void SetDefaultAnswers(Question question)
        {
            question.Answers.Add(new Answer { Text = "1" });
            question.Answers.Add(new Answer { Text = "2" });
            question.Answers.Add(new Answer { Text = "3" });
            question.Answers.Add(new Answer { Text = "4" });
            question.Answers.Add(new Answer { Text = "5" });
        }
    }
}
