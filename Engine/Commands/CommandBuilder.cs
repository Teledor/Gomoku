using System;

namespace Engine.Commands
{
    /// <summary>
    /// This class is for sending command to the Gomokup manager
    /// </summary>
    public class Command
    {
        private readonly CommandType _type;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">The type of the command you want to make</param>
        public Command(CommandType type)
        {
            _type = type;
        }

        /// <summary>
        /// Send command to the manager
        /// </summary>
        /// <param name="args">Arguments we want to send</param>
        public void Send(params string[] args)
        {
            Console.WriteLine(@"{0} {1}", _type, string.Join(",", args));
        }

        /// <summary>
        /// If case we want to send custom message to the client
        /// </summary>
        /// <param name="msg">Message we want to send</param>
        public void Send(string msg)
        {
            Console.WriteLine(@"{0} {1}", _type, msg);
        }
        
        /// <summary>
        /// Send command to the manager
        /// </summary>
        /// <param name="args">Arguments we want to send</param>
        public void Send(params int[] args)
        {
            Console.WriteLine(@"{0} {1}", _type, string.Join(",", args));
        }

        /// <summary>
        /// Get formated message
        /// </summary>
        /// <param name="args">Arguments we want to send</param>
        /// <returns></returns>
        public string GetMessage(params int[] args)
        {
            return $@"{_type} {string.Join(" ", args)}";
        }
        
        /// <summary>
        /// Get formated message
        /// </summary>
        /// <param name="args">Argumentes we want to send</param>
        /// <returns></returns>
        public string GetMessage(params string[] args)
        {
            return $@"{_type} {string.Join(" ", args)}";
        }
    }
}