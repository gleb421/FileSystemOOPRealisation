using System.Collections.Concurrent;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CommandsRepository
{
    public ConcurrentDictionary<string, string[]> CommandAndModification { get; private set; }

    public CommandsRepository()
    {
        CommandAndModification = new ConcurrentDictionary<string, string[]>
        {
            ["console"] = Array.Empty<string>(),
            ["disconnect"] = Array.Empty<string>(),
            ["tree"] = new string[] { "goto", "list" },
            ["file"] = new string[] { "show", "move", "copy", "delete", "rename" },
        };
    }

    public string[] GetCommands(string command)
    {
        if (CommandAndModification.TryGetValue(command, out string[]? result))
        {
            return result;
        }

        return Array.Empty<string>();
    }
}