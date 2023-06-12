using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOnBoardingMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeStatusLookUps",
                columns: new[] { "Id", "EmployeeStatusCode", "EmployeeStatusDescription" },
                values: new object[,]
                {
                    { 1, "Active", "The employee is currently employed" },
                    { 2, "On Leave", "The employee is on an approved leave of absence" },
                    { 3, "Terminated", "The employee's employment has been terminated" },
                    { 4, "Onboarding", "The employee is in the process of being onboarded" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Email", "EmployeeIdentityId", "EmployeeStatusId", "EndDate", "FirstName", "HireDate", "LastName", "MiddleName", "SSN" },
                values: new object[,]
                {
                    { 1, "123 Main St, City 1, Country 1", "aries.mu@GoldSaints.com", new Guid("49d65189-9d93-4ba0-9a2e-6cd349a86c6a"), 1, null, "Aries", null, "Mu", null, "123-45-6789" },
                    { 2, "456 Oak St, City 2, Country 2", "Taurus.Aldebaran@GoldSaints.com", new Guid("14467328-f534-4ad3-9eb7-614d33b2814a"), 1, null, "Taurus", null, "Aldebaran", null, "234-56-7890" },
                    { 3, "789 Elm St, City 3, Country 3", "Gemini.Saga@GoldSaints.com", new Guid("cfa82a5b-2e3c-42b9-ade0-4abda5914de6"), 1, null, "Gemini", null, "Saga", null, "345-67-8901" },
                    { 4, "234 Maple St, City 4, Country 4", "Cancer.DeathMask@GoldSaints.com", new Guid("0009ced2-db4c-4e05-9459-e375bd2b06ff"), 1, null, "Cancer", null, "DeathMask", null, "456-78-9012" },
                    { 5, "567 Pine St, City 5, Country 5", "Leo.Aiolia@GoldSaints.com", new Guid("8c9019dc-ea34-4b05-871a-bcc3ce01633f"), 1, null, "Leo", null, "Aiolia", null, "567-89-0123" },
                    { 6, "890 Cherry St, City 6, Country 6", "Virgo.Shaka@GoldSaints.com", new Guid("2035b55f-2d17-4b86-b729-906a3113f4c3"), 1, null, "Virgo", null, "Shaka", null, "678-90-1234" },
                    { 7, "987 Walnut St, City 7, Country 7", "Libra.Dohko@GoldSaints.com", new Guid("d0b89c08-2bae-40af-9b50-f906cd7ddbdc"), 1, null, "Libra", null, "Dohko", null, "789-01-2345" },
                    { 8, "876 Cedar St, City 8, Country 8", "Scorpio.Milo@GoldSaints.com", new Guid("81bc38d5-1bb1-4c61-bd9f-b074fcf50e74"), 1, null, "Scorpio", null, "Milo", null, "890-12-3456" },
                    { 9, "765 Birch St, City 9, Country 9", "Sagittarius.Aiolos@GoldSaints.com", new Guid("e6ba17d4-5712-418d-8e49-fe41ae74b043"), 1, null, "Sagittarius", null, "Aiolos", null, "901-23-4567" },
                    { 10, "654 Willow St, City 10, Country 10", "Capricorn.Shura@GoldSaints.com", new Guid("4200a89b-2aad-4b94-bb65-d131fe5b4000"), 1, null, "Capricorn", null, "Shura", null, "012-34-5678" },
                    { 11, "543 Ash St, City 11, Country 11", "Aquarius.Camus@GoldSaints.com", new Guid("1e0ca156-a75f-48aa-8262-82fc1461461c"), 1, null, "Aquarius", null, "Camus", null, "987-65-4321" },
                    { 12, "432 Cypress St, City 12, Country 12", "Pisces.Aphrodite@GoldSaints.com", new Guid("2f793398-4c0c-4469-8002-a5905acd0136"), 1, null, "Pisces", null, "Aphrodite", null, "876-54-3210" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeStatusLookUps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeStatusLookUps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeStatusLookUps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EmployeeStatusLookUps",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
