namespace Rules
{
    /// <summary>
    /// This class help us to manage the board
    /// </summary>
    public class Board
    {
        private readonly int _x;
        private readonly int _y;
        public Pair<short, short> LastShot = new Pair<short, short>();

        public Cell[,] Cell;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">The X axis size of the board</param>
        /// <param name="y">The Y axis size of the board</param>
        public Board(int x, int y)
        {
            _x = x;
            _y = y;
            Cell = new Cell[y, x];
            BoardInitializing();
        }

        /// <summary>
        /// This function help us to know if a player can play on these coords
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns>A boolean if you can play or not</returns>
        public bool CanPlay(int x, int y)
        {
            return x <= _x && y <= _y && IsFree(x, y);
        }

        /// <summary>
        /// This function is initializing the board by fill it of empty Cells
        /// </summary>
        public void BoardInitializing()
        {
            for (var m = 0; m < _x ; m++)
            {
                for (var n = 0; n < _y ; n++)
                {
                    Cell[m, n] = new Cell();
                }
            }
        }
        
        /// <summary>
        /// This function tell us if a cell is taken by a player or not
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns>Boolean if the cell is taken or not</returns>
        private bool IsFree(int x, int y)
        {
            return Cell[y, x].State == State.Free;
        }

        /// <summary>
        /// This is our entry point for playing
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <param name="player">The player</param>
        public void Play(int x, int y, State player)
        {
            AddMoveToBoard(x, y, player);
        }

        /// <summary>
        /// This function add a turn on the board and record the last move
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <param name="player">The player we want to give the cell</param>
        private void AddMoveToBoard(int x, int y, State player)
        {
            LastShot.First = (short) x;
            LastShot.Second = (short)y;
            if (!CanPlay(x, y)) return;
            Cell[y, x].State = player;
        }
    }
}