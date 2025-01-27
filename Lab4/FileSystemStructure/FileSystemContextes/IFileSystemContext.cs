using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

public interface IFileSystemContext
{
    public string CurrentPath { get; }

    public LocalFileSystem LocalFileSystem { get; }

    FileSystemContextResultTypes Connect(string path, string? mode);

    FileSystemContextResultTypes Disconnect();

    FileSystemContextResultTypes TreeGoTo(string path);

    FileSystemContextResultTypes TreeList(int depth, TreeOutputConfig config);

    FileSystemContextResultTypes ShowInConsole(string path);

    string ResolvePath(string relativeOrAbsolutePath);

    string ResolveNameCollision(string directory, string newName);
}