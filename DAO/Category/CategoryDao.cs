using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public class CategoryDao : ICategoryDao
    {
        private readonly ApplicationDbContext _context;

        public CategoryDao(ApplicationDbContext context)
        {
            _context = context;
        }


        public Category AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category GetCategory(string categoryId)
        {
            return _context.Category.SingleOrDefault(x => x.Id.Equals(categoryId));
        }

        public void UpdateCategory(string categoryId, Category newCategory)
        {
            var category = GetCategory(categoryId);
            category = newCategory;

            _context.SaveChanges();
        }

        public void DeleteCategory(string categoryId)
        {
            var category = GetCategory(categoryId);

            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}
