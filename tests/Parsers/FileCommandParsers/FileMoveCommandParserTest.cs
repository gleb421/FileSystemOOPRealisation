using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.FileCommandParsers;

[TestSubject(typeof(FileMoveCommandParser))]
[TestSubject(typeof(FileMoveCommandParser))]
public class FileMoveCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnFileMoveCommand_WithCorrectSourceAndDestination()
    {
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new FileMoveCommandParser();
        var args = new CommandArguments(
            "file",
            "move",
            new() { "/source/path", "/destination/path" },
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileMoveCommand>(command);

        var fileMoveCommand = (FileMoveCommand)command;
        Assert.Equal("/source/path", fileMoveCommand.SourcePath);
        Assert.Equal("/destination/path", fileMoveCommand.DestinationPath);
    }
}