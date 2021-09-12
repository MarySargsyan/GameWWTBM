using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameWWTBM.Models;
using GameWWTBM.Repository;
using GameWWTBM.Service;

namespace GameWWTBM.Controllers
{
    public class QuestionsController : Controller
    {
        private  ApplicationDbcontext _context;
        private readonly IQuestionsService _questinService;

        public static int points;
        public static int quantity;
        public static string Rights;
        public static int Fifty = 1;
         public static List<int> ides = new List<int>();

        public static List<Questions> questions = new List<Questions>();
        public QuestionsController(ApplicationDbcontext context, IQuestionsService questions)
        {
            _questinService = questions;
            _context = context;
        }

        public ActionResult Index()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? n)
        {
            if (n == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                quantity = Convert.ToInt32(n);
                List<Questions> first = _questinService.AllQuestions().ToList();
                //сделать массив из first по id
                foreach (var i in first)
                {
                    ides.Add(i.Id);
                }
                //перемешать id
                Random rand = new Random();
                for (int i = ides.Count - 1; i >= 1; i--)
                {
                    int j = rand.Next(i + 1);
                    int tmp = ides[j];
                    ides[j] = ides[i];
                    ides[i] = tmp;
                }

                //создать лист с найденными Questions по id
                List<Questions> questions = new List<Questions>();
                foreach (var i in ides)
                {
                    if (questions.Count < n)
                    {
                        questions.Add(first.Where(x => x.Id == i).FirstOrDefault());
                    }
                }
                return RedirectToAction("AllQuestions");

            }
        }

        public ActionResult AllQuestions()
        {
            List<Questions> questions = new List<Questions>();
            foreach(var i in ides)
            {
                if(questions.Count < quantity)
                {
                    questions.Add(_context.Questions.Find(i));

                }
            }
            if (Rights == null)
            {
                return View(questions);

            }
            else
            { 
                string[] items = Rights.Split(' ');
                List<int> list = new List<int>();
                foreach(var i in items)
                {
                    if(i != "")
                    {
                        list.Add(Convert.ToInt32(i));
                    }
                }
                    for (int i = 0; i< list.Count; i++)
                    {
                        questions.Remove(_context.Questions.Find(list[i]));

                    }
                    if (questions.Count == 0)
                    {
                        return RedirectToAction("Win");

                    }
                return View(questions);

            }
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
        public ActionResult Details(int? State, int? id, string e)
        {
            if (State == 2)
            {               
                return RedirectToAction("Correct", new { id = id });
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
        public ActionResult NOFif(int? State, int? id, string e)
        {
            if (State == 2)
            {
                return RedirectToAction("Correct", new { id = id });
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
        public ActionResult Win()
        {
            points = 0;
            return View();
        }
        public ActionResult Correct(int? id)
        {
            points = points + (1000000/quantity);
            ViewBag.points = points;
            Rights = Rights + " " + id.ToString();
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
        public ActionResult Fifti(int? State, int? id, string e)
        {
            if (State == 2)
            {
                return RedirectToAction("Correct", new { id = id });
            }
            else if (State == 1)
            {
                return RedirectToAction("Lose");
            }
            else return RedirectToAction("Index");

        }

    }
}
