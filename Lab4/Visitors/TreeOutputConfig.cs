namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class TreeOutputConfig
{
    public string DirectoryPrefix { get; set; } = "|–> ";

    public string FilePrefix { get; set; } = "|--> ";

    public string Indentation { get; set; } = "   ";

    public int DefaultDepth { get; set; } = 1;

    public TreeOutputConfig() { }

    public TreeOutputConfig(string directoryPrefix, string filePrefix, string indentation, int defaultDepth)
    {
        DirectoryPrefix = directoryPrefix;
        FilePrefix = filePrefix;
        Indentation = indentation;
        DefaultDepth = defaultDepth;
    }
}