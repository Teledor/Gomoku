namespace Rules
{
    public class Board
    {
        private readonly int _x;
        private readonly int _y;

        public Cell[,] Cell;

        public Board(int x, int y)
        {
            _x = x;
            _y = y;
            Cell = new Cell[y, x];
            BoardInitializing();
        }

        public bool CanPlay(int x, int y)
        {
            return x <= _x && y <= _y && IsFree(x, y);
        }

        private void BoardInitializing()
        {
            for (var m = 0; m < _x ; m++)
            {
                for (var n = 0; n < _y ; n++)
                {
                    Cell[m, n] = new Cell(m, n);
                }
            }
        }
        
        private bool IsFree(int x, int y)
        {
            return Cell[y, x].State == State.Free;
        }

        public bool Play(int x, int y, State player)
        {
            return AddMoveToBoard(x, y, player);
        }

        private bool AddMoveToBoard(int x, int y, State player)
        {
            if (!CanPlay(x, y)) return false;
            Cell[y, x].State = player;
            return true;
        }

        public ref Cell GetLeftCell(int x, int y)
        {
            return ref Cell[x - 1, y];
        }

        public ref Cell GetRightCell(int x, int y)
        {
            return ref Cell[x + 1, y];
        }

        public ref Cell GetTopCell(int x, int y)
        {
            return ref Cell[x, y + 1];
        }

        public ref Cell GetBottomCell(int x, int y)
        {
            return ref Cell[x, y - 1];
        }

        public ref Cell GetCellAt(int x, int y)
        {
            return ref Cell[x, y];
        }
    }
}