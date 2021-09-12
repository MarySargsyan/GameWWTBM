using GameWWTBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Service
{
    public interface IQuestionsService
    {
        IEnumerable<Questions> AllQuestions();

    }
}
