using System;
using Engine.Commands;
using Rules;

namespace Engine
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Board board = null;
            var entry = Console.ReadLine();

            if (entry == null) return;
            while (entry != "END")
            {
                var r = new Response(entry);
                r.SendToHandler(ref board);
                entry = Console.ReadLine();
            }
        }
    }
}