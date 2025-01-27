using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileMoveCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string SourcePath { get; private set; }

    public string DestinationPath { get; private set; }

    public FileMoveCommand(IFileSystemContext context, string sourcePath, string destinationPath)
    {
        Context = context;
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public CommandResultTypes Execute()
    {
        string fullSourcePath = Path.Combine(Context.CurrentPath, SourcePath);
        string fullDestinationPath = Path.Combine(Context.CurrentPath, DestinationPath);

        // Проверяем, существует ли исходный файл
        if (!File.Exists(fullSourcePath))
        {
            return new CommandResultTypes.WrongPath();
        }

        string destinationDirectory = Path.GetDirectoryName(fullDestinationPath) ?? string.Empty;

        // Проверяем, существует ли целевая директория
        if (!Directory.Exists(destinationDirectory))
        {
            throw new DirectoryNotFoundException($"Destination directory not found: {destinationDirectory}");
        }

        if (File.Exists(fullDestinationPath))
        {
            fullDestinationPath = Context.ResolveNameCollision(destinationDirectory, Path.GetFileName(fullDestinationPath));
        }

        File.Move(fullSourcePath, fullDestinationPath);

        return new CommandResultTypes.Success();
    }
}