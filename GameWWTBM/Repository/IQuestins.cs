using GameWWTBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Repository
{
    public interface IQuestins
    {
        IEnumerable<Questions> AllQuestions { get; }
        Questions GetBook(int id);
        void Create(Questions item);
        void Update(Questions item);
        void Delete(int id);
        void Save();
    }
}
