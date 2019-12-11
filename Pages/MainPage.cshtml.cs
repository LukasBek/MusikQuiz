using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MusikQuiz.Pages
{
    public class Index1Model : PageModel
    {
        public string Username { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");
        }
    }
}
