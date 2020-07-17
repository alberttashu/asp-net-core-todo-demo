using System;

namespace Todo.Api.Model
{
    public class Todo : Entity
    {
        protected Todo()
        {
            
        }


        public Todo(string summary, string description, Interval interval)
        {
            Created = DateTime.Now;
            Summary = summary;
            Description = description;
            Interval = interval;
            IsDone = false;
        }

        public string Summary { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public Interval Interval { get; set; }
    }
}
