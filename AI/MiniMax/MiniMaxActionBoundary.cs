using Rules;

namespace AI
{
    public partial class MiniMax
    {
		/// <summary>
		/// Adds margin on the edges.
		/// </summary>
		/// <param name="actionBoudary"></param>
		/// <param name="board"></param>
		private static void AddMargin(ref Boundary actionBoudary, ref Cell[,] board)
		{
			actionBoudary.XMin = (actionBoudary.XMin > 0 ? actionBoudary.XMin - 1 : actionBoudary.XMin);
			actionBoudary.YMin = (actionBoudary.YMin > 0 ? actionBoudary.YMin - 1 : actionBoudary.YMin);
			actionBoudary.XMax = (actionBoudary.XMax < board.GetLength(1) - 1 ? actionBoudary.XMax + 1 : actionBoudary.XMax);
			actionBoudary.YMax = (actionBoudary.YMax < board.GetLength(0) - 1 ? actionBoudary.YMax + 1 : actionBoudary.YMax);
		}

		/// <summary>
		/// Returns the boundaries of the board
		/// where actions take places.
		/// </summary>
		/// <param name="board"></param>
		/// <returns></returns>
		private static Boundary GetActionBoundary(ref Cell[,] board)
		{
			var actionBoudary = new Boundary(int.MaxValue, 0, int.MaxValue, 0);

			for (var row = 0; row < board.GetLength(0); row++)
			{
				for (var column = 0; column < board.GetLength(1); column++)
				{
					if (board[row, column].State == State.Free) continue;
					actionBoudary.XMin = (column < actionBoudary.XMin ? column : actionBoudary.XMin);
					actionBoudary.XMax = (column > actionBoudary.XMax ? column : actionBoudary.XMax);
					actionBoudary.YMin = (row < actionBoudary.YMin ? row : actionBoudary.YMin);
					actionBoudary.YMax = (row > actionBoudary.YMax ? row : actionBoudary.YMax);
				}
			}
			AddMargin(ref actionBoudary, ref board);
			return (actionBoudary);
		}
	}
}
