namespace EventSourcing1.Events
{
    public class AgeChangeEvent : PersonEvent
    {
        public Person Target;
        public int Old, New;

        public AgeChangeEvent(Person p, int old, int newVal)
        {
            Target = p;
            Old = old;
            New = newVal;
        }

        public override string ToString()
        {
            return $"Age changed from {Old} to {New}";
        }
    }
}