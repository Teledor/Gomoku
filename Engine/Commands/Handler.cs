using System;
using AI;
using Rules;

namespace Engine.Commands
{
    public static class Handler
    {
        private static readonly MiniMax _ai = new MiniMax();
        
        public static bool Start(ref Board board, int nb)
        {
            if (nb > 0 && nb < short.MaxValue)
                board = new Board(nb, nb);
            Console.WriteLine("OK");
            return true;
        }

        public static bool Turn(ref Board board, params string[] args)
        {
            var splitted = args[0].Split(',');
            board.Play(short.Parse(splitted[0]), short.Parse(splitted[1]), State.Ennemy);
            var shot = _ai.Run(ref board.Cell, false);
            board.Play(shot.X, shot.Y, State.Me);
            Console.WriteLine("{0},{1}", shot.X, shot.Y);
			return true;
        }

        public static bool Begin(ref Board board)
        {
            var shot = _ai.Run(ref board.Cell, true);
            board.Play(shot.X, shot.Y, State.Me);
            Console.WriteLine("{0},{1}", shot.X, shot.Y);
            return true;
        }

        public static bool Board(ref Board board, params string[] pars)
        {
            var entry = Console.ReadLine();

            while (entry != "DONE")
            {
                if (entry == null) continue;
                var l = entry.Split(',');
                Console.Write(l[0] + l[1] + l[2]);
                board.Play(short.Parse(l[0]), short.Parse(l[1]), (State) short.Parse(l[2]));
                Console.WriteLine(entry);
                entry = Console.ReadLine();
            }
            return true;
        }
    }
}