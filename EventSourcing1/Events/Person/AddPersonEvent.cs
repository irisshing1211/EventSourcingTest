namespace EventSourcing1.Events
{
    public class AddPersonEvent: PersonEvent
    {
        public AddPersonEvent(Person p)
        {
            Target = p;
        }

        public override string ToString()
        {
            return $"Person ({Target.Name}) added.";
        }
    }
}