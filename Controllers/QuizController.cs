using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusikQuiz.DAO;
using MusikQuiz.Data;
using MusikQuiz.DTO;
using MusikQuiz.Models;

namespace MusikQuiz.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuizDao _quizDao;
        private readonly IMapper _mapper;

        public QuizController(ApplicationDbContext context, IQuizDao quizDao, IMapper mapper)
        {
            _context = context;
            _quizDao = quizDao;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz([FromRoute] string id)
        {
            var quiz = _quizDao.GetQuiz(id);

            if (quiz == null)
            {
                return StatusCode(400, "Quiz wit hid: " + id + " does not exists");
            }

            var returnQuiz = _mapper.Map<QuizVmSingle>(quiz);

            return Ok(returnQuiz);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = _quizDao.GetAllQuizzes();

            List<QuizVmSingle> quizVmList = new List<QuizVmSingle>();

            foreach (Quiz quiz in quizzes)
            {
                var quizVm = _mapper.Map<QuizVmSingle>(quiz);
                quizVmList.Add(quizVm);
            }

            return Ok(quizVmList);
        }

        [HttpGet("{tag}")]
        public async Task<IActionResult> GetAllQuizWithTag([FromRoute] string tag)
        {
            var quizzes = _quizDao.GetAllQuizzes();

            List<QuizVmSingle> quizVmList = new List<QuizVmSingle>();

            foreach (Quiz quiz in quizzes)
            {
                var quizVm = _mapper.Map<QuizVmSingle>(quiz);
                if (quizVm.Tags.Any(x => x.Name == tag))
                {
                    quizVmList.Add(quizVm);
                }
            }

            return Ok(quizVmList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] QuizImDto quizIm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var quiz = _mapper.Map<Quiz>(quizIm);
                quiz.TimeCreated = DateTime.Now;
                quiz.TimeChanged = DateTime.Now;

                var result = _quizDao.AddQuiz(quiz);

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error in creating Qui: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz([FromRoute] string quizId)
        {
            if (!_quizDao.QuizExists(quizId))
            {
                return StatusCode(404, "Quiz with id: " + quizId + " was not found");
            }

            _quizDao.DeleteQuiz(quizId);
            return StatusCode(200, "Quiz with id: " + quizId + " have been succesfully deleted");
        }

        [HttpPost]
        public IActionResult UpdateQuiz([FromRoute] QuizImDto quizIm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldQuiz = _quizDao.GetQuiz(quizIm.Id);
            var updatedQuiz = _mapper.Map<Quiz>(quizIm);
            updatedQuiz.TimeCreated = oldQuiz.TimeCreated;
            updatedQuiz.TimeChanged = DateTime.Now;
            
            var quiz = _quizDao.UpdateQuiz(quizIm.Id, updatedQuiz);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }
    }
}
