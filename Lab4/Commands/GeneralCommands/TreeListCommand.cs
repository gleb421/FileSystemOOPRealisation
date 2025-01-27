using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;

public class TreeListCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public int Depth { get; private set; }

    private readonly TreeOutputConfig _config;

    public TreeListCommand(IFileSystemContext context, int depth, TreeOutputConfig config)
    {
        Context = context;
        Depth = depth;
        _config = config;
    }

    public CommandResultTypes Execute()
    {
        Context.TreeList(Depth, _config);
        return new CommandResultTypes.Success();
    }
}