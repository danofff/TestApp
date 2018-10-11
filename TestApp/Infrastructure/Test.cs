using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Infrastructure
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestHeader { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public List<Question> Questions { get; set; }
    }
}