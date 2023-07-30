using Common.Data.Repositories;
using FileDb = NstuOnline.FileService.Domain.Entities.File;

namespace NstuOnline.FileService.Domain.Contracts;

public interface IFileRepository : IRepository<FileDb, Guid>
{
    
}