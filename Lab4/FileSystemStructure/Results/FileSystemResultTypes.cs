namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;

public abstract record FileSystemResultTypes
{
    private FileSystemResultTypes() { }

    public sealed record Success() : FileSystemResultTypes;

    public sealed record InvalidState : FileSystemResultTypes;
}