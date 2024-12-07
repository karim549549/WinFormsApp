using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DomainEntities
{
    public class Quiz
    {
        public int  Id { get; set; }
        public ICollection<Question> Questions {  get; set; } 
    }
}
