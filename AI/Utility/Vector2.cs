namespace AI
{
    public class Vector2
    {
	    #region Properties

		public int X { get; set; }

	    public int Y { get; set; }

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
		public static Vector2 Zero => (new Vector2(0, 0));

	    public void SetVector2(int x, int y)
		{
			X = x;
			Y = y;
		}
    }
}
