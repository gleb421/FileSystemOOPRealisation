using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.GeneralCommandHandlers;

public class TreeListCommandHandler : CommandHandlerBase
{
    private readonly IFileSystemContext _context;

    public TreeListCommandHandler(IFileSystemContext context)
    {
        _context = context;
    }

    public override ICommand? Handle(string[] request)
    {
        var argumentsParser = new ArgumentsParser();
        CommandArguments arguments = argumentsParser.Parse(request);
        if (!ParserChecker.CheckTreeListParser(arguments))
            return Next?.Handle(request);
        ICommandParser parser = ParserFactory.CreateParser("tree list");

        return parser.Parse(_context, arguments);
    }
}