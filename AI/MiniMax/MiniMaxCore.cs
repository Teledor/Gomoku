using AI.Interfaces;
using Rules;

namespace AI
{
    public partial class MiniMax : IAi
    {
		#region ScoreAndPosition

		protected class ScoreAndPosition
		{
			public Vector2 Position;
			public int Score;

			public ScoreAndPosition()
			{
				Position = Vector2.Zero;
				Score = 0;
			}
		}

		#endregion /* !ScoreAndPosition */

		/// <summary>
		/// Returns the best position to play based on the 2 opponents.
		/// </summary>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <returns>best position to play</returns>
		private static Vector2 GetBestPosition(ref Cell[,] board, ref Boundary actionBoundary)
		{
			var bestBlack = new ScoreAndPosition();
			var bestWhite = new ScoreAndPosition();
			var currentBlack = new ScoreAndPosition();
			var currentWhite = new ScoreAndPosition();

			for (var row = actionBoundary.YMin; row < actionBoundary.YMax; row++)
			{
				for (var column = actionBoundary.XMin; column < actionBoundary.XMax; column++)
				{
					if (board[row, column].State != State.Free) continue;
					currentBlack.Position.SetVector2(column, row);
					currentWhite.Position.SetVector2(column, row);
					GetBestScoreAndPositionFromState(ref currentBlack, ref board, ref actionBoundary, State.Me);
					GetBestScoreAndPositionFromState(ref currentWhite, ref board, ref actionBoundary, State.Ennemy);
					if (bestBlack.Score < currentBlack.Score)
					{
						bestBlack.Position.SetVector2(column, row);
						bestBlack.Score = currentBlack.Score;
					}
					if (bestWhite.Score >= currentWhite.Score) continue;
					bestWhite.Position.SetVector2(column, row);
					bestWhite.Score = currentWhite.Score;
				}
			}
			return ((bestBlack.Score > bestWhite.Score ? bestBlack.Position : bestWhite.Position));
		}

		/// <summary>
		/// Affects the score of the current position based on state.
		/// </summary>
		/// <param name="scoreAndPosition"></param>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <param name="state"></param>
		protected static void GetBestScoreAndPositionFromState(ref ScoreAndPosition scoreAndPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			int score;
			int tmpScore;

			// Vertical
			score = GetVerticalScore(ref scoreAndPosition.Position, ref board, ref actionBoundary, state);

			// Horizontal
			tmpScore = GetHorizontalScore(ref scoreAndPosition.Position, ref board, ref actionBoundary, state);
			score = (tmpScore > score ? tmpScore : score);

			// Top-left to bottom-right
			tmpScore = GetTopLeftToRightBottomScore(ref scoreAndPosition.Position, ref board, ref actionBoundary, state);
			score = (tmpScore > score ? tmpScore : score);

			// Top-right to bottom-left
			tmpScore = GetTopRightToLeftBottomScore(ref scoreAndPosition.Position, ref board, ref actionBoundary, state);
			score = (tmpScore > score ? tmpScore : score);

			scoreAndPosition.Score = score;
		}

		/// <summary>
		/// Returns the score of the current position
		/// based on the vertical axis.
		/// </summary>
		/// <param name="currentPosition"></param>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		private static int GetVerticalScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			var consecutive = 0;

			for (var row = currentPosition.Y - 1; row >= actionBoundary.YMin && board[row, currentPosition.X].State == state; row--)
				consecutive++;
			for (var row = currentPosition.Y + 1; row < actionBoundary.YMax && board[row, currentPosition.X].State == state; row++)
				consecutive++;
			return (GetScoreFromConsecutive(consecutive));
		}

		/// <summary>
		/// Returns the score of the current position
		/// based on the horizontal axis.
		/// </summary>
		/// <param name="currentPosition"></param>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		private static int GetHorizontalScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			var consecutive = 0;

			for (var column = currentPosition.X - 1; column >= actionBoundary.XMin
				&& board[currentPosition.Y, column].State == state; column--)
				consecutive++;
			for (var column = currentPosition.X + 1; column < actionBoundary.XMax
				&& board[currentPosition.Y, column].State == state; column++)
				consecutive++;
			return (GetScoreFromConsecutive(consecutive));
		}

		/// <summary>
		/// Returns the score of the current position
		/// based on the Top-left to bottom-right axis.
		/// </summary>
		/// <param name="currentPosition"></param>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		private static int GetTopLeftToRightBottomScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			var consecutive = 0;

			var column = currentPosition.X;
			var row = currentPosition.Y;
			while (column >= actionBoundary.XMin && row >= actionBoundary.YMin && board[row, column].State == state)
			{
				consecutive++;
				column--;
				row--;
			}
			column = currentPosition.X;
			row = currentPosition.Y;
			while (column < actionBoundary.XMax && row < actionBoundary.YMax && board[row, column].State == state)
			{
				consecutive--;
				column++;
				row++;
			}
			return (GetScoreFromConsecutive(consecutive));
		}

		/// <summary>
		/// Returns the score of the current position
		/// based on the Top-right to bottom-left axis.
		/// </summary>
		/// <param name="currentPosition"></param>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		private static int GetTopRightToLeftBottomScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			var consecutive = 0;

			var column = currentPosition.X;
			var row = currentPosition.Y;
			while (column < actionBoundary.XMax && row >= actionBoundary.YMin && board[row, column].State == state)
			{
				consecutive++;
				column++;
				row--;
			}
			column = currentPosition.X;
			row = currentPosition.Y;
			while (column >= actionBoundary.XMin && row < actionBoundary.YMax && board[row, column].State == state)
			{
				consecutive--;
				column--;
				row++;
			}
			return (GetScoreFromConsecutive(consecutive));
		}

		/// <summary>
		/// Returns the score based on the number of consecutive.
		/// </summary>
		/// <param name="consecutive"></param>
		/// <returns>score</returns>
		private static int GetScoreFromConsecutive(int consecutive)
		{
			return (consecutive * 1000 + 1);
		}

		/// <summary>
		/// Entry point of the IA.
		/// </summary>
		/// <param name="board"></param>
		/// <returns>Best position to play</returns>
		public Vector2 Run(ref Cell[,] board)
		{
			var actionBoundary = GetActionBoundary(ref board);

			// If first to play
			if (actionBoundary.XMin == int.MaxValue && actionBoundary.XMax == 0)
				return (new Vector2(board.GetLength(1) / 2, board.GetLength(0) / 2));

			return (GetBestPosition(ref board, ref actionBoundary));
		}
    }
}
