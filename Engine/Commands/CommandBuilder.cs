using System;

namespace Engine.Commands
{
    public class Command
    {
        private readonly CommandType _type;

        public Command(CommandType type)
        {
            _type = type;
        }

        public void Send(params string[] args)
        {
            Console.WriteLine(@"{0} {1}", _type, string.Join(' ', args));
        }

        public void Send(params int[] args)
        {
            Console.WriteLine(@"{0} {1}", _type, string.Join(' ', args));
        }

        public string GetMessage(params int[] args)
        {
            return string.Format(@"{0} {1}", _type, string.Join(' ', args));
        }
        
        public string GetMessage(params string[] args)
        {
            return string.Format(@"{0} {1}", _type, string.Join(' ', args));
        }
    }
}