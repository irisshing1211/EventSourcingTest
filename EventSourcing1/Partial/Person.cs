using EventSourcing1.Command;
using EventSourcing1.Events;
using EventSourcing1.Queries;

namespace EventSourcing1
{
    public partial class Person
    {
        private EventBroker broker;
        public Person(EventBroker b)
        {
            broker = b;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnCommands(object sender, Commands command)
        {
            if (command is ChangeAgeCommand cac && cac.Target == this)
            {
                if (cac.Reg) broker.AllEvents.Add(new AgeChangeEvent(this, Age, cac.Age));
                Age = cac.Age;
            }
            else if (command is ChangeNameCommand changeName && changeName.Target == this)
            {
                if (changeName.Reg) broker.AllEvents.Add(new NameChangeEvent(this, Name, changeName.Name));
                Name = changeName.Name;
            }
            else if (command is ChangePhoneCommand changePhone && changePhone.Target == this)
            {
                if (changePhone.Reg) broker.AllEvents.Add(new PhoneChangeEvent(this, Phone, changePhone.Value));
                Phone = changePhone.Value;
            }
            else if (command is ModPersonCommand modPerson && modPerson.Target == this)
            {
                broker.AllEvents.Add(new ModPersonEvent(this, modPerson.Updated));
                var upd = modPerson.Updated;
                Age = upd.Age;
                Name = upd.Name;
                Phone = upd.Phone;
            }
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            if (query is AgeQuery ac && ac.Target == this)
            {
                ac.Result = Age;
            }
            else if (query is NameQuery nq && nq.Target == this)
            {
                nq.Result = Name;
            }
            else if (query is PhoneQuery pq && pq.Target == this)
            {
                pq.Result = Phone;
            }
        }
    }
}