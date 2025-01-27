namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}