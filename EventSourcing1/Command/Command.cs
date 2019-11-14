using System;

namespace EventSourcing1
{
    public class Command : EventArgs
    {
        public bool Reg = true;
    }
}