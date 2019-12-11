using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Models;

namespace MusikQuiz.DTO
{
    public class QuizImDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Category> Categories { get; set; }
    }

    public class QuizVmMain
    {
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeChanged { get; set; }
        public ICollection<Category> Categories { get; set; }
    }

    public class QuizVmSingle
    {
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
