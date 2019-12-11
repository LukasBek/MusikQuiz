using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MusikQuiz.Controllers;

namespace MusikQuiz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserController _userController;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Id { get; set; }

        public string Msg { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!(Username == null || Password == null))
            {
                if (Username.Equals("lukas") && Password.Equals("123"))
                {
                    //var url = _
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("MainPage");
                }
            }

            return Page();

        }
    }
}
