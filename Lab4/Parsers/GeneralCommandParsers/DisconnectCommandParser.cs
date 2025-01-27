using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;

public class DisconnectCommandParser : ICommandParser
{
    public ICommand Parse(IFileSystemContext fileSystemContext, CommandArguments arguments)
    {
        return new DisconnectCommand(fileSystemContext);
    }
}