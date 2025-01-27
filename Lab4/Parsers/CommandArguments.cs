using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandArguments
{
    public string Command { get; private set; }

    public string? Modification { get; private set; }

    public Collection<string> Parameters { get; private set; }

    public IDictionary<string, string?> Flags { get; private set; }

    public CommandArguments(string command, string? modification, Collection<string> parameters, ConcurrentDictionary<string, string?> flags)
    {
        Command = command;
        Modification = modification;
        Parameters = parameters;
        Flags = flags;
    }

    public bool HasFlag(string flag) => Flags.ContainsKey(flag);

    public string? GetFlagValue(string flag) => Flags.TryGetValue(flag, out string? value) ? value : null;
}