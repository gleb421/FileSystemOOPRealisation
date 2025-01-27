using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.FileCommandParsers;

[TestSubject(typeof(FileDeleteCommandParser))]
public class FileDeleteCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnFileDeleteCommand_WithCorrectPath()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new FileDeleteCommandParser();
        var args = new CommandArguments(
            "file",
            "delete",
            new() { "/path/to/file" },
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileDeleteCommand>(command);

        var fileDeleteCommand = (FileDeleteCommand)command;
        Assert.Equal("/path/to/file", fileDeleteCommand.Path);
    }
}