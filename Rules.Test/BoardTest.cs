using System.Diagnostics;
using Xunit;

namespace Rules.Test
{
    public class BoardTest
    {
        [Fact]
        public void Play_Out_Of_Board()
        {
            var board = new Board(15, 15);
            Assert.False(board.CanPlay(100, 1400));
        }

        [Fact]
        public void Creation_Inferior_To_100_ms()
        {
            var watch = Stopwatch.StartNew();
            var board = new Board(19, 19);
            Assert.True(watch.ElapsedMilliseconds < 100);
        }

        [Fact]
        public void Play_In_Board()
        {
            var board = new Board(19, 19);
            Assert.True(board.CanPlay(3, 5));
        }
    }
}