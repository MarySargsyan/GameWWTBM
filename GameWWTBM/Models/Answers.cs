using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int State { get; set; }
        public int QuestionId { get; set; }
        public Questions Question { get; set; }

    }
}
