using System;

namespace KitCore.Domain.Service;

public interface IFileService
{
    Task ImportFromDirectoryAsync(string directoryPath);
}
