using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public interface IUserDao
    {
        Task<IdentityResult> AddUser(User user, string password);
        User GetUser(string userId);
        User GetUserFromUsername(string username);

        /// <summary>
        /// Deletes user and all their created quizzes!!!
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUser(string userId);

        bool UserNameIsTaken(string name);

        User AddQuizToUser(string userId, Quiz quiz);

        User RemoveQuizFromUser(string userId, string quizId);

        bool UserExists(string userId);


    }

    /*
     *     public class User : IdentityUser
    {
        public override string Id { get; set; }
        //public string Username { get; set; }
        public string Password { get; set; }
        public DateTime TimeCreated { get; set; }
        
    }
     */
}
