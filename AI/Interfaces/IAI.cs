using Rules;

namespace AI.Interfaces
{
    internal interface IAi
    {
		Vector2 Run(ref Cell[,] board);
    }
}
