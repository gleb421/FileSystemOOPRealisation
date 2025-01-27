using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class ConsoleTreeListVisitor : IFileSystemComponentVisitor
{
    private readonly TreeOutputConfig _config;
    private readonly IOutputWriter _outputWriter;
    private int _curDepth;

    public int MaxDepth { get; private set; }

    public ConsoleTreeListVisitor(int depth, TreeOutputConfig config, IOutputWriter outputWriter)
    {
        MaxDepth = depth;
        _config = config;
        _outputWriter = outputWriter;
    }

    public void Visit(FileFileSystemComponent component)
    {
        WriteIndented(component.Name, isFile: true);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        WriteIndented(component.Name, isFile: false);

        _curDepth += 1;

        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            if (_curDepth <= MaxDepth)
                innerComponent.Accept(this);
        }

        _curDepth -= 1;
    }

    private void WriteIndented(string value, bool isFile)
    {
        if (_curDepth > 0)
        {
            _outputWriter.Write(string.Concat(Enumerable.Repeat(_config.Indentation, _curDepth)));
            _outputWriter.Write(isFile ? _config.FilePrefix : _config.DirectoryPrefix);
        }

        _outputWriter.WriteLine(value);
    }
}