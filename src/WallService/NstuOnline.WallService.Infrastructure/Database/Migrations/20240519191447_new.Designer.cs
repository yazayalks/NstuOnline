﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NstuOnline.WallService.Infrastructure.Database;

#nullable disable

namespace NstuOnline.WallService.Infrastructure.Database.Migrations
{
    [DbContext(typeof(WallContext))]
    [Migration("20240519191447_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("AttachmentTypeId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentTypeId");

                    b.ToTable("attachment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.AttachmentType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("attachment_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Code = "document",
                            Name = "Документ"
                        },
                        new
                        {
                            Id = (byte)2,
                            Code = "photo",
                            Name = "Фото"
                        });
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.AttachmentUser", b =>
                {
                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("AttachmentId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("attachment_user", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("record", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.RecordAttachment", b =>
                {
                    b.Property<Guid>("RecordId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uuid");

                    b.HasKey("RecordId", "AttachmentId");

                    b.HasIndex("AttachmentId");

                    b.ToTable("record_attachment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.RecordUser", b =>
                {
                    b.Property<Guid>("RecordId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("RecordId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("record_user", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.Attachment", b =>
                {
                    b.HasOne("NstuOnline.WallService.Domain.Entity.AttachmentType", "AttachmentType")
                        .WithMany()
                        .HasForeignKey("AttachmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttachmentType");
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.AttachmentUser", b =>
                {
                    b.HasOne("NstuOnline.WallService.Domain.Entity.Attachment", "Attachment")
                        .WithMany("Users")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.WallService.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.Record", b =>
                {
                    b.HasOne("NstuOnline.WallService.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.RecordAttachment", b =>
                {
                    b.HasOne("NstuOnline.WallService.Domain.Entity.Attachment", "Attachment")
                        .WithMany("Records")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.WallService.Domain.Entity.Record", "Record")
                        .WithMany("Attachments")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.RecordUser", b =>
                {
                    b.HasOne("NstuOnline.WallService.Domain.Entity.Record", "Record")
                        .WithMany("Users")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.WallService.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.Attachment", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NstuOnline.WallService.Domain.Entity.Record", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
