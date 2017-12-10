using System;
using System.Linq;
using Rules;

namespace Engine.Commands
{
    public class Response
    {
        private readonly CommandType _type;
        public string[] Args { get; }

        public Response(string type, params string[] args)
        {
            Enum.TryParse(type, out _type);
        }

        public Response(string cmd)
        {
            var final = cmd.Split(' ');
            Args = final.Where((src, idx) => idx != 0).ToArray();
            if (!Enum.TryParse(final[0], out _type))
                _type = CommandType.UNKNOWN;
        }

        public CommandType GetCommandType()
        {
            return _type;
        }

        public bool SendToHandler(ref Board board)
        {
			Console.WriteLine($"MESSAGE {_type} arg: {Args[0]}");
            switch(_type)
            {
                case CommandType.START:
                    Handler.Start(ref board, short.Parse(Args[0]));
                    break;
                case CommandType.TURN:
                    Handler.Turn(ref board, Args);
                    break;
                case CommandType.BEGIN:
                    Handler.Begin(ref board);
                    break;
                case CommandType.BOARD:
                    Handler.Board(ref board, Args);
                    break;
                case CommandType.INFO:
                    break;
                case CommandType.END:
                    break;
                case CommandType.ABOUT:
                    break;
                case CommandType.RECTSTART:
                    break;
                case CommandType.RESTART:
                    break;
                case CommandType.TAKEBACK:
                    break;
                case CommandType.PLAY:
                    break;
                case CommandType.UNKNOWN:
                    break;
                case CommandType.ERROR:
                    break;
                case CommandType.MESSAGE:
                    break;
                case CommandType.DEBUG:
                    break;
                case CommandType.SUGGEST:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }
    }
}