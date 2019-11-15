namespace EventSourcing1.Command
{
    public class ChangeAgeCommand : PersonCommand
    {
        public int Age;

        public ChangeAgeCommand(Person t, int age):base(t)
        {
            Age = age;
        }
    }
}