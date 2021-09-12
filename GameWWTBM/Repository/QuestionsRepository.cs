using GameWWTBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Repository
{
    public class QuestionsRepository : IQuestins
    {
        private ApplicationDbcontext _context;

        public QuestionsRepository( ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
        }
        public IEnumerable<Questions> AllQuestions() {
            using(_context)
            {
                var questions = _context.Questions.ToList();
                return questions;
            }
        }

    }

}
