﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NstuOnline.EducationalStructure.Infrastructure.Database;

#nullable disable

namespace NstuOnline.EducationalStructure.Infrastructure.Database.Migrations
{
    [DbContext(typeof(EducationalStructureContext))]
    partial class EducationalStructureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.AccreditationType", b =>
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

                    b.ToTable("accreditation_type", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("AttachmentTypeId")
                        .HasColumnType("smallint");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("attachment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("FacultyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("department", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("faculty", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Flow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("flow", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid?>("FlowId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<byte>("Semester")
                        .HasColumnType("smallint");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("FlowId");

                    b.ToTable("group", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("specialization", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ExternalId")
                        .HasColumnType("text");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SyllabusId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SyllabusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.StudyFormType", b =>
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

                    b.ToTable("study_form_type", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.StudyLevel", b =>
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

                    b.Property<byte>("NbSemester")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("study_level", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("subject", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Syllabus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("AccreditationTypeId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uuid");

                    b.Property<byte>("StudyFormTypeId")
                        .HasColumnType("smallint");

                    b.Property<byte>("StudyLevelId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AccreditationTypeId");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("StudyFormTypeId");

                    b.HasIndex("StudyLevelId");

                    b.ToTable("syllabus", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.SyllabusSubject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SyllabusId")
                        .HasColumnType("uuid");

                    b.Property<byte>("ConsultationHours")
                        .HasColumnType("smallint");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte>("LabHours")
                        .HasColumnType("smallint");

                    b.Property<byte>("LectureHours")
                        .HasColumnType("smallint");

                    b.Property<byte>("NbControlWork")
                        .HasColumnType("smallint");

                    b.Property<byte>("NbCourseWork")
                        .HasColumnType("smallint");

                    b.Property<byte>("NbSettlementWork")
                        .HasColumnType("smallint");

                    b.Property<byte>("PractiseHours")
                        .HasColumnType("smallint");

                    b.Property<byte>("Semester")
                        .HasColumnType("smallint");

                    b.Property<bool>("WithExam")
                        .HasColumnType("boolean");

                    b.Property<bool>("WithGos")
                        .HasColumnType("boolean");

                    b.Property<bool>("WithСredit")
                        .HasColumnType("boolean");

                    b.HasKey("SubjectId", "SyllabusId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("SyllabusId");

                    b.ToTable("syllabus_subject", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("teacher", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.TeachingAssignment", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.HasKey("SubjectId", "TeacherId", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("teaching_assignment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("SubjectId");

                    b.ToTable("topic", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.TopicAttachment", b =>
                {
                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uuid");

                    b.HasKey("TopicId", "AttachmentId");

                    b.HasIndex("AttachmentId");

                    b.ToTable("topic_attachment", (string)null);
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Department", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Group", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Flow", "Flow")
                        .WithMany("Groups")
                        .HasForeignKey("FlowId");

                    b.Navigation("Department");

                    b.Navigation("Flow");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Specialization", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Student", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Syllabus", "Syllabus")
                        .WithMany()
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Syllabus");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Syllabus", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.AccreditationType", "AccreditationType")
                        .WithMany()
                        .HasForeignKey("AccreditationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.StudyFormType", "StudyFormType")
                        .WithMany()
                        .HasForeignKey("StudyFormTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.StudyLevel", "StudyLevel")
                        .WithMany()
                        .HasForeignKey("StudyLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccreditationType");

                    b.Navigation("Specialization");

                    b.Navigation("StudyFormType");

                    b.Navigation("StudyLevel");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.SyllabusSubject", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Syllabus", "Syllabus")
                        .WithMany()
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Syllabus");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Teacher", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.TeachingAssignment", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Topic", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Attachment", null)
                        .WithMany("Topics")
                        .HasForeignKey("AttachmentId");

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.TopicAttachment", b =>
                {
                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NstuOnline.EducationalStructure.Domain.Entity.Topic", "Topic")
                        .WithMany("Attachments")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Attachment", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Flow", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("NstuOnline.EducationalStructure.Domain.Entity.Topic", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
