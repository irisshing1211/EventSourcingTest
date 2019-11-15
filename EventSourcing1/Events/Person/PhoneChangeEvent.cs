namespace EventSourcing1.Events
{
    public class PhoneChangeEvent : PersonEvent
    {
        public string Old, New;

        public PhoneChangeEvent(Person p, string old, string newVal)
        {
            Target = p;
            Old = old;
            New = newVal;
        }

        public override string ToString()
        {
            return $"Phone changed from {Old} to {New}";
        }
    }
}