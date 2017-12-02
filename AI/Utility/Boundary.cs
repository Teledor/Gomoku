namespace AI
{
	public class Boundary
	{
		protected int _xMin;
		protected int _xMax;
		protected int _yMin;
		protected int _yMax;

		#region Properties

		public int XMin
		{
			get { return _xMin; }
			set { _xMin = value; }
		}

		public int XMax
		{
			get { return _xMax; }
			set { _xMax = value; }
		}

		public int YMin
		{
			get { return _yMin; }
			set { _yMin = value; }
		}

		public int YMax
		{
			get { return _yMax; }
			set { _yMax = value; }
		}

		#endregion /* !Properties */

		#region Constructors

		public Boundary()
		{
			SetBoundary(0, 0, 0, 0);
		}

		public Boundary(int xMin, int xMax, int yMin, int yMax)
		{
			SetBoundary(xMin, xMax, yMin, yMax);
		}

		#endregion /* !Constructors */

		public void SetBoundary(int xMin, int xMax, int yMin, int yMax)
		{
			SetXBoundary(xMin, xMax);
			SetYBoundary(yMin, yMax);
		}

		public void SetXBoundary(int xMin, int xMax)
		{
			XMin = xMin;
			XMax = xMax;
		}

		public void SetYBoundary(int yMin, int yMax)
		{
			YMin = yMin;
			YMax = yMax;
		}
	}
}
