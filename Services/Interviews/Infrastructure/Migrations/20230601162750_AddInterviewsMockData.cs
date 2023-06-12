using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInterviewsMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InterviewTypeLookUps",
                columns: new[] { "Id", "InterviewTypeCode", "InterviewTypeDescription" },
                values: new object[,]
                {
                    { 1, "P", "Phone Screen" },
                    { 2, "T", "Technical Interview" },
                    { 3, "B", "Behavioral Interview" },
                    { 4, "C", "Case Interview" },
                    { 5, "S", "Stress Interview" },
                    { 6, "O", "On-site Interview" }
                });

            migrationBuilder.InsertData(
                table: "Interviewers",
                columns: new[] { "Id", "Email", "EmployeeIdentityId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "aries.mu@GoldSaints.com", "49d65189-9d93-4ba0-9a2e-6cd349a86c6a", "Aries", "Mu" },
                    { 2, "Taurus.Aldebaran@GoldSaints.com", "14467328-f534-4ad3-9eb7-614d33b2814a", "Taurus", "Aldebaran" },
                    { 3, "Gemini.Saga@GoldSaints.com", "cfa82a5b-2e3c-42b9-ade0-4abda5914de6", "Gemini", "Saga" },
                    { 4, "Cancer.DeathMask@GoldSaints.com", "0009ced2-db4c-4e05-9459-e375bd2b06ff", "Cancer", "DeathMask" },
                    { 5, "Leo.Aiolia@GoldSaints.com", "8c9019dc-ea34-4b05-871a-bcc3ce01633f", "Leo", "Aiolia" },
                    { 6, "Virgo.Shaka@GoldSaints.com", "2035b55f-2d17-4b86-b729-906a3113f4c3", "Virgo", "Shaka" },
                    { 7, "Libra.Dohko@GoldSaints.com", "d0b89c08-2bae-40af-9b50-f906cd7ddbdc", "Libra", "Dohko" },
                    { 8, "Scorpio.Milo@GoldSaints.com", "81bc38d5-1bb1-4c61-bd9f-b074fcf50e74", "Scorpio", "Milo" },
                    { 9, "Sagittarius.Aiolos@GoldSaints.com", "e6ba17d4-5712-418d-8e49-fe41ae74b043", "Sagittarius", "Aiolos" },
                    { 10, "Capricorn.Shura@GoldSaints.com", "4200a89b-2aad-4b94-bb65-d131fe5b4000", "Capricorn", "Shura" },
                    { 11, "Aquarius.Camus@GoldSaints.com", "1e0ca156-a75f-48aa-8262-82fc1461461c", "Aquarius", "Camus" },
                    { 12, "Pisces.Aphrodite@GoldSaints.com", "2f793398-4c0c-4469-8002-a5905acd0136", "Pisces", "Aphrodite" }
                });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "Id", "BeginTime", "CandidateEmail", "CandidateFirstName", "CandidateIdentityId", "CandidateLastName", "EndTime", "Feedback", "InterviewTypeId", "InterviewerId", "Passed", "Rating", "SubmissionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), "emilytaylor@gmail.com", "Emily", new Guid("00000000-0000-0000-0000-000000000001"), "Taylor", new DateTime(2023, 5, 16, 9, 30, 0, 0, DateTimeKind.Unspecified), "Good communication skills", 1, 1, true, 4, 1 },
                    { 2, new DateTime(2023, 5, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "michaeljohnson@gmail.com", "Michael", new Guid("00000000-0000-0000-0000-000000000002"), "Johnson", new DateTime(2023, 5, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Strong technical skills", 2, 2, true, 5, 2 },
                    { 3, new DateTime(2023, 5, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), "john.smith@example.com", "John", new Guid("00000000-0000-0000-0000-000000000003"), "Smith", new DateTime(2023, 5, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), "Struggled to articulate their thoughts coherently", 3, 3, false, 2, 3 },
                    { 4, new DateTime(2023, 5, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), "sarah.williams@example.com", "Sarah", new Guid("00000000-0000-0000-0000-000000000004"), "Williams", new DateTime(2023, 5, 19, 9, 30, 0, 0, DateTimeKind.Unspecified), null, 4, 4, null, null, 4 },
                    { 5, new DateTime(2023, 5, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "david.wilson@example.com", "David", new Guid("00000000-0000-0000-0000-000000000005"), "Wilson", new DateTime(2023, 5, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 5, null, null, 5 },
                    { 6, new DateTime(2023, 5, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), "emma.brown@example.com", "Emma", new Guid("00000000-0000-0000-0000-000000000006"), "Brown", new DateTime(2023, 5, 21, 19, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 6, null, null, 6 },
                    { 7, new DateTime(2023, 5, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "danielmiller@example.com", "Daniel", new Guid("00000000-0000-0000-0000-000000000007"), "Miller", new DateTime(2023, 5, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), null, 1, 7, null, null, 7 },
                    { 8, new DateTime(2023, 5, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), "oliviaanderson@example.com", "Olivia", new Guid("00000000-0000-0000-0000-000000000008"), "Anderson", new DateTime(2023, 5, 31, 13, 30, 0, 0, DateTimeKind.Unspecified), null, 2, 8, null, null, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InterviewTypeLookUps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InterviewTypeLookUps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InterviewTypeLookUps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InterviewTypeLookUps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InterviewTypeLookUps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InterviewTypeLookUps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Interviewers",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
