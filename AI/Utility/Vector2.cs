namespace AI
{
	public class Vector2
	{
		private int _x;
		private int _y;

		#region Constructors

		public Vector2()
		{
			_x = 0;
			_y = 0;
		}

		public Vector2(int x, int y)
		{
			_x = x;
			_y = y;
		}

		#endregion /* !Constructors */

		#region Properties

		public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}

		#endregion /* !Properties */
	}
}
