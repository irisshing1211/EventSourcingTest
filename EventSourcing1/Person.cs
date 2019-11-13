using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace EventSourcing1
{
    public class Person
    {
        private int age;
        private EventBroker broker;

        public Person(EventBroker b)
        {
            broker = b;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if (cac != null && cac.Target == this)
            {
                if (cac.Reg) broker.AllEvents.Add(new AgeChangeEvent(this, age, cac.Age));
                age = cac.Age;
            }
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            var ac = query as AgeQuery;
            if (ac != null && ac.Target == this)
            {
                ac.Result = age;
            }
        }
    }

    public class EventBroker
    {
        // all event that happened
        public IList<Event> AllEvents = new List<Event>();

        // command, to do some action
        public event EventHandler<Command> Commands;

        // query
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T) q.Result;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangeEvent;
            if (ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.Old) {Reg = false});
                AllEvents.Remove(e);
            }
        }
    }

    public class Event
    {
        // backtrack
    }

    public class AgeChangeEvent : Event
    {
        public Person Target;
        public int Old, New;

        public AgeChangeEvent(Person p, int old, int newVal)
        {
            Target = p;
            Old = old;
            New = newVal;
        }

        public override string ToString()
        {
            return $"Age change from {Old} to {New}";
        }
    }

    public class Command : EventArgs
    {
        public bool Reg = true;
    }

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

    public class Query
    {
        public object Result;
    }

    public class AgeQuery : Query
    {
        public Person Target;
    }
}