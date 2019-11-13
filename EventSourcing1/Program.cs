using System;

namespace EventSourcing1
{
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var p = new Person(eb);

            eb.Command(new ChangeAgeCommand(p, 1));
            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            int age;
            age = eb.Query<int>(new AgeQuery {Target = p});

            eb.UndoLast();
            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }
        }
    }
}