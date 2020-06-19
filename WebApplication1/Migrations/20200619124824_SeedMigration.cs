using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BreedType",
                columns: new[] { "IdBreedType", "Description", "Name" },
                values: new object[] { 1, "SUPER NICE", "Rassel Terrier" });

            migrationBuilder.InsertData(
                table: "BreedType",
                columns: new[] { "IdBreedType", "Description", "Name" },
                values: new object[] { 2, "fluffy!!!", "Corgi" });

            migrationBuilder.InsertData(
                table: "Volunteer",
                columns: new[] { "IdVolunteer", "Address", "Email", "IdSupervisor", "Name", "Phone", "StartingDate", "Surname" },
                values: new object[] { 1, "Warsaw, Dobra 9/12", "alexilovepets@gmail.com", null, "Alex", "+48999999999", new DateTime(2013, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koakoka" });

            migrationBuilder.InsertData(
                table: "Pet",
                columns: new[] { "IdPet", "ApproximateDateOfBirth", "DateAdopted", "DateRegistered", "IdBreedType", "IsMale", "Name" },
                values: new object[] { 1, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Mickey" });

            migrationBuilder.InsertData(
                table: "Pet",
                columns: new[] { "IdPet", "ApproximateDateOfBirth", "DateAdopted", "DateRegistered", "IdBreedType", "IsMale", "Name" },
                values: new object[] { 2, new DateTime(2019, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Ash" });

            migrationBuilder.InsertData(
                table: "Volunteer",
                columns: new[] { "IdVolunteer", "Address", "Email", "IdSupervisor", "Name", "Phone", "StartingDate", "Surname" },
                values: new object[] { 2, "Warsaw, Konarskiego 11/112", "johnPkskkd@gmail.com", 1, "John", "+48991111113", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plskksoakoka" });

            migrationBuilder.InsertData(
                table: "Volunteer_Pet",
                columns: new[] { "IdVolunteer", "IdPet", "DateAccepted" },
                values: new object[] { 1, 1, new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Volunteer_Pet",
                columns: new[] { "IdVolunteer", "IdPet", "DateAccepted" },
                values: new object[] { 2, 2, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Volunteer_Pet",
                keyColumns: new[] { "IdVolunteer", "IdPet" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Volunteer_Pet",
                keyColumns: new[] { "IdVolunteer", "IdPet" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "IdPet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "IdPet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteer",
                keyColumn: "IdVolunteer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BreedType",
                keyColumn: "IdBreedType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BreedType",
                keyColumn: "IdBreedType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteer",
                keyColumn: "IdVolunteer",
                keyValue: 1);
        }
    }
}
