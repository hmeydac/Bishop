namespace Bishop.IntegrationTests
{
    using System;
    using System.Linq;

    using Bishop.Model;
    using Bishop.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataGenerationTests
    {
        [TestMethod]
        public void DatabaseInitialize()
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
            var forms = context.Forms;
            var topics = context.Topics;
            var answers = context.Answers;
            var questions = context.Questions;

            // Assert
            Assert.IsNotNull(forms);
            Assert.IsNotNull(topics);
            Assert.IsNotNull(questions);
            Assert.IsNotNull(answers);
            Assert.IsTrue(forms.Any());
            Assert.IsTrue(topics.Any());
            Assert.IsTrue(questions.Any());
            Assert.IsTrue(answers.Any());
        }

        private void SaveData(FormsContext context)
        {
            var form = new Form { Id = Guid.NewGuid(), Title = "Performance Review" };
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
