﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NstuOnline.PortfolioService.Infrastructure.Database;

#nullable disable

namespace NstuOnline.PortfolioService.Infrastructure.Database.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20240520001152_NEWNEW3")]
    partial class NEWNEW3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Attachment", b =>
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

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.AttachmentType", b =>
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

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte>("PortfolioTypeId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioTypeId");

                    b.ToTable("portfolio", (string)null);
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.PortfolioType", b =>
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

                    b.ToTable("portfolio_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Code = "educational",
                            Name = "Учебное"
                        },
                        new
                        {
                            Id = (byte)2,
                            Code = "personal",
                            Name = "Личное"
                        });
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.PortfolioUser", b =>
                {
                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("PortfolioId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("portfolio_user", (string)null);
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("topic", (string)null);
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.TopicAttachment", b =>
                {
                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uuid");

                    b.HasKey("TopicId", "AttachmentId");

                    b.HasIndex("AttachmentId");

                    b.ToTable("topic_attachment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Attachment", b =>
                {
                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.AttachmentType", "AttachmentType")
                        .WithMany()
                        .HasForeignKey("AttachmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttachmentType");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Portfolio", b =>
                {
                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.PortfolioType", "PortfolioType")
                        .WithMany()
                        .HasForeignKey("PortfolioTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortfolioType");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.PortfolioUser", b =>
                {
                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.Portfolio", "Portfolio")
                        .WithMany("Users")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Topic", b =>
                {
                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.Portfolio", "Portfolio")
                        .WithMany("Topics")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.TopicAttachment", b =>
                {
                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.Attachment", "Attachment")
                        .WithMany("Topics")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.PortfolioService.Domain.Entity.Topic", "Topic")
                        .WithMany("Attachments")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Attachment", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Portfolio", b =>
                {
                    b.Navigation("Topics");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NstuOnline.PortfolioService.Domain.Entity.Topic", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
