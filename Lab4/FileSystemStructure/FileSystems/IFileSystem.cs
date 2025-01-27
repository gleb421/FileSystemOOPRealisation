using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystems;

public interface IFileSystem
{
    FileSystemResultTypes Connect();

    FileSystemResultTypes Disconnect();
}