using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;

public class TreeGotoCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string Path { get; private set; }

    public TreeGotoCommand(IFileSystemContext context, string path)
    {
        Context = context;
        Path = path;
    }

    public CommandResultTypes Execute()
    {
        Context.TreeGoTo(Path);
        return new CommandResultTypes.Success();
    }
}