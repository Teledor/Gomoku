using Rules;

namespace AI
{
    public partial class MiniMax : IAI
    {
		#region ScoreAndPosition

		protected class ScoreAndPosition
		{
			public Vector2 position;
			public int score;

			public ScoreAndPosition()
			{
				position = Vector2.zero;
				score = 0;
			}
		}

		#endregion /* !ScoreAndPosition */

		/// <summary>
		/// Returns the best position to play based on the 2 opponents.
		/// </summary>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <returns>best position to play</returns>
		protected Vector2 GetBestPosition(ref Cell[,] board, ref Boundary actionBoundary)
		{
			ScoreAndPosition bestBlack = new ScoreAndPosition();
			ScoreAndPosition bestWhite = new ScoreAndPosition();
			ScoreAndPosition currentBlack = new ScoreAndPosition();
			ScoreAndPosition currentWhite = new ScoreAndPosition();

			for (int row = actionBoundary.YMin; row < actionBoundary.YMax; row++)
			{
				for (int column = actionBoundary.XMin; column < actionBoundary.XMax; column++)
				{
					if (board[row, column].State == State.Free)
					{
						currentBlack.position.SetVector2(column, row);
						currentWhite.position.SetVector2(column, row);
						GetBestScoreAndPositionFromState(ref currentBlack, ref board, ref actionBoundary, State.Black);
						GetBestScoreAndPositionFromState(ref currentWhite, ref board, ref actionBoundary, State.White);
						if (bestBlack.score < currentBlack.score)
						{
							bestBlack.position.SetVector2(column, row);
							bestBlack.score = currentBlack.score;
						}
						if (bestWhite.score < currentWhite.score)
						{
							bestWhite.position.SetVector2(column, row);
							bestWhite.score = currentWhite.score;
						}
					}
				}
			}
			return ((bestBlack.score > bestWhite.score ? bestBlack.position : bestWhite.position));
		}

		/// <summary>
		/// Affects the score of the current position based on state.
		/// </summary>
		/// <param name="scoreAndPosition"></param>
		/// <param name="board"></param>
		/// <param name="actionBoundary"></param>
		/// <param name="state"></param>
		protected void GetBestScoreAndPositionFromState(ref ScoreAndPosition scoreAndPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			int score;
			int tmpScore;

			// Vertical
			score = GetVerticalScore(ref scoreAndPosition.position, ref board, ref actionBoundary, state);

			// Horizontal
			tmpScore = GetHorizontalScore(ref scoreAndPosition.position, ref board, ref actionBoundary, state);
			score = (tmpScore > score ? tmpScore : score);

			// Top-left to bottom-right
			tmpScore = GetTopLeftToRightBottomScore(ref scoreAndPosition.position, ref board, ref actionBoundary, state);
			score = (tmpScore > score ? tmpScore : score);

			// Top-right to bottom-left
			tmpScore = GetTopRightToLeftBottomScore(ref scoreAndPosition.position, ref board, ref actionBoundary, state);
			score = (tmpScore > score ? tmpScore : score);

			scoreAndPosition.score = score;
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
		protected int GetVerticalScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			int consecutive = 0;

			for (int row = currentPosition.Y - 1; row >= actionBoundary.YMin && board[row, currentPosition.X].State == state; row--)
				consecutive++;
			for (int row = currentPosition.Y + 1; row < actionBoundary.YMax && board[row, currentPosition.X].State == state; row++)
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
		protected int GetHorizontalScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			int consecutive = 0;

			for (int column = currentPosition.X - 1; column >= actionBoundary.XMin
				&& board[currentPosition.Y, column].State == state; column--)
				consecutive++;
			for (int column = currentPosition.X + 1; column < actionBoundary.XMax
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
		protected int GetTopLeftToRightBottomScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			int consecutive = 0;

			int column = currentPosition.X;
			int row = currentPosition.Y;
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
		protected int GetTopRightToLeftBottomScore(ref Vector2 currentPosition, ref Cell[,] board,
			ref Boundary actionBoundary, State state)
		{
			int consecutive = 0;

			int column = currentPosition.X;
			int row = currentPosition.Y;
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
		protected int GetScoreFromConsecutive(int consecutive)
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
			Boundary actionBoundary = GetActionBoundary(ref board);

			// If first to play
			if (actionBoundary.XMin == int.MaxValue && actionBoundary.XMax == 0)
				return (new Vector2(board.GetLength(1) / 2, board.GetLength(0) / 2));

			return (GetBestPosition(ref board, ref actionBoundary));
		}
    }
}
