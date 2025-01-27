using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.FileCommandParsers;

[TestSubject(typeof(FileRenameCommandParser))]
public class FileRenameCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnFileRenameCommand_WithCorrectPathAndNewName()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new FileRenameCommandParser();
        var args = new CommandArguments(
            "file",
            "rename",
            new() { "/path/to/file", "newname" },
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileRenameCommand>(command);

        var fileRenameCommand = (FileRenameCommand)command;
        Assert.Equal("/path/to/file", fileRenameCommand.Path);
        Assert.Equal("newname", fileRenameCommand.NewName);
    }
}