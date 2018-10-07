using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Infrastructure
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsRight { get; set; }
    }
}