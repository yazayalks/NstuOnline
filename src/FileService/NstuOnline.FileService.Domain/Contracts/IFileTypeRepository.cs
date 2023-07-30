using Common.Data.Repositories;
using NstuOnline.FileService.Domain.Entities;

namespace NstuOnline.FileService.Domain.Contracts;

public interface IFileTypeRepository : IDictionaryRepository<FileType, byte>
{
    
}