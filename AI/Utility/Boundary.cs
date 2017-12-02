namespace AI
{
	public class Boundary
	{
		#region Properties

		public int XMin { get; set; }

		public int XMax { get; set; }

		public int YMin { get; set; }

		public int YMax { get; set; }

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

		private void SetBoundary(int xMin, int xMax, int yMin, int yMax)
		{
			SetXBoundary(xMin, xMax);
			SetYBoundary(yMin, yMax);
		}

		private void SetXBoundary(int xMin, int xMax)
		{
			XMin = xMin;
			XMax = xMax;
		}

		private void SetYBoundary(int yMin, int yMax)
		{
			YMin = yMin;
			YMax = yMax;
		}
	}
}
