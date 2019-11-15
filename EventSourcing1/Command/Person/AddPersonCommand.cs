namespace EventSourcing1.Command
{
    public class AddPersonCommand : PersonCommand
    {
        public AddPersonCommand(Person p): base(p)
        {
            
        }
    }
}