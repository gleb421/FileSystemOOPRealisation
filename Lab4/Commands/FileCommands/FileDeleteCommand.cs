using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string Path { get; private set; }

    public FileDeleteCommand(IFileSystemContext context, string path)
    {
        Context = context;
        Path = path;
    }

    public CommandResultTypes Execute()
    {
        string fullPath = System.IO.Path.Combine(Context.CurrentPath, Path);

        if (!File.Exists(fullPath))
        {
            return new CommandResultTypes.WrongPath();
        }

        File.Delete(fullPath);
        return new CommandResultTypes.Success();
    }
}