using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileCopyCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string SourcePath { get; private set; }

    public string DestinationPath { get; private set; }

    public FileCopyCommand(IFileSystemContext context, string sourcePath, string destinationPath)
    {
        Context = context;
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public CommandResultTypes Execute()
    {
        string fullSourcePath = Path.Combine(Context.CurrentPath, SourcePath);
        string fullDestinationPath = Path.Combine(Context.CurrentPath, DestinationPath);

        if (!File.Exists(fullSourcePath))
        {
            return new CommandResultTypes.WrongPath();
        }

        string destinationDirectory = Path.GetDirectoryName(fullDestinationPath) ?? string.Empty;

        if (!Directory.Exists(destinationDirectory))
        {
            return new CommandResultTypes.WrongPath();
        }

        File.Copy(fullSourcePath, fullDestinationPath, overwrite: true);
        return new CommandResultTypes.Success();
    }
}