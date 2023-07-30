using Common.Data.EntityFramework.Repositories;
using NstuOnline.FileService.Domain.Contracts;
using FileDb = NstuOnline.FileService.Domain.Entities.File;

namespace NstuOnline.FileService.Infrastructure.Database.Repositories;

public class FileRepository : RepositoryBase<FileDb, Guid>, IFileRepository
{
    public FileRepository(FileContext context) : base(context)
    {
    }
}