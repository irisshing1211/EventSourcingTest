namespace EventSourcing1.Command
{
    public class ChangeNameCommand : PersonCommand
    {
        public string Name;

        public ChangeNameCommand(Person p, string name) : base(p)
        {
            Name = name;
        }
    }
}