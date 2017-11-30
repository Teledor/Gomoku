namespace AI
{
    class Vector2
    {
		private int _x;
		private int _y;

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

		#region Constructors

		public Vector2()
		{
			SetVector2(0, 0);
		}

		public Vector2(int x, int y)
		{
			SetVector2(x, y);
		}

		#endregion /* !Constructors */

		/// <summary>
		/// Returns a Vector2 with 0 in X and Y.
		/// </summary>
		public static Vector2 zero
		{
			get { return (new Vector2(0, 0)); }
		}

		public void SetVector2(int x, int y)
		{
			X = x;
			Y = y;
		}
    }
}
