namespace EventSourcing1.Command
{
    public class ModPersonCommand : PersonCommand
    {
        public Person Updated;

        public ModPersonCommand(Person p, Person update) : base(p)
        {
            Updated = update;
        }
    }
}