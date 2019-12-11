using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz
{
    public class TestModel : PageModel
    {
        private readonly MusikQuiz.Data.ApplicationDbContext _context;

        public TestModel(MusikQuiz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; }

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quiz.ToListAsync();
        }
    }
}
