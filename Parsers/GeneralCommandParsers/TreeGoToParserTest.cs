using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.GeneralCommandParsers;

[TestSubject(typeof(TreeGoToParser))]
public class TreeGoToParserTest
{
    [Fact]
    public void Parse_ShouldReturnTreeGoToCommand_WithCorrectPath()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new TreeGoToParser();
        var args = new CommandArguments(
            "tree",
            "goto",
            new() { "/path/to/directory" },
            new());

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<TreeGotoCommand>(command);

        var treeGoToCommand = (TreeGotoCommand)command;
        Assert.Equal("/path/to/directory", treeGoToCommand.Path);
    }
}