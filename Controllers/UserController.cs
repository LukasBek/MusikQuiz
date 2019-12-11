using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusikQuiz.DAO;
using MusikQuiz.DTO;
using MusikQuiz.Models;
using MusikQuiz.Utility;

namespace MusikQuiz.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserDao _userDAO;
        private readonly IMapper _mapper;

        public UserController(IUserDao iUserDao, UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _userDAO = iUserDao;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var user = _userDAO.GetUser(id);
            return Ok(_mapper.Map<UserVmDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserImDto userIm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = _mapper.Map<User>(userIm);
            user.TimeCreated = DateTime.Now;
            user.CreatedQuizzes = null;

            var result = await _userDAO.AddUser(user, user.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ErrorsForModelState.AddErrorsToModelState(result, ModelState));
            }

            return new OkObjectResult("User succesfully created");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword([FromBody] UserImNewPassDto newPasswordUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userDAO.GetUserFromUsername(newPasswordUser.Username);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var update = await _userManager.ChangePasswordAsync(user, newPasswordUser.OldPassword, newPasswordUser.NewPassword);
            if (update.Succeeded)
            {
                return Ok("Password updated");
            }
            else
            {
                return StatusCode(500, "Something went wrong: " + update.Errors);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] string userId)
        {
            if (!_userDAO.UserExists(userId))
            {
                return StatusCode(404, "User with id: " + userId + " was not found");
            }

            _userDAO.DeleteUser(userId);
            return StatusCode(200, "User with id: " + userId + " have been deleted");
        }


        [HttpPost]
        public async Task<IActionResult> AddQuizToUser([FromBody] QuizImDto newQuiz)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = _mapper.Map<Quiz>(newQuiz);

            var result = _userDAO.AddQuizToUser(newQuiz.UserId, quiz);

            return Ok(result);
        }
    }
}
