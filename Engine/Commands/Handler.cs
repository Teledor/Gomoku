using System;
using AI;
using Rules;

namespace Engine.Commands
{
    /// <summary>
    /// This class handle Responses from the Gomokup Manager
    /// </summary>
    public static class Handler
    {
        private static readonly MiniMax Ai = new MiniMax();
        
        
        /// <summary>
        /// Handling the start command where we have to awnser "OK" after initializing the board
        /// </summary>
        /// <param name="board">Reference to the board we want to initialize</param>
        /// <param name="nb">The size we want for the board</param>
        public static void Start(ref Board board, int nb)
        {
            if (nb > 0 && nb < short.MaxValue)
                board = new Board(nb, nb);
			else
				Environment.Exit(1);
			Console.WriteLine("OK");
        }

        /// <summary>
        /// Handling the opponent playing.
        /// Adding the shot to the turn and answer and send it.
        /// </summary>
        /// <param name="board">Reference to the board we want to act on</param>
        /// <param name="args">THe coord the opponent played</param>
        public static void Turn(ref Board board, params string[] args)
        {
            var splitted = args[0].Split(',');
            board.Play(short.Parse(splitted[0]), short.Parse(splitted[1]), State.Ennemy);
            var shot = Ai.Run(ref board.Cell, false);
            board.Play(shot.X, shot.Y, State.Me);
            Console.WriteLine("{0},{1}", shot.X, shot.Y);
        }

        /// <summary>
        /// Handling the case we are to first player to play.
        /// </summary>
        /// <param name="board">The board we want to play on</param>
        public static void Begin(ref Board board)
        {
            var shot = Ai.Run(ref board.Cell, true);
            board.Play(shot.X, shot.Y, State.Me);
            Console.WriteLine("{0},{1}", shot.X, shot.Y);
        }

        /// <summary>
        /// Handling game resuming
        /// We have to get the old turn and add them to the board
        /// </summary>
        /// <param name="board">The board we want to add on old shot</param>
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

        /// <summary>
        /// Game ending
        /// We have to clear everything
        /// </summary>
        public static void End()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Environment.Exit(0);
        }

        /// <summary>
        /// About command
        /// We have to the author information to the manager
        /// </summary>
        public static void About()
        {
            Console.WriteLine("name=\"Tinderflow\", version=\"1.0\", author=\"Antoine MOREL & Julien HOUZET\", country=\"FRA\"");
        }

        /// <summary>
        /// Creating a rectangle board
        /// Then everything goes like START
        /// </summary>
        /// <param name="board">The board we want to initialize</param>
        /// <param name="x">The size on the X axis</param>
        /// <param name="y">The size on the Y axis</param>
        public static void Rectstart(ref Board board, short x, short y)
        {
            if (x > 0 && x < short.MaxValue && y > 0 && y < short.MaxValue)
                board = new Board(x, y);
            Console.WriteLine("OK");
        }

        /// <summary>
        /// Action possible if a player want to cancel his turn
        /// </summary>
        /// <param name="board">The board we want to act on</param>
        /// <param name="x">The X coord of the turn</param>
        /// <param name="y">The Y coord of the turn</param>
        public static void Takeback(ref Board board, short x, short y)
        {
            if (board.LastShot.First != x || board.LastShot.Second != y) return;
            board.Cell[y, x].State = State.Free;
            Console.WriteLine("OK");
        }

        /// <summary>
        /// Handling a new game
        /// We have to clear the board to start a new game
        /// </summary>
        /// <param name="board">The board we want to clear</param>
        public static void Restart(ref Board board)
        {
            board.BoardInitializing();
            Console.WriteLine("OK");
        }

        /// <summary>
        /// Handling unrecognized commands
        /// </summary>
        public static void Unknown()
        {
            Console.WriteLine("UNKNOWN");
        }
    }
}