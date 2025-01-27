using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;

public class ConnectCommandParser : ICommandParser
{
    public ICommand Parse(IFileSystemContext fileSystemContext, CommandArguments arguments)
    {
        string address = arguments.Parameters[0];
        string? mode = arguments.GetFlagValue("-m");
        return new ConnectCommand(fileSystemContext, address, mode);
    }
}
