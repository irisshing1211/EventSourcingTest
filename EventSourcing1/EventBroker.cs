using System;
using System.Collections.Generic;
using System.Linq;
using EventSourcing1.Events;
using EventSourcing1.Queries;

namespace EventSourcing1
{
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
}