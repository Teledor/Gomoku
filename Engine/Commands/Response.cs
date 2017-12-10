using System;
using System.Linq;
using Rules;

namespace Engine.Commands
{
    public class Response
    {
        private readonly CommandType _type;
        public string[] Args { get; }

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

        public void SendToHandler(ref Board board)
        {
            switch (_type)
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
                    Handler.Board(ref board);
                    break;
                case CommandType.END:
                    Handler.End();
                    break;
                case CommandType.ABOUT:
                    Handler.About();
                    break;
                case CommandType.RECTSTART:
                    Handler.Rectstart(ref board, short.Parse(Args[0]), short.Parse(Args[1]));
                    break;
                case CommandType.RESTART:
                    break;
                case CommandType.TAKEBACK:
                    Handler.Takeback(ref board, short.Parse(Args[0]), short.Parse(Args[1]));
                    break;
            }
        }
    }
}