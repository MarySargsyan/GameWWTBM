using GameWWTBM.Models;
using GameWWTBM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Service
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestins _questins;
        public QuestionsService(IQuestins questins)
        {
            _questins = questins;
        }

        public IEnumerable<Questions> AllQuestions() => _questins.AllQuestions();
    }
}
