using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Infrastructure
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }
}