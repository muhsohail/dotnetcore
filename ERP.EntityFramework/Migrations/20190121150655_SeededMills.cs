using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.EntityFramework.Migrations
{
    public partial class SeededMills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "5a64c741-2f18-4b34-b83e-5e07815708a6", new DateTime(2019, 1, 21, 19, 6, 54, 847, DateTimeKind.Local).AddTicks(9976) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "e9ea755e-6dfc-4958-92cf-ec0f00654668", new DateTime(2019, 1, 21, 19, 6, 54, 848, DateTimeKind.Local).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "5c4869e1-554b-488f-91e3-5f157d4fe0ac", new DateTime(2019, 1, 21, 19, 6, 54, 848, DateTimeKind.Local).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90970f5e-5557-4dd4-b6ac-ad0775644da3", "AQAAAAEAACcQAAAAENUj6GlvdM5fPVy6iDXleoDg7iA0Ahk1pBJ8+ahUL8OV0cM0YsYoYPFuQ9rOG66Wjw==", "beb5d688-1c16-4c68-a651-927958b59cdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00336c74-de5d-467e-ba7f-2c2de2704bfb", "AQAAAAEAACcQAAAAEEgi6zdPKxqzj37EUdrmCgIR+zpJ54rvBpKAb4OrEZoCw28Zm8Nbhor6wDuwVvxpbw==", "db9557e5-1352-4124-80c2-59470ad85ea5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ff0e8b8-29ac-44e9-b729-7842b4cb4689", "AQAAAAEAACcQAAAAEJhOPUOxM0OHwxzL/dcOj7q9NtQvVYzqam5YNaQGEz5jK/CegBe5hmqLCgRTp+7NeA==", "b8b734b3-7325-4e44-8807-bb3f63b442a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fff2204-425d-42a8-ac6a-b536e9d260f2", "AQAAAAEAACcQAAAAELRtS3QeIXYtV+ZZvVe0oGbbJPmnVB+v2xs01fWlOgvaVKgL9tMdEFwFdfWupqKmdw==", "40631d61-882d-4817-9272-e34e0ccaaa05" });

            migrationBuilder.InsertData(
                table: "Mills",
                columns: new[] { "Id", "CPMId", "CityId", "Code", "IsActive", "MDId", "MangerId", "MechanicalId", "Name" },
                values: new object[,]
                {
                    { new Guid("69ae3e06-2407-4074-b4ab-450200bb3470"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), new Guid("93f89299-cfc9-4998-9ddd-09c5583dc8c2"), "07-kar-ahm", true, new Guid("bbc84742-4bbf-44d6-bb17-911b82dbfc37"), new Guid("e2c71c6b-f141-415b-9a5d-ccb7727aeaa4"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), "Ahmad Paper Mill" },
                    { new Guid("c4c9feb4-3478-4dfc-ba01-b629c74a76e9"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), new Guid("93f89299-cfc9-4998-9ddd-09c5583dc8c2"), "07-kar-ash", true, new Guid("bbc84742-4bbf-44d6-bb17-911b82dbfc37"), new Guid("e2c71c6b-f141-415b-9a5d-ccb7727aeaa4"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), "Ashraf Paper" },
                    { new Guid("d862a91a-a3aa-4767-ba1a-92a77606f2b9"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), new Guid("93f89299-cfc9-4998-9ddd-09c5583dc8c2"), "07-kar-azi", true, new Guid("bbc84742-4bbf-44d6-bb17-911b82dbfc37"), new Guid("e2c71c6b-f141-415b-9a5d-ccb7727aeaa4"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), "Aziz Paper" },
                    { new Guid("e6933b4b-8ece-4791-b5f8-bdf98007cf59"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), new Guid("93f89299-cfc9-4998-9ddd-09c5583dc8c2"), "07-kar-asl", true, new Guid("bbc84742-4bbf-44d6-bb17-911b82dbfc37"), new Guid("e2c71c6b-f141-415b-9a5d-ccb7727aeaa4"), new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), "ASL" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mills",
                keyColumn: "Id",
                keyValue: new Guid("69ae3e06-2407-4074-b4ab-450200bb3470"));

            migrationBuilder.DeleteData(
                table: "Mills",
                keyColumn: "Id",
                keyValue: new Guid("c4c9feb4-3478-4dfc-ba01-b629c74a76e9"));

            migrationBuilder.DeleteData(
                table: "Mills",
                keyColumn: "Id",
                keyValue: new Guid("d862a91a-a3aa-4767-ba1a-92a77606f2b9"));

            migrationBuilder.DeleteData(
                table: "Mills",
                keyColumn: "Id",
                keyValue: new Guid("e6933b4b-8ece-4791-b5f8-bdf98007cf59"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "4e329bb4-29c3-46f9-be0c-e56dc0c15820", new DateTime(2019, 1, 21, 18, 49, 0, 105, DateTimeKind.Local).AddTicks(142) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "dd7c820a-df1f-45cb-9453-29e2df925a22", new DateTime(2019, 1, 21, 18, 49, 0, 105, DateTimeKind.Local).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "6d97a0e9-fd0a-4966-acb9-5b429b9ca278", new DateTime(2019, 1, 21, 18, 49, 0, 105, DateTimeKind.Local).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4f1a97-c295-4ffb-8490-60c3ee0622bb", "AQAAAAEAACcQAAAAEESpa0fvEvSvQJS7uClpZYMUd2aXYRHajdOymHUlYBn5fhJ1svH7pZQ6IOEFKf/8bQ==", "e68300a5-8659-4d7f-a609-9ea84d0caa4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d17c108-59c6-4621-bd68-fbb05386b945", "AQAAAAEAACcQAAAAEKUFq1dDASVSWp4l6Al4WuinEqZktTWjWRCMMeHawY7qSCIs+bnEbF98ooOdnAPBCw==", "554da14c-ad1f-4fa8-96cc-517b0053a55d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24651ad4-5078-4ae4-a938-518e13b50e50", "AQAAAAEAACcQAAAAEP6TO5zPV8grkizbeZAVRoZ74lweHS/BlaCHM5Y2+6Nkg4QfxDbeFfxjFqx5L4eA5w==", "62bf385d-b168-4970-8cbb-5a3ea0819de9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "097a5747-7167-440c-a3c4-ee18bfcb553e", "AQAAAAEAACcQAAAAEBaqe7NFzJ0cKcfxq4lcvH7/NB/AYsVSNdzfHLUM3ridZjOw+JeTBBddH/yJdfrQHw==", "632b13af-7fbc-46db-a5a0-1723030dfa53" });
        }
    }
}
