using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.GeneralCommandHandlers;

public class TreeGotoCommandHandler : CommandHandlerBase
{
    private readonly IFileSystemContext _context;

    public TreeGotoCommandHandler(IFileSystemContext context)
    {
        _context = context;
    }

    public override ICommand? Handle(string[] request)
    {
        var argumentsParser = new ArgumentsParser();
        CommandArguments arguments = argumentsParser.Parse(request);
        if (!ParserChecker.CheckTreeGotoParser(arguments))
            return Next?.Handle(request);
        ICommandParser parser = ParserFactory.CreateParser("tree goto");

        return parser.Parse(_context, arguments);
    }
}