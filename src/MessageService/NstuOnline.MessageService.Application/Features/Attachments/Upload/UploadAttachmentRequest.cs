using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Minio;
using NstuOnline.MessageService.Domain.Constants;

namespace NstuOnline.MessageService.Application.Features.Attachments.Upload;

public record UploadAttachmentRequest(IFormFile File, Guid UserId) : IRequest;

public class UploadAttachmentHandler : IRequestHandler<UploadAttachmentRequest>
{
    private readonly MinioClient _minioClient;

    public UploadAttachmentHandler(MinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    public async Task Handle(UploadAttachmentRequest request, CancellationToken cancellationToken)
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

        var fileName = "photo/" +
                       DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss") + 
                       "_" +
                       request.File.FileName;
        
        var putObjectArgs = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithStreamData(stream)
            .WithObject(fileName)
            .WithObjectSize(stream.Length)
            .WithContentType(MediaTypeNames.Application.Octet);

        await _minioClient.PutObjectAsync(putObjectArgs, cancellationToken);
        
        
        var presignedGetObjectArgs = new PresignedGetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileName)
            .WithExpiry(60 * 60 * 24);

        var url = await _minioClient.PresignedGetObjectAsync(presignedGetObjectArgs);
    }
}