using System;
using System.Linq;
using EventSourcing1.Command;
using EventSourcing1.Queries;
using Newtonsoft.Json;

namespace EventSourcing1
{
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var db = new BaseContext(eb);
            var p = new Person(eb)
                {Id = Guid.NewGuid(), Age = 18, Name = "Person 1", CreatedAt = DateTime.Now, Phone = "12345678"};
            eb.Command(new AddPersonCommand(p));
         //   Console.WriteLine(JsonConvert.SerializeObject(p));
            Console.WriteLine(eb.AllEvents.LastOrDefault());
            eb.Command(new ModPersonCommand(p, new Person() {Age = 30, Name = "Person update", Phone = "98765432"}));
           // Console.WriteLine(JsonConvert.SerializeObject(p));
            Console.WriteLine(eb.AllEvents.LastOrDefault());
            eb.Command(new ModPersonCommand(p, new Person() {Age = 30, Name = "Person update 2", Phone = "98765432"}));
          //  Console.WriteLine(JsonConvert.SerializeObject(p));
            Console.WriteLine(eb.AllEvents.LastOrDefault());
            /*var p = new Person(eb);

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
            }*/
        }
    }
}