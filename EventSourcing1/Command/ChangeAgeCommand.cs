namespace EventSourcing1
{
    public class ChangeAgeCommand : Command
    {
        public Person Target;
        public int Age;

        public ChangeAgeCommand(Person t, int age)
        {
            Target = t;
            Age = age;
        }
    }
}