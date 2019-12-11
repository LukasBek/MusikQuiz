using System;
using System.Collections.Generic;
using System.Linq;
using MusikQuiz.DAO.Exceptions;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public class QuizDao : IQuizDao
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDao _userDao;

        public QuizDao(ApplicationDbContext context, IUserDao userDao)
        {
            _context = context;
            _userDao = userDao;
        }


        public Quiz AddQuiz(Quiz quiz)
        {
            _context.Add(quiz);
            _context.SaveChanges();

            return quiz;
        }

        public Quiz GetQuiz(string quizId)
        {
            return _context.Quiz.SingleOrDefault(x => x.Id.Equals(quizId));
        }

        public Quiz UpdateQuiz(string quizId, Quiz newQuiz)
        {
            var quiz = GetQuiz(quizId);
            quiz = newQuiz;

            _context.SaveChanges();

            return quiz;
        }

        public void DeleteQuiz(string quizId)
        {
            var quiz = GetQuiz(quizId);

            _context.Quiz.Remove(quiz);
            _context.SaveChanges();
        }

        public void DeleteCategory(string quizId, string categoryId)
        {
            var quiz = GetQuiz(quizId);
            ICollection<Category> categories = quiz.Categories;

            foreach (Category category in categories)
            {
                if (string.Compare(category.Id, categoryId) == 0)
                {
                    categories.Remove(category);
                }
            }

            _context.SaveChanges();
        }

        public void AddCategoryToQuiz(string quizId, Category category)
        {
            var quiz = GetQuiz(quizId);
            ICollection<Category> categories = quiz.Categories;

            if (categories.Count >= 5)
            {
                throw new QuizAllreadyCompleteException("The quiz with id: "+quizId+" already have 5 categories");
            }
            else
            {
                categories.Add(category);
                _context.SaveChanges();
            }
            
        }

        public List<Quiz> GetAllQuizForUser(string userId)
        {
            return _userDao.GetUser(userId).CreatedQuizzes.ToList();
        }

        public List<Quiz> GetAllQuizzes()
        {
            return _context.Quiz.ToList();
        }

        public bool QuizExists(string quizId)
        {
            return _context.Quiz.Any(x => x.Id == quizId);
        }

    }
}
