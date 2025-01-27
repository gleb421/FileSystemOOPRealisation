using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public abstract class CommandHandlerBase : ICommandHandler
{
    protected ICommandHandler? Next { get; private set; }

    protected CommandParserFactory ParserFactory { get; } = new CommandParserFactory();

    protected ParserChecker ParserChecker { get; } = new ParserChecker();

    public ICommandHandler AddNext(ICommandHandler commandHandler)
    {
        if (Next is null)
        {
            Next = commandHandler;
        }
        else
        {
            Next.AddNext(commandHandler);
        }

        return this;
    }

    public abstract ICommand? Handle(string[] request);
}