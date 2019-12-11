using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    interface ICategoryDao
    {
        Category AddCategory(Category category);
        Category GetCategory(string categoryId);
        void UpdateCategory(string categoryId, Category newCategory);
        void DeleteCategory(string categoryId);
    }

    /**
     *     {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WhatToGuess { get; set; }
        public string BonusPoints { get; set; }
        public ICollection<Sound> Sounds { get; set; }
    }
     */
}
