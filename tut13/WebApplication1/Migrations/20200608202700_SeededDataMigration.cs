using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class SeededDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Confectionery",
                columns: new[] { "IdConfectionery", "Name", "PricePerItem", "Type" },
                values: new object[,]
                {
                    { 1, "ponchik", 1.2, "sladost" },
                    { 2, "tortik", 2.2000000000000002, "sladkaya sladost" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "IdCustomer", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Jennifer", "Day" },
                    { 2, "Jennifer2", "Day2" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IdEmployee", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Alex", "Way" },
                    { 2, "Alex2", "Way2" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdCustomer", "IdEmployee", "Notes" },
                values: new object[] { 1, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "vkusno" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdCustomer", "IdEmployee", "Notes" },
                values: new object[] { 2, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "nu ne ochen vkusno" });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 1, 1, "normik", 3 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 2, 2, "nu pochti normik", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "IdCustomer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "IdCustomer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 2);
        }
    }
}
