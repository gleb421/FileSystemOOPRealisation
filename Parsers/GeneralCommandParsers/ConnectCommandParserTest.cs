using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.GeneralCommandParsers;

[TestSubject(typeof(ConnectCommandParser))]
public class ConnectCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnConnectCommand_WithCorrectFileSystemType()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new ConnectCommandParser();
        var args = new CommandArguments(
            "connect",
            null, // No modification
            new() { "FileSystemType" },
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<ConnectCommand>(command);

        var connectCommand = (ConnectCommand)command;
        Assert.Equal("FileSystemType", connectCommand.Path);
    }
}