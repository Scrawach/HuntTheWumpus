namespace HuntTheWumpus.Core.Commands.Abstract;

public struct CommandStatus
{
    public bool IsSuccess { get; private init; }
    public bool IsFailure { get; private init; }
    
    public static CommandStatus Success() =>
        new()
        {
            IsSuccess = true
        };

    public static CommandStatus Failure() =>
        new()
        {
            IsFailure = true
        };

    public static CommandStatus Unknown() =>
        new();
}