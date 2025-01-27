using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;

public class DisconnectCommand : ICommand
{
    private readonly IFileSystemContext _context;

    public DisconnectCommand(IFileSystemContext context)
    {
        _context = context;
    }

    public CommandResultTypes Execute()
    {
        _context.Disconnect();
        return new CommandResultTypes.Success();
    }
}