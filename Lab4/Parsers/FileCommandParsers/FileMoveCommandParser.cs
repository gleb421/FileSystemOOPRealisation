using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;

public class FileMoveCommandParser : ICommandParser
{
    public ICommand Parse(IFileSystemContext fileSystemContext, CommandArguments arguments)
    {
        string sourcePath = arguments.Parameters[0];
        string destinationPath = arguments.Parameters[1];
        return new FileMoveCommand(fileSystemContext, sourcePath, destinationPath);
    }
}