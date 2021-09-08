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
        public QuestionsRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public void Create(Questions item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Questions GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questions> AllQuestions => _context.Questions;


        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Questions item)
        {
            throw new NotImplementedException();
        }
    }

}
