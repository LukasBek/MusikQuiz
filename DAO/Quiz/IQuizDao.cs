using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public interface IQuizDao
    {
        Quiz AddQuiz(Quiz quiz);
        Quiz GetQuiz(string quizId);
        Quiz UpdateQuiz(string quizId, Quiz newQuiz);
        void DeleteQuiz(string quizId);

        void DeleteCategory(string quizId, string categoryId);
        void AddCategoryToQuiz(string quizId, Category category);

        List<Quiz> GetAllQuizForUser(string userId);
        List<Quiz> GetAllQuizzes();
        bool QuizExists(string quizId);

    }
    /*
     *     public class Quiz
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeChanged { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
     */
}
