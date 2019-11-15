namespace EventSourcing1.Command
{
    public class ChangePhoneCommand : PersonCommand
    {
        public string Value;

        public ChangePhoneCommand(Person p, string value) : base(p)
        {
            Value = value;
        }
    }
}