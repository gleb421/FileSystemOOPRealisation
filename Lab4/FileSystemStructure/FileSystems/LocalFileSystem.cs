using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private LocalFileSystemState _localFileSystemState;

    public LocalFileSystem()
    {
        _localFileSystemState = LocalFileSystemState.Disconnected;
    }

    public FileSystemResultTypes Connect()
    {
        if (_localFileSystemState == LocalFileSystemState.Connected)
        {
            return new FileSystemResultTypes.InvalidState();
        }

        _localFileSystemState = LocalFileSystemState.Connected;
        return new FileSystemResultTypes.Success();
    }

    public FileSystemResultTypes Disconnect()
    {
        if (_localFileSystemState == LocalFileSystemState.Disconnected)
        {
            return new FileSystemResultTypes.InvalidState();
        }

        _localFileSystemState = LocalFileSystemState.Disconnected;
        return new FileSystemResultTypes.Success();
    }
}