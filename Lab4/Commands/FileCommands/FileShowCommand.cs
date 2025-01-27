using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileShowCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string Path { get; private set; }

    public string? Mode { get; private set; }

    public FileShowCommand(IFileSystemContext context, string path, string? mode)
    {
        Context = context;
        Path = path;
        Mode = mode;
    }

    public CommandResultTypes Execute()
    {
        string fullPath = Context.ResolvePath(Path);

        if (!File.Exists(fullPath))
        {
            return new CommandResultTypes.WrongPath();
        }

        if (Mode == "console")
        {
            Context.ShowInConsole(fullPath);
            return new CommandResultTypes.Success();
        }

        return new CommandResultTypes.NoThisModel();
    }
}