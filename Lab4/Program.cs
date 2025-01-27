using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.FileCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.GeneralCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var consoleOutputWriter = new ConsoleOutputWriter();

        var fileSystemContext = new LocalFileSystemContext(consoleOutputWriter);
        ICommandHandler chain = new ConnectCommandHandler(fileSystemContext)
            .AddNext(new DisconnectCommandHandler(fileSystemContext))
            .AddNext(new TreeGotoCommandHandler(fileSystemContext))
            .AddNext(new TreeListCommandHandler(fileSystemContext))
            .AddNext(new FileMoveCommandHandler(fileSystemContext))
            .AddNext(new FileCopyCommandHandler(fileSystemContext))
            .AddNext(new FileDeleteCommandHandler(fileSystemContext))
            .AddNext(new FileRenameCommandHandler(fileSystemContext))
            .AddNext(new FileShowCommandHandler(fileSystemContext));

        while (true)
        {
            string? input = Console.ReadLine();
            string[] argsArray = input?.Split(' ') ?? Array.Empty<string>();

            ICommand? command = chain.Handle(argsArray);
            if (command?.Execute() != new CommandResultTypes.Success())
            {
                break;
            }
        }
    }
}