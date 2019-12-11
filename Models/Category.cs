using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusikQuiz.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WhatToGuess { get; set; }
        public string BonusPoints { get; set; }
        public ICollection<Sound> Sounds { get; set; }
    }
}
