using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FileCommandHandlers;

public class FileRenameCommandHandler : CommandHandlerBase
{
    private readonly IFileSystemContext _context;

    public FileRenameCommandHandler(IFileSystemContext context)
    {
        _context = context;
    }

    public override ICommand? Handle(string[] request)
    {
        var argumentsParser = new ArgumentsParser();
        CommandArguments arguments = argumentsParser.Parse(request);
        if (!ParserChecker.CheckFileRenameParser(arguments))
            return Next?.Handle(request);
        ICommandParser parser = ParserFactory.CreateParser("file rename");

        return parser.Parse(_context, arguments);
    }
}