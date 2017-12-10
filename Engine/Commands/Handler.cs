using System;
using AI;
using Rules;

namespace Engine.Commands
{
    public static class Handler
    {
        private static readonly MiniMax Ai = new MiniMax();
        
        public static void Start(ref Board board, int nb)
        {
            if (nb > 0 && nb < short.MaxValue)
                board = new Board(nb, nb);
            Console.WriteLine("OK");
        }

        public static void Turn(ref Board board, params string[] args)
        {
            var splitted = args[0].Split(',');
            board.Play(short.Parse(splitted[0]), short.Parse(splitted[1]), State.Ennemy);
            var shot = Ai.Run(ref board.Cell, false);
            board.Play(shot.X, shot.Y, State.Me);
            Console.WriteLine("{0},{1}", shot.X, shot.Y);
        }

        public static void Begin(ref Board board)
        {
            var shot = Ai.Run(ref board.Cell, true);
            board.Play(shot.X, shot.Y, State.Me);
            Console.WriteLine("{0},{1}", shot.X, shot.Y);
        }

        public static void Board(ref Board board)
        {
            var entry = Console.ReadLine();

            while (entry != "DONE")
            {
                if (entry == null) continue;
                var l = entry.Split(',');
                board.Play(short.Parse(l[0]), short.Parse(l[1]), (State) short.Parse(l[2]));
                entry = Console.ReadLine();
            }
        }

        public static void End()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Environment.Exit(0);
        }


        public static void About()
        {
            Console.WriteLine("name=\"Tinderflow\", version=\"1.0\", author=\"Antoine MOREL & Julien HOUZET\", country=\"FRA\"");
        }

        public static void Rectstart(ref Board board, short x, short y)
        {
            if (x > 0 && x < short.MaxValue && y > 0 && y < short.MaxValue)
                board = new Board(x, y);
            Console.WriteLine("OK");
        }

        public static void Takeback(ref Board board, short x, short y)
        {
            if (board.LastShot.First != x || board.LastShot.Second != y) return;
            board.Cell[y, x].State = State.Free;
            Console.WriteLine("OK");
        }

        public static void Restart(ref Board board)
        {
            board.BoardInitializing();
            Console.WriteLine("OK");
        }
    }
}