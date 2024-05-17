﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NstuOnline.WorkCompletion.Infrastructure.Database;

#nullable disable

namespace NstuOnline.WorkCompletion.Infrastructure.Database.Migrations
{
    [DbContext(typeof(WorkCompletionContext))]
    partial class WorkCompletionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WorkCompletionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkCompletionId");

                    b.HasIndex("WorkId");

                    b.ToTable("attachment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("work", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ResultId")
                        .HasColumnType("uuid");

                    b.Property<byte>("StatusId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.HasIndex("StatusId");

                    b.HasIndex("WorkId");

                    b.ToTable("work_completion", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool?>("IsPassed")
                        .HasColumnType("boolean");

                    b.Property<byte?>("Mark")
                        .HasColumnType("smallint");

                    b.Property<byte?>("Percent")
                        .HasColumnType("smallint");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("work_completion_result", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletionStatus", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("work_completion_status", (string)null);
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.Attachment", b =>
                {
                    b.HasOne("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletion", null)
                        .WithMany("Attachments")
                        .HasForeignKey("WorkCompletionId");

                    b.HasOne("NstuOnline.WorkCompletion.Domain.Entity.Work", null)
                        .WithMany("Attachments")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletion", b =>
                {
                    b.HasOne("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletionResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");

                    b.HasOne("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletionStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.WorkCompletion.Domain.Entity.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Result");

                    b.Navigation("Status");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.Work", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("NstuOnline.WorkCompletion.Domain.Entity.WorkCompletion", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}