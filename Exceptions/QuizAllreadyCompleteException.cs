using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusikQuiz.DAO.Exceptions
{
    public class QuizAllreadyCompleteException : Exception
    {
        public QuizAllreadyCompleteException()
        {
        }

        public QuizAllreadyCompleteException(string message)
            : base(message)
        {
        }

        public QuizAllreadyCompleteException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
