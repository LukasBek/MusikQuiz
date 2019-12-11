using System;
using System.Collections.Generic;
using MusikQuiz.Models;

namespace MusikQuiz.DTO
{
    public class UserImDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserImNewPassDto
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class UserVmDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime TimeCreated { get; set; }
        public ICollection<Quiz> QuizzesCreated { get; set; }
    }

}
