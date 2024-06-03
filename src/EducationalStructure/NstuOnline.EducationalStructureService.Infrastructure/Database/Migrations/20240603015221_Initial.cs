using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.EducationalStructure.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accreditation_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accreditation_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "faculty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "flow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "study_form_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_form_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "study_level",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NbSemester = table.Column<byte>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_department_faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_topic_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Semester = table.Column<byte>(type: "smallint", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FlowId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_group_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_group_flow_FlowId",
                        column: x => x.FlowId,
                        principalTable: "flow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "specialization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specialization_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacher_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topic_attachment",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic_attachment", x => new { x.TopicId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_topic_attachment_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_topic_attachment_topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "syllabus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudyFormTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    AccreditationTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    StudyLevelId = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syllabus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_syllabus_accreditation_type_AccreditationTypeId",
                        column: x => x.AccreditationTypeId,
                        principalTable: "accreditation_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_syllabus_specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_syllabus_study_form_type_StudyFormTypeId",
                        column: x => x.StudyFormTypeId,
                        principalTable: "study_form_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_syllabus_study_level_StudyLevelId",
                        column: x => x.StudyLevelId,
                        principalTable: "study_level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teaching_assignment",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teaching_assignment", x => new { x.SubjectId, x.TeacherId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_teaching_assignment_group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teaching_assignment_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teaching_assignment_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    SyllabusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "syllabus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "syllabus_subject",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    SyllabusId = table.Column<Guid>(type: "uuid", nullable: false),
                    WithExam = table.Column<bool>(type: "boolean", nullable: false),
                    WithСredit = table.Column<bool>(type: "boolean", nullable: false),
                    WithGos = table.Column<bool>(type: "boolean", nullable: false),
                    Semester = table.Column<byte>(type: "smallint", nullable: false),
                    NbCourseWork = table.Column<byte>(type: "smallint", nullable: false),
                    NbSettlementWork = table.Column<byte>(type: "smallint", nullable: false),
                    NbControlWork = table.Column<byte>(type: "smallint", nullable: false),
                    LectureHours = table.Column<byte>(type: "smallint", nullable: false),
                    PractiseHours = table.Column<byte>(type: "smallint", nullable: false),
                    LabHours = table.Column<byte>(type: "smallint", nullable: false),
                    ConsultationHours = table.Column<byte>(type: "smallint", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syllabus_subject", x => new { x.SubjectId, x.SyllabusId });
                    table.ForeignKey(
                        name: "FK_syllabus_subject_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_syllabus_subject_syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "syllabus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accreditation_type_Code",
                table: "accreditation_type",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accreditation_type_Name",
                table: "accreditation_type",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachment_ExternalId",
                table: "attachment",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_department_ExternalId",
                table: "department",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_department_FacultyId",
                table: "department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_department_Name",
                table: "department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_faculty_Code",
                table: "faculty",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_faculty_ExternalId",
                table: "faculty",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_faculty_Name",
                table: "faculty",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flow_ExternalId",
                table: "flow",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_DepartmentId",
                table: "group",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_group_ExternalId",
                table: "group",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_FlowId",
                table: "group",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_specialization_Code",
                table: "specialization",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specialization_DepartmentId",
                table: "specialization",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_specialization_ExternalId",
                table: "specialization",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specialization_Name",
                table: "specialization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_GroupId",
                table: "student",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_student_SyllabusId",
                table: "student",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_student_UserId",
                table: "student",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_study_form_type_Code",
                table: "study_form_type",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_study_form_type_Name",
                table: "study_form_type",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_study_level_Code",
                table: "study_level",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_study_level_Name",
                table: "study_level",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_ExternalId",
                table: "subject",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_Name",
                table: "subject",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_AccreditationTypeId",
                table: "syllabus",
                column: "AccreditationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_SpecializationId",
                table: "syllabus",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_StudyFormTypeId",
                table: "syllabus",
                column: "StudyFormTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_StudyLevelId",
                table: "syllabus",
                column: "StudyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_subject_ExternalId",
                table: "syllabus_subject",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_subject_SyllabusId",
                table: "syllabus_subject",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_DepartmentId",
                table: "teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_UserId",
                table: "teacher",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teaching_assignment_GroupId",
                table: "teaching_assignment",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_teaching_assignment_TeacherId",
                table: "teaching_assignment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_AttachmentId",
                table: "topic",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_ExternalId",
                table: "topic",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_SubjectId",
                table: "topic",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentId",
                table: "topic_attachment",
                column: "AttachmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "syllabus_subject");

            migrationBuilder.DropTable(
                name: "teaching_assignment");

            migrationBuilder.DropTable(
                name: "topic_attachment");

            migrationBuilder.DropTable(
                name: "syllabus");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "accreditation_type");

            migrationBuilder.DropTable(
                name: "specialization");

            migrationBuilder.DropTable(
                name: "study_form_type");

            migrationBuilder.DropTable(
                name: "study_level");

            migrationBuilder.DropTable(
                name: "flow");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "faculty");
        }
    }
}
