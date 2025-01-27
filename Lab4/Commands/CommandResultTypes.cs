namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract record CommandResultTypes
{
    private CommandResultTypes() { }

    public sealed record Success : CommandResultTypes;

    public sealed record WrongPath : CommandResultTypes;

    public sealed record NoThisModel : CommandResultTypes;

    public sealed record FileSystemError : CommandResultTypes;
}