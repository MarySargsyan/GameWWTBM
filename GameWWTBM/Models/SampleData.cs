using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Models
{
    public static class SampleData
    {
        public static void Initialize(ApplicationDbcontext context)
        {
            if (!context.Questions.Any())
            {
                context.Questions.AddRange(
                    new Questions
                    {
                       Text = "Кто проживает на дне океана?"
                    },
                    new Questions
                    {
                       Text = "Так в старину называли сторожа городских ворот"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
