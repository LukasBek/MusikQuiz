using System.Collections.Generic;
using MusikQuiz.Models;

namespace MusikQuiz.DTO
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string WhatToGuess { get; set; }
        public string BonusPoints { get; set; }
        public ICollection<Sound> Sounds { get; set; }

    }
}
