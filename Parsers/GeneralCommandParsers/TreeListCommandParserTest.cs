using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.GeneralCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.GeneralCommandParsers;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers.GeneralCommandParsers;

[TestSubject(typeof(TreeListCommandParser))]
public class TreeListCommandParserTest
{
    [Fact]
    public void Parse_ShouldReturnTreeListCommand_WithCorrectDepth()
    {
        // Arrange
        var mockFileSystemContext = new Mock<IFileSystemContext>();
        var parser = new TreeListCommandParser();
        var args = new CommandArguments(
            "tree",
            "list",
            new(),
            new() { ["-d"] = "3" });

        // Act
        ICommand command = parser.Parse(mockFileSystemContext.Object, args);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<TreeListCommand>(command);

        var treeListCommand = (TreeListCommand)command;
        Assert.Equal(3, treeListCommand.Depth);
    }
}