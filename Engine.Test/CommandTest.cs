using Engine.Commands;
using Xunit;

namespace Engine.Test
{
    public class CommandTest
    {
        [Fact]
        public void Send_command()
        {
            var cmd = new Command(CommandType.MESSAGE);
            Assert.Equal("MESSAGE This is a test", cmd.GetMessage("This is a test"));
        }

        [Fact]
        public void Parse_command()
        {
            var cmd = new Response("MESSAGE salut");
            Assert.Equal(cmd.GetCommandType().ToString(), "MESSAGE");
            Assert.Equal("salut", cmd.Args[0]);
        }
    }
}