using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusikQuiz.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public string Password { get; set; }
        public DateTime TimeCreated { get; set; }
        public ICollection<Quiz> CreatedQuizzes { get; set; }
        
    }
}
