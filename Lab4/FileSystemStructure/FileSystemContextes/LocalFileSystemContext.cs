using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

public class LocalFileSystemContext : IFileSystemContext
{
    public string CurrentPath { get; private set; }

    public string? Mode { get; private set; }

    public LocalFileSystem LocalFileSystem { get; private set; } = new LocalFileSystem();

    private readonly IOutputWriter _outputWriter;

    public LocalFileSystemContext(IOutputWriter outputWriter)
    {
        LocalFileSystem.Disconnect();
        CurrentPath = string.Empty;
        Mode = "local";
        _outputWriter = outputWriter;
    }

    public FileSystemContextResultTypes Connect(string path, string? mode)
    {
        if (!Directory.Exists(path))
        {
            return new FileSystemContextResultTypes.WrongPath();
        }

        if (LocalFileSystem.Connect() == new FileSystemResultTypes.InvalidState())
        {
            return new FileSystemContextResultTypes.InvalidMove();
        }

        CurrentPath = path;
        Mode = mode;
        return new FileSystemContextResultTypes.Success();
    }

    public FileSystemContextResultTypes Disconnect()
    {
        if (LocalFileSystem.Disconnect() == new FileSystemResultTypes.InvalidState())
        {
            return new FileSystemContextResultTypes.InvalidMove();
        }

        CurrentPath = string.Empty;
        Mode = string.Empty;
        return new FileSystemContextResultTypes.Success();
    }

    public string ResolvePath(string relativeOrAbsolutePath)
    {
        if (Path.IsPathRooted(relativeOrAbsolutePath))
        {
            return relativeOrAbsolutePath;
        }

        return Path.Combine(CurrentPath, relativeOrAbsolutePath);
    }

    public FileSystemContextResultTypes TreeGoTo(string path)
    {
        string newPath = ResolvePath(path);

        if (!Directory.Exists(newPath))
        {
            return new FileSystemContextResultTypes.WrongPath();
        }

        CurrentPath = Path.GetFullPath(newPath);
        return new FileSystemContextResultTypes.Success();
    }

    public FileSystemContextResultTypes TreeList(int depth, TreeOutputConfig config)
    {
        var factory = new FileSystemComponentFactory();
        IFileSystemComponent component = factory.Create(CurrentPath);
        var vistor = new ConsoleTreeListVisitor(depth, config, _outputWriter);
        component.Accept(vistor);
        return new FileSystemContextResultTypes.Success();
    }

    public FileSystemContextResultTypes ShowInConsole(string path)
    {
        string content = File.ReadAllText(path);
        _outputWriter.WriteLine(content);
        return new FileSystemContextResultTypes.Success();
    }

    public string ResolveNameCollision(string directory, string newName)
    {
        string baseName = Path.GetFileNameWithoutExtension(newName);
        string extension = Path.GetExtension(newName);
        string newFilePath = Path.Combine(directory, newName);

        int counter = 1;
        while (File.Exists(newFilePath))
        {
            newFilePath = Path.Combine(directory, $"{baseName}({counter}){extension}");
            counter++;
        }

        return newFilePath;
    }
}