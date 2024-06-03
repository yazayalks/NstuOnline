﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("message");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Text)
            .HasMaxLength(1000);
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        builder
            .HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId);
        
        builder
            .HasOne(x => x.MessageType)
            .WithMany()
            .HasForeignKey(x => x.MessageTypeId);
        
        builder
            .HasOne(x => x.MessageStatus)
            .WithMany()
            .HasForeignKey(x => x.MessageStatusId);
        
        builder
            .Property(x => x.ExternalId)
            .HasMaxLength(50);
        
        builder
            .HasIndex(x => x.ExternalId)
            .IsUnique();
    }
}