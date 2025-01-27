using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.FileCommandParsers;

[TestSubject(typeof(FileShowCommandParser))]
public class FileShowCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnFileShowCommand_WithCorrectPathAndMode()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new FileShowCommandParser();
        var args = new CommandArguments(
            "file",
            "show",
            new() { "/path/to/file" },
            new() { ["-m"] = "hex" });

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileShowCommand>(command);

        var fileShowCommand = (FileShowCommand)command;
        Assert.Equal("/path/to/file", fileShowCommand.Path);
        Assert.Equal("hex", fileShowCommand.Mode);
    }
}