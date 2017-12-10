namespace Rules
{
    /// <summary>
    /// Tuple implementation
    /// </summary>
    /// <typeparam name="T">Class one</typeparam>
    /// <typeparam name="TU">Class two</typeparam>
    public class Pair<T, TU> {
        public Pair() {
        }

        public Pair(T first, TU second) {
            First = first;
            Second = second;
        }

        public T First { get; set; }
        public TU Second { get; set; }
    };
}