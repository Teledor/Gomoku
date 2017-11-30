using Rules;

namespace AI
{
    class MiniMax
    {
		private Cell[,] _board;
		private Insulator _insulator;
		private State _playerState;

		#region Properties

		public void UpdateBoard(Cell[,] board)
		{
			_board = board;
		}

		#endregion /* !Properties */

		MiniMax(Cell[,] cell, State playerState)
		{
			_board = cell;
			_playerState = playerState;
		}

		public Vector2 GetBestPosition()
		{
			Vector2 bestPosition = Vector2.zero;

			return (bestPosition);
		}
    }
}
