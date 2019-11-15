using Newtonsoft.Json;

namespace EventSourcing1.Events
{
    public class ModPersonEvent : PersonEvent
    {
        public Person Updated;

        public ModPersonEvent(Person p, Person update)
        {
            Target = p;
            Updated = update;
        }

        public override string ToString()
        {
            return
                $"Person ({Target.Name}) updated from {JsonConvert.SerializeObject(Target)} to {JsonConvert.SerializeObject(Updated)}";
        }
    }
}