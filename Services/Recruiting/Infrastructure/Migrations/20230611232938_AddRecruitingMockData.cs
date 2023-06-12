using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecruitingMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "LastName", "MiddleName", "ResumeURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 16, 17, 13, 14, 593, DateTimeKind.Unspecified).AddTicks(3333), "emilytaylor@gmail.com", "Emily", "Taylor", null, "https://example.com/resumes/emilytaylor" },
                    { 2, new DateTime(2023, 5, 16, 17, 14, 35, 960, DateTimeKind.Unspecified), "michaeljohnson@gmail.com", "Michael", "Johnson", null, "https://example.com/resumes/michaeljohnson" },
                    { 3, new DateTime(2023, 5, 17, 1, 41, 50, 743, DateTimeKind.Unspecified).AddTicks(3333), "john.smith@example.com", "John", "Smith", null, "resume_url_1" },
                    { 4, new DateTime(2023, 5, 18, 9, 25, 0, 123, DateTimeKind.Unspecified).AddTicks(4567), "sarah.williams@example.com", "Sarah", "Williams", null, "https://example.com/resumes/sarahwilliams" },
                    { 5, new DateTime(2023, 5, 19, 14, 30, 45, 987, DateTimeKind.Unspecified).AddTicks(6543), "david.wilson@example.com", "David", "Wilson", null, "resume_url_2" },
                    { 6, new DateTime(2023, 5, 20, 18, 45, 12, 345, DateTimeKind.Unspecified).AddTicks(6789), "emma.brown@example.com", "Emma", "Brown", null, "https://example.com/resumes/emmabrown" },
                    { 7, new DateTime(2023, 5, 31, 16, 55, 0, 0, DateTimeKind.Utc), "danielmiller@example.com", "Daniel", "Miller", null, "https://example.com/resumes/danielmiller.pdf" },
                    { 8, new DateTime(2023, 5, 31, 17, 10, 0, 0, DateTimeKind.Utc), "oliviaanderson@example.com", "Olivia", "Anderson", null, "https://example.com/resumes/oliviaanderson.pdf" },
                    { 9, new DateTime(2023, 5, 31, 19, 35, 0, 0, DateTimeKind.Utc), "sophiaclark@example.com", "Sophia", "Clark", null, "https://example.com/resumes/sophiaclark.pdf" },
                    { 10, new DateTime(2023, 5, 31, 21, 5, 0, 0, DateTimeKind.Utc), "avahill@example.com", "Ava", "Hill", null, "https://example.com/resumes/avahill.pdf" },
                    { 11, new DateTime(2023, 5, 31, 22, 20, 0, 0, DateTimeKind.Utc), "christophergonzalez@example.com", "Christopher", "Gonzalez", null, "https://example.com/resumes/christophergonzalez.pdf" }
                });

            migrationBuilder.InsertData(
                table: "JobStatusLookUps",
                columns: new[] { "Id", "JobStatusCode", "JobStatusDescription" },
                values: new object[,]
                {
                    { 1, "Open", "Job is Open" },
                    { 2, "Pending", "Job is Pending" },
                    { 3, "Closed", "Job is Closed" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CloseOn", "ClosedReason", "CreatedOn", "Description", "IsActive", "JobCode", "JobStatusLookUpId", "NumberOfPositions", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2023, 5, 10, 1, 53, 36, 833, DateTimeKind.Unspecified).AddTicks(5340), "Need to be good with C#", true, new Guid("9a8b615e-5ba5-4211-84a0-c8c4998549a1"), 1, 2, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), ".NET Developer" },
                    { 2, null, null, new DateTime(2023, 5, 10, 15, 25, 39, 32, DateTimeKind.Unspecified).AddTicks(1810), "Need to be good with Java", true, new Guid("f45e3dc6-7c56-4f6d-b74a-3d53c7f9dc60"), 1, 4, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java Developer" },
                    { 3, null, null, new DateTime(2023, 5, 14, 1, 53, 36, 833, DateTimeKind.Unspecified).AddTicks(5340), "Good with C#", true, new Guid("aebb8a82-734b-4b47-9475-64e127e1f4a0"), 1, 4, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Dev" },
                    { 4, null, null, new DateTime(2023, 5, 15, 16, 55, 18, 473, DateTimeKind.Unspecified).AddTicks(9500), "Looking for a skilled frontend developer with experience in HTML, CSS, and JavaScript.", true, new Guid("b2d06b8e-9e15-4d13-a22e-f07c5e3f52cc"), 1, 3, new DateTime(2023, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Frontend Developer" },
                    { 5, null, null, new DateTime(2023, 5, 30, 13, 45, 0, 0, DateTimeKind.Utc), "Develop and maintain software applications.", true, new Guid("a6b8a2f4-8eae-4a82-9e99-3a3fd4960011"), 1, 10, new DateTime(2023, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Software Developer" },
                    { 6, null, null, new DateTime(2023, 5, 28, 10, 30, 0, 0, DateTimeKind.Utc), "Promote and sell products to customers.", true, new Guid("03d19b10-579f-4b45-9461-8c7d1d06f092"), 1, 2, new DateTime(2023, 7, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Sales Representative" },
                    { 7, null, null, new DateTime(2023, 5, 25, 16, 20, 0, 0, DateTimeKind.Utc), "Analyze and interpret complex data sets.", true, new Guid("e9e8192a-84c5-4a8a-940e-2e9793817d4f"), 1, 5, new DateTime(2023, 6, 20, 9, 0, 0, 0, DateTimeKind.Utc), "Data Analyst" },
                    { 8, null, null, new DateTime(2023, 5, 23, 9, 15, 0, 0, DateTimeKind.Utc), "Create visually appealing designs for marketing materials.", true, new Guid("c0571f0b-0e47-4181-89f6-82e3ae6a86c1"), 1, 3, new DateTime(2023, 6, 25, 9, 0, 0, 0, DateTimeKind.Utc), "Graphic Designer" },
                    { 9, null, null, new DateTime(2023, 5, 19, 3, 28, 0, 0, DateTimeKind.Utc), "Develop and implement marketing strategies.", true, new Guid("f03e9879-6ab1-4e4d-9ff9-81a9a5c218b8"), 1, 2, new DateTime(2023, 7, 10, 9, 0, 0, 0, DateTimeKind.Utc), "Marketing Manager" },
                    { 10, null, null, new DateTime(2023, 5, 12, 13, 15, 0, 0, DateTimeKind.Utc), "Lead and oversee project planning and execution.", true, new Guid("7815d102-24d1-45fe-8b32-3e0e0d97e317"), 1, 8, new DateTime(2023, 7, 12, 9, 0, 0, 0, DateTimeKind.Utc), "Project Manager" },
                    { 1003, null, null, new DateTime(2023, 5, 14, 19, 25, 39, 32, DateTimeKind.Unspecified).AddTicks(1810), "Good with Azure", true, new Guid("d67e8644-8a29-40a1-9d6f-1eae6cc7b29a"), 1, 5, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azure Developer" }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "CandidateId", "JobId", "RejectedOn", "RejectedReason", "SelectedForInterview", "SubmittedOn" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null, new DateTime(2023, 5, 20, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, 2, null, null, null, new DateTime(2023, 5, 21, 10, 30, 0, 0, DateTimeKind.Utc) },
                    { 3, 3, 3, null, null, null, new DateTime(2023, 5, 22, 14, 15, 0, 0, DateTimeKind.Utc) },
                    { 4, 4, 1003, null, null, null, new DateTime(2023, 5, 23, 16, 45, 0, 0, DateTimeKind.Utc) },
                    { 5, 5, 5, null, null, null, new DateTime(2023, 5, 24, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 6, 6, null, null, null, new DateTime(2023, 5, 25, 9, 30, 0, 0, DateTimeKind.Utc) },
                    { 7, 7, 7, null, null, null, new DateTime(2023, 5, 26, 13, 20, 0, 0, DateTimeKind.Utc) },
                    { 8, 8, 8, null, null, null, new DateTime(2023, 5, 27, 10, 10, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "JobStatusLookUps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobStatusLookUps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "JobStatusLookUps",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
