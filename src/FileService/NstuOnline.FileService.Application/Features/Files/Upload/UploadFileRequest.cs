using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Http;
using Minio;
using NstuOnline.FileService.Domain.Constants;
using NstuOnline.FileService.Domain.Contracts;
using NstuOnline.FileService.Domain.Enums;
using FileDb = NstuOnline.FileService.Domain.Entities.File;

namespace NstuOnline.FileService.Application.Features.Files.Upload;

public record UploadFileRequest(IFormFile File, Guid UserId) : IRequest;

public class UploadFileHandler : IRequestHandler<UploadFileRequest>
{
    private readonly MinioClient _minioClient;
    private readonly IFileRepository _fileRepository;

    public UploadFileHandler(
        MinioClient minioClient, 
        IFileRepository fileRepository)
    {
        _minioClient = minioClient;
        _fileRepository = fileRepository;
    }

    public async Task Handle(UploadFileRequest request, CancellationToken cancellationToken)
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
        
        var stream = request.File.OpenReadStream();

        var dateTimeUtcNow = DateTime.UtcNow;
        
        var objectName = "photo/" + //TODO::
                       DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss") + 
                       "_" +
                       request.File.FileName;

        var headers = new Dictionary<string, string>
        {
            { FileHeaders.FileName, request.File.FileName }
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
            Name = request.File.FileName,
            TypeId = (byte)FileTypes.Image, //TODO
            CreateDateTime = dateTimeUtcNow,
            ObjectName = objectName
        };

        await _fileRepository.Add(newFile, cancellationToken);
    }
}