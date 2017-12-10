namespace Engine
{
    /// <summary>
    /// Enum for the command type
    /// We will use it for parsing and creating command
    /// </summary>
    public enum CommandType
    {
        START,
        TURN,
        BEGIN,
        BOARD,
        INFO,
        END,
        ABOUT,
        RECTSTART,
        RESTART,
        TAKEBACK,
        PLAY,
        UNKNOWN,
        ERROR,
        MESSAGE,
        DEBUG,
        SUGGEST
    }
}