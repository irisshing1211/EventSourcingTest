﻿namespace EventSourcing1.Events
{
    public class NameChangeEvent : Event
    {
        public Person Target;
        public string Old, New;

        public NameChangeEvent(Person p, string old, string newVal)
        {
            Target = p;
            Old = old;
            New = newVal;
        }

        public override string ToString()
        {
            return $"Name changed from {Old} to {New}";
        }
    }
}