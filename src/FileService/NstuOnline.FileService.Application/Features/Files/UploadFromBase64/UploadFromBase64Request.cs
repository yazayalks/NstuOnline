using System.Net.Mime;
using MediatR;
using Minio;
using NstuOnline.FileService.Domain.Constants;
using NstuOnline.FileService.Domain.Contracts;
using NstuOnline.FileService.Domain.Enums;
using FileDb = NstuOnline.FileService.Domain.Entities.File;

namespace NstuOnline.FileService.Application.Features.Files.UploadFromBase64;

public record UploadFromBase64Request : IRequest<Guid>
{
    public string DataBase64 { get; set; }
    
    public string FileName { get; set; }
    
    public Guid UserId { get; set; }
}

public class UploadFromBase64Handler : IRequestHandler<UploadFromBase64Request, Guid>
{
    private readonly MinioClient _minioClient;
    private readonly IFileRepository _fileRepository;

    public UploadFromBase64Handler(MinioClient minioClient, IFileRepository fileRepository)
    {
        _minioClient = minioClient;
        _fileRepository = fileRepository;
    }

    public async Task<Guid> Handle(UploadFromBase64Request request, CancellationToken cancellationToken)
    {
        var bucketName = Buckets.Prefix + request.UserId;
        var beArgs = new BucketExistsArgs().WithBucket(bucketName);
        
        var found = await _minioClient.BucketExistsAsync(beArgs, cancellationToken);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs()
                .WithBucket(bucketName);
            await _minioClient.MakeBucketAsync(mbArgs, cancellationToken);
        }
        
        var stream = new MemoryStream(Convert.FromBase64String(request.DataBase64));

        var dateTimeUtcNow = DateTime.UtcNow;
        
        var objectName = "photo/" + //TODO::
                         DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss") + 
                         "_" +
                         request.FileName;

        var headers = new Dictionary<string, string>
        {
            { FileHeaders.FileName, request.FileName }
        };
        
        var putObjectArgs = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithStreamData(stream)
            .WithObject(objectName)
            .WithObjectSize(stream.Length)
            .WithHeaders(headers)
            .WithContentType(MediaTypeNames.Application.Octet);

        await _minioClient.PutObjectAsync(putObjectArgs, cancellationToken);


        var newFile = new FileDb
        {
            UserId = request.UserId,
            Name = request.FileName,
            TypeId = (byte)FileTypes.Image, //TODO
            CreateDateTime = dateTimeUtcNow,
            ObjectName = objectName
        };

        await _fileRepository.Add(newFile, cancellationToken);

        return newFile.Id;
    }
}
