using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using JetBrains.Annotations;
using Xunit;

namespace Lab4.Tests.Parsers;

[TestSubject(typeof(ArgumentsParser))]
public class ArgumentsParserTest
{
    [Fact]
    public void Parse_ShouldParseSimpleCommandWithoutArguments()
    {
        // Arrange
        var parser = new ArgumentsParser();
        string[] args = new[] { "disconnect" };

        // Act
        CommandArguments result = parser.Parse(args);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("disconnect", result.Command);
        Assert.Null(result.Modification);
        Assert.Empty(result.Parameters);
        Assert.Empty(result.Flags);
    }

    [Fact]
    public void Parse_ShouldParseCommandWithModification()
    {
        // Arrange
        var parser = new ArgumentsParser();
        string[] args = new[] { "tree", "goto", "/some/path" };

        // Act
        CommandArguments result = parser.Parse(args);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("tree", result.Command);
        Assert.Equal("goto", result.Modification);
        Assert.Single(result.Parameters);
        Assert.Equal("/some/path", result.Parameters[0]);
        Assert.Empty(result.Flags);
    }

    [Fact]
    public void Parse_ShouldParseCommandWithFlags()
    {
        // Arrange
        var parser = new ArgumentsParser();
        string[] args = new[] { "tree", "list", "-d", "2" };

        // Act
        CommandArguments result = parser.Parse(args);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("tree", result.Command);
        Assert.Equal("list", result.Modification);
        Assert.Empty(result.Parameters);
        Assert.Single(result.Flags);
        Assert.True(result.Flags.ContainsKey("-d"));
        Assert.Equal("2", result.Flags["-d"]);
    }

    [Fact]
    public void Parse_ShouldParseCommandWithMultipleParametersAndFlags()
    {
        // Arrange
        var parser = new ArgumentsParser();
        string[] args = new[] { "file", "move", "/source/path", "/destination/path", "-m", "overwrite" };

        // Act
        CommandArguments result = parser.Parse(args);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("file", result.Command);
        Assert.Equal("move", result.Modification);
        Assert.Equal(2, result.Parameters.Count);
        Assert.Equal("/source/path", result.Parameters[0]);
        Assert.Equal("/destination/path", result.Parameters[1]);
        Assert.Single(result.Flags);
        Assert.True(result.Flags.ContainsKey("-m"));
        Assert.Equal("overwrite", result.Flags["-m"]);
    }
}