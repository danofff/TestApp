using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp.Infrastructure;
using TestApp.Models;

namespace TestApp.Help
{
    public class ContextHandler
    {
        private ApplicationDbContext context;

        public ContextHandler()
        {
            context=new ApplicationDbContext();
        }

        public List<Subject> GetSubjects()
        {
            return context.Subjects.ToList();
        }

        public List<Test> GetTestsBySubjectId(int subId)
        {
            var tests = context.Tests.Select(s => s).Where(w => w.SubjectId == subId).ToList();
            return tests;
        }
        
        ~ContextHandler()
        {
            context.Dispose();
        }
    }
}