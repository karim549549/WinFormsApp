﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DomainEntities
{
    public class Question
    {
        public  int  Id { get; set; }
        public string Text  { get; set; }
        public List<string> Options { get; set; }
        public int   AnswerIndex { get; set; }
    }
}
