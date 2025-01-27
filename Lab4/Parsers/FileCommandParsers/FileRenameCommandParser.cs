using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;

public class FileRenameCommandParser : ICommandParser
{
    public ICommand Parse(IFileSystemContext fileSystemContext, CommandArguments arguments)
    {
        string path = arguments.Parameters[0];
        string newName = arguments.Parameters[1];
        return new FileRenameCommand(fileSystemContext, path, newName);
    }
}