namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ParserChecker
{
    public bool CheckConnectParser(CommandArguments args)
    {
        return args.Command.Equals("connect", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is null
               && args.HasFlag("-m")
               && args.Parameters.Count == 1;
    }

    public bool CheckDisconnectParser(CommandArguments args)
    {
        return args.Command.Equals("disconnect", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is null
               && args.Flags.Count == 0
               && args.Parameters.Count == 0;
    }

    public bool CheckTreeGotoParser(CommandArguments args)
    {
        return args.Command.Equals("tree", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null &&
               args.Modification.Equals("goto", System.StringComparison.OrdinalIgnoreCase)
               && args.Flags.Count == 0
               && args.Parameters.Count == 1;
    }

    public bool CheckTreeListParser(CommandArguments args)
    {
        return args.Command.Equals("tree", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null
               && args.Modification.Equals("list", System.StringComparison.OrdinalIgnoreCase)
               && args.HasFlag("-d")
               && args.Parameters.Count == 0;
    }

    public bool CheckFileShowParser(CommandArguments args)
    {
        return args.Command.Equals("file", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null
               && args.Modification.Equals("show", System.StringComparison.OrdinalIgnoreCase)
               && args.HasFlag("-m")
               && args.Parameters.Count == 1;
    }

    public bool CheckFileMoveParser(CommandArguments args)
    {
        return args.Command.Equals("file", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null
               && args.Modification.Equals("move", System.StringComparison.OrdinalIgnoreCase)
               && args.Flags.Count == 0
               && args.Parameters.Count == 2;
    }

    public bool CheckFileCopyParser(CommandArguments args)
    {
        return args.Command.Equals("file", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null
               && args.Modification.Equals("copy", System.StringComparison.OrdinalIgnoreCase)
               && args.Flags.Count == 0
               && args.Parameters.Count == 2;
    }

    public bool CheckFileDeleteParser(CommandArguments args)
    {
        return args.Command.Equals("file", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null
               && args.Modification.Equals("delete", System.StringComparison.OrdinalIgnoreCase)
               && args.Flags.Count == 0
               && args.Parameters.Count == 1;
    }

    public bool CheckFileRenameParser(CommandArguments args)
    {
        return args.Command.Equals("file", System.StringComparison.OrdinalIgnoreCase)
               && args.Modification is not null
               && args.Modification.Equals("rename", System.StringComparison.OrdinalIgnoreCase)
               && args.Flags.Count == 0
               && args.Parameters.Count == 2;
    }
}