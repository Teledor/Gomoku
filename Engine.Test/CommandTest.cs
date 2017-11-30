using Engine.Commands;
using Xunit;

namespace Engine.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Send_command()
        {
            var cmd = new Command(CommandType.MESSAGE);
            Assert.Equal("MESSAGE This is a test", cmd.GetMessage("This is a test"));
        }
    }
}