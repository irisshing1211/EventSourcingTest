namespace EventSourcing1.Command
{
    public class PersonCommand : Commands
    {
        public Person Target;

        public PersonCommand(Person p)
        {
            Target = p;
        }
    }
}