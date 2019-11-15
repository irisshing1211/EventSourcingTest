using EventSourcing1.Command;
using EventSourcing1.Events;
using EventSourcing1.Queries;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing1
{
    public partial class BaseContext //: DbContext
    {
        // public DbSet<Person> Persons { get; set; }
        /*public DbSet<LogHistory> LogHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=localhost;Initial Catalog=ESTesting;Integrated Security=True;");*/

        private EventBroker broker;

        public BaseContext(EventBroker b)
        {
            broker = b;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnCommands(object sender, Commands command)
        {
            if (command is AddPersonCommand addPerson)
            {
                broker.AllEvents.Add(new AddPersonEvent(addPerson.Target));
            }
        }

        private void BrokerOnQueries(object sender, Query query)
        {
        }
    }
}