namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}