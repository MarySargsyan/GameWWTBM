using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameWWTBM.Models;
using GameWWTBM.Repository;

namespace GameWWTBM.Controllers
{
    public class QuestionsController : Controller
    {
        private  ApplicationDbcontext _context;

        private IQuestins _questins;
        //public static int quantity;
        public static int points;
        public static int Fifty = 1;

        public QuestionsController(ApplicationDbcontext context, IQuestins questins)
        {
            _questins = questins;
            _context = context;
        }

        public ActionResult Index()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Index(int n)
        {
            return RedirectToAction("AllQuestions", new { });
        }

        public ActionResult AllQuestions(int n)
        {
            List<Questions> questions = _context.Questions.ToList();
            return View(questions);

        }
        public ActionResult Details(int? id)
        {
            if (Fifty == 1)
            {
                Questions questions = _context.Questions.Find(id);
                ViewBag.Answers = _context.Answers.Where(s => s.QuestionId == questions.Id).ToList();
                return View(questions);
            }
            else
            {
                return RedirectToAction("NOFif", new { id = id });
            }
            
        } 
        [HttpPost]
        public ActionResult Details(int? State, string e)
        {
            if (State == 2)
            {               
                return RedirectToAction("Correct");
            }
            else if (State == 1)
            {
                return RedirectToAction("Lose");
            }
            else return RedirectToAction("Index");

        }

        public ActionResult NOFif(int? id)
        {
            Questions questions = _context.Questions.Find(id);
            ViewBag.Answer = _context.Answers.Where(s => s.QuestionId == questions.Id).ToList();
            return View(questions);
        }
        [HttpPost]
        public ActionResult NOFif(int? State, string e)
        {
            if (State == 2)
            {
                return RedirectToAction("Correct");
            }
            else if (State == 1)
            {
                return RedirectToAction("Lose");
            }
            else return RedirectToAction("Index");

        }
        public ActionResult Lose()
        {
            points = 0;
            return View();
        }
        public ActionResult Correct()
        {
            points = points + (1000000/10);
            ViewBag.points = points;
            return View();
        } 
        public ActionResult Fifti(int? id)
        {
            Fifty = 0;
            Questions questionsl = _context.Questions.Find(id);
            ViewBag.Answers = _context.Answers.Where(s => s.QuestionId == questionsl.Id).ToList();
            return View(questionsl);
        }
        [HttpPost]
        public ActionResult Fifti(int? State, string e)
        {
            if (State == 2)
            {
                return RedirectToAction("Correct");
            }
            else if (State == 1)
            {
                return RedirectToAction("Lose");
            }
            else return RedirectToAction("Index");

        }

    }
}
