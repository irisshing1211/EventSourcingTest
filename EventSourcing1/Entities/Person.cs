using System.Collections;
using System.Diagnostics.Contracts;
using EventSourcing1.Events;
using EventSourcing1.Queries;

namespace EventSourcing1
{
    public class Person
    {
        private string name;
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
            if (command is ChangeAgeCommand cac && cac.Target == this)
            {
                if (cac.Reg) broker.AllEvents.Add(new AgeChangeEvent(this, age, cac.Age));
                age = cac.Age;
            }
            else if (command is ChangeNameCommand c && c.Target == this)
            {
                if(c.Reg)broker.AllEvents.Add(new NameChangeEvent(this, name, c.Name));
                name = c.Name;
            }
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            if (query is AgeQuery ac && ac.Target == this)
            {
                ac.Result = age;
            }
            else if (query is NameQuery q && q.Target == this)
            {
                q.Result = name;
            }
        }
    }
}