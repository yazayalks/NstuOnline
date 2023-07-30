using MediatR;
using Minio;
using NstuOnline.FileService.Domain.Constants;
using NstuOnline.FileService.Domain.Contracts;

namespace NstuOnline.FileService.Application.Features.Files.GetUrlById;

public record GetFileUrlByIdRequest(Guid Id, Guid UserId) : IRequest<string>;

public class GetFileUrlByIdHandler : IRequestHandler<GetFileUrlByIdRequest, string>
{
    private readonly MinioClient _minioClient;
    private readonly IFileRepository _fileRepository;

    public GetFileUrlByIdHandler(MinioClient minioClient, IFileRepository fileRepository)
    {
        _minioClient = minioClient;
        _fileRepository = fileRepository;
    }

    public async Task<string> Handle(GetFileUrlByIdRequest request, CancellationToken cancellationToken)
    {
        var file = await _fileRepository.GetById(request.Id, asNoTracking: true, cancellationToken: cancellationToken);

        if (file is null)
        {
            throw new NotImplementedException();
        }
        
        var bucketName = Buckets.Prefix + file.UserId;
        
        var presignedGetObjectArgs = new PresignedGetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(file.ObjectName)
            .WithExpiry(60 * 60 * 24);
        
        var url = await _minioClient.PresignedGetObjectAsync(presignedGetObjectArgs);
        
        return url;
    }
}