using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;

public class TreeListCommandParser : ICommandParser
{
    public ICommand Parse(IFileSystemContext fileSystemContext, CommandArguments arguments)
    {
        int depth = 1;
        if (arguments.GetFlagValue("-d") is string depthValue && int.TryParse(depthValue, out int parsedDepth))
        {
            depth = parsedDepth;
        }

        var config = new TreeOutputConfig
        {
            DirectoryPrefix = arguments.GetFlagValue("--dir-prefix") ?? "|–> ",
            FilePrefix = arguments.GetFlagValue("--file-prefix") ?? "|--> ",
            Indentation = arguments.GetFlagValue("--indent") ?? "   ",
        };

        return new TreeListCommand(fileSystemContext, depth, config);
    }
}