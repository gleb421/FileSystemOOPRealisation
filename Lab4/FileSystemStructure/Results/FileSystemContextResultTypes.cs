namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;

public abstract record FileSystemContextResultTypes
{
    private FileSystemContextResultTypes() { }

    public sealed record Success : FileSystemContextResultTypes;

    public sealed record InvalidMove : FileSystemContextResultTypes;

    public sealed record WrongPath : FileSystemContextResultTypes;
}