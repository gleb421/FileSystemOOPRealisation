using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FileCommandHandlers;

public class FileShowCommandHandler : CommandHandlerBase
{
    private readonly IFileSystemContext _context;

    public FileShowCommandHandler(IFileSystemContext context)
    {
        _context = context;
    }

    public override ICommand? Handle(string[] request)
    {
        var argumentsParser = new ArgumentsParser();
        CommandArguments arguments = argumentsParser.Parse(request);
        if (!ParserChecker.CheckFileShowParser(arguments))
            return Next?.Handle(request);
        ICommandParser parser = ParserFactory.CreateParser("file show");

        return parser.Parse(_context, arguments);
    }
}