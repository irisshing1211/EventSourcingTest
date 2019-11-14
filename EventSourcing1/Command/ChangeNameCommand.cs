namespace EventSourcing1
{
    public class ChangeNameCommand : Command
    {
        public Person Target;
        public string Name;

        public ChangeNameCommand(Person p, string name)
        {
            Target = p;
            Name = name;
        }
    }
}