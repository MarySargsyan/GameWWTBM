using GameWWTBM.Models;
using GameWWTBM.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Controllers
{
    public class HomeController : Controller
    {
        private IQuestins _questins;
        public HomeController(IQuestins questins)
        {
            _questins = questins;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
