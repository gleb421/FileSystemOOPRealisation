using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.FileCommandParsers;

[TestSubject(typeof(FileCopyCommandParser))]
public class FileCopyCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnFileCopyCommand_WithCorrectSourceAndDestination()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new FileCopyCommandParser();
        var args = new CommandArguments(
            "file",
            "copy",
            new() { "/source/path", "/destination/path" },
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileCopyCommand>(command);

        var fileCopyCommand = (FileCopyCommand)command;
        Assert.Equal("/source/path", fileCopyCommand.SourcePath);
        Assert.Equal("/destination/path", fileCopyCommand.DestinationPath);
    }
}