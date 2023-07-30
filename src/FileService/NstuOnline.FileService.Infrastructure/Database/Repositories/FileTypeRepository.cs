using Common.Data.EntityFramework.Repositories;
using NstuOnline.FileService.Domain.Contracts;
using NstuOnline.FileService.Domain.Entities;

namespace NstuOnline.FileService.Infrastructure.Database.Repositories;

public class FileTypeRepository : DictionaryRepository<FileType, byte>, IFileTypeRepository
{
    public FileTypeRepository(FileContext context) : base(context)
    {
    }
}