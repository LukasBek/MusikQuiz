using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public class UserDao : IUserDao
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public UserDao(ApplicationDbContext ctx, UserManager<User> userManager)
        {
            _context = ctx;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public User GetUser(string userId)
        {
            return _context.Users.SingleOrDefault(x => x.Id.Equals(userId));
        }

        public User GetUserFromUsername(string username)
        {
            return _context.User.SingleOrDefault(x => x.UserName.Equals(username));
        }

        public void DeleteUser(string userId)
        {
            var user = GetUser(userId);

            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public bool UserNameIsTaken(string name)
        {
            var user = GetUserFromUsername(name);
            if (user != null)
            {
                return true;
            }

            return false;

        }

        public User AddQuizToUser(string userId, Quiz quiz)
        {
            var user = GetUser(userId);
            user.CreatedQuizzes.Add(quiz);

            _context.SaveChanges();

            return user;
        }

        public User RemoveQuizFromUser(string userId, string quizId)
        {
            var user = GetUser(userId);
            var quiz = user.CreatedQuizzes.SingleOrDefault(x => x.Id == quizId);
            user.CreatedQuizzes.Remove(quiz);

            _context.SaveChanges();

            return user;
        }

        public bool UserExists(string userId)
        {
            return _userManager.Users.Any(x => x.Id == userId);
        }
    }
}
