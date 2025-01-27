using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ArgumentsParser
{
    public CommandsRepository CommandsRepository { get; set; } = new CommandsRepository();

    public CommandArguments Parse(string[] args)
    {
        string command = args[0];
        string? modification = null;
        var parameters = new Collection<string>();
        var flags = new ConcurrentDictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        string[] validModifications = CommandsRepository.GetCommands(command);
        int start = 1;
        if (validModifications.Length > 0 && args.Length > 1 && validModifications.Contains(args[1]))
        {
            modification = args[1];
            start = 2;
        }

        for (int i = start; i < args.Length; i++)
        {
            if (args[i].StartsWith('-'))
            {
                string flag = args[i];
                string? value = null;

                if (i + 1 < args.Length && !args[i + 1].StartsWith('-'))
                {
                    value = args[i + 1];
                    i++;
                }

                flags[flag] = value;
            }
            else
            {
                parameters.Add(args[i]);
            }
        }

        return new CommandArguments(command, modification, parameters, flags);
    }
}