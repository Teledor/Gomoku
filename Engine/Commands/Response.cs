using System;
using System.Linq;

namespace Engine.Commands
{
    public class Response
    {
        private CommandType _type;
        private string[] Args { get; set; }

        public Response(string type, params string[] args)
        {
            Enum.TryParse(type, out _type);
        }

        public Response()
        {
            
        }

        public bool Builder(string cmd)
        {
            var final = cmd.Split(' ');
            Args = final.Where((src, idx) => idx != 0).ToArray();
            return Enum.TryParse(final[0], out _type);
        }
    }
}