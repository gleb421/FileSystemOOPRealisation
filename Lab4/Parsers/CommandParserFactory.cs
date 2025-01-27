using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;
using System.Collections.Concurrent;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandParserFactory
{
    public IDictionary<string, Func<ICommandParser>> Parsers { get; private set; }

    public CommandParserFactory()
    {
        Parsers = new ConcurrentDictionary<string, Func<ICommandParser>>(StringComparer.OrdinalIgnoreCase);
        Parsers.Add(
            "connect",
            () => new ConnectCommandParser());
        Parsers.Add(
            "disconnect",
            () => new DisconnectCommandParser());
        Parsers.Add(
            "tree goto",
            () => new TreeGoToParser());
        Parsers.Add(
            "tree list",
            () => new TreeListCommandParser());
        Parsers.Add(
            "file show",
            () => new FileShowCommandParser());
        Parsers.Add(
            "file move",
            () => new FileMoveCommandParser());
        Parsers.Add(
            "file copy",
            () => new FileCopyCommandParser());
        Parsers.Add(
            "file delete",
            () => new FileDeleteCommandParser());
        Parsers.Add(
            "file rename",
            () => new FileRenameCommandParser());
    }

    public ICommandParser CreateParser(string command)
    {
        if (Parsers.TryGetValue(command, out Func<ICommandParser>? parserFactory))
        {
            return parserFactory();
        }

        throw new ArgumentException($"No parser found for command: {command}");
    }
}