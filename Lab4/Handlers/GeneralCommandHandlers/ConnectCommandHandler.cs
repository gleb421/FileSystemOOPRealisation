using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.GeneralCommandHandlers;

public class ConnectCommandHandler : CommandHandlerBase
{
    private readonly IFileSystemContext _context;

    public ConnectCommandHandler(IFileSystemContext context)
    {
        _context = context;
    }

    public override ICommand? Handle(string[] request)
    {
        var argumentsParser = new ArgumentsParser();
        CommandArguments arguments = argumentsParser.Parse(request);
        if (!ParserChecker.CheckConnectParser(arguments))
            return Next?.Handle(request);
        ICommandParser parser = ParserFactory.CreateParser("connect");

        return parser.Parse(_context, arguments);
    }
}