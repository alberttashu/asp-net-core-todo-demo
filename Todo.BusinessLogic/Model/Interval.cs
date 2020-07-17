namespace Todo.Api.Model
{
    public class Interval
    {
        protected Interval()
        {
            
        }

        public Interval(DayOfWeek dayOfWeek, int weeksBeforeNextScheduling)
        {
            DayOfWeek = dayOfWeek;
            WeeksBeforeNextScheduling = weeksBeforeNextScheduling;
        }

        public DayOfWeek DayOfWeek { get; set; }
        public int WeeksBeforeNextScheduling { get; set; }
    }
}