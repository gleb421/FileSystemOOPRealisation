using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.FileSystemContextes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileRenameCommand : ICommand
{
    public IFileSystemContext Context { get; private set; }

    public string Path { get; private set; }

    public string NewName { get; private set; }

    public FileRenameCommand(IFileSystemContext context, string path, string newName)
    {
        Context = context;
        Path = path;
        NewName = newName;
    }

    public CommandResultTypes Execute()
    {
        {
            string fullPath = System.IO.Path.Combine(Context.CurrentPath, Path);

            // Проверяем, существует ли файл по старому пути
            if (!File.Exists(fullPath))
            {
                return new CommandResultTypes.WrongPath();
            }

            string directory = System.IO.Path.GetDirectoryName(fullPath) ?? string.Empty;
            string newFullPath = System.IO.Path.Combine(directory, NewName);

            // Если файл с новым именем уже существует, пытаемся разрешить коллизию
            if (File.Exists(newFullPath))
            {
                newFullPath = Context.ResolveNameCollision(directory, NewName);
            }

            // Переименовываем файл
            File.Move(fullPath, newFullPath);

            return new CommandResultTypes.Success();
        }
    }
}