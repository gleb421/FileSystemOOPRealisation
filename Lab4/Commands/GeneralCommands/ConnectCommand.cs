using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;

public class ConnectCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string Path { get; private set; }

    public string? Mode { get; private set; }

    public ConnectCommand(IFileSystemContext context, string path, string? mode)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        Path = path ?? throw new ArgumentNullException(nameof(path));
        Mode = mode;
    }

    public CommandResultTypes Execute()
    {
        if (Mode != "local")
        {
            return new CommandResultTypes.NoThisModel();
        }

        if (Context.Connect(Path, Mode) == new FileSystemContextResultTypes.Success())
        {
            return new CommandResultTypes.Success();
        }

        if (Context.Connect(Path, Mode) == new FileSystemContextResultTypes.WrongPath())
            return new CommandResultTypes.WrongPath();

        return new CommandResultTypes.FileSystemError();
    }
}