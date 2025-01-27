using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.GeneralCommandParsers;

[TestSubject(typeof(DisconnectCommandParser))]
public class DisconnectCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnDisconnectCommand()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new DisconnectCommandParser();
        var args = new CommandArguments(
            "disconnect",
            null, // No modification
            new(), // No parameters
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<DisconnectCommand>(command);
    }
}