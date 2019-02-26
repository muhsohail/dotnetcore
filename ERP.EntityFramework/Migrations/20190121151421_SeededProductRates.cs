using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.EntityFramework.Migrations
{
    public partial class SeededProductRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "bd3fdd47-6116-43d3-b0cb-ac9a25eb4ebf", new DateTime(2019, 1, 21, 19, 14, 20, 595, DateTimeKind.Local).AddTicks(4051) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "7f1a149b-17ae-4681-b1c3-b7f8c80f641c", new DateTime(2019, 1, 21, 19, 14, 20, 595, DateTimeKind.Local).AddTicks(4836) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "66d12e07-b089-481d-b851-9abec83fd954", new DateTime(2019, 1, 21, 19, 14, 20, 595, DateTimeKind.Local).AddTicks(4852) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d1e2901-2881-4a85-9ffe-9ce6fc5ec454", "AQAAAAEAACcQAAAAEKZvkX01ySJw4LbkLMtHy1OspgqYF4s1pampbCfqoGIaxrAPqsEJ0Fs93RkevHUI8w==", "cd5a1cba-6e01-42ba-b27d-b2ba8ee2d1c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b24c85b4-c326-49b9-93fd-156bc3341742", "AQAAAAEAACcQAAAAEKPLjHYyOeD4QruHIWDiHRkSUXjEpniu1wMnlqNmhcye3JBi49d4tqQmyayrS123xA==", "f88e012a-71ad-4949-adf4-124b6b63e5f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b3c7f4e-5986-4255-9657-c1d16aef6bcd", "AQAAAAEAACcQAAAAEG2yoSRUzkuL2eBg/ZkYBJhUkyTiT0t4dVNZm24vNlGx6KZG3/zqgD4k0Y8zJ5Xkfg==", "68e07a4b-1a7a-48ab-8d21-08318193745d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bc0386a-7be9-4582-8338-b3136ea76103", "AQAAAAEAACcQAAAAEBDPqP6R65ptoHqeIYRTHih2YRaFb0zc8X+V5rEbt9j3FLe/1vHRuOQwKgclsQPgnQ==", "4f35db67-5772-4371-93f7-3e9be0930ab6" });

            migrationBuilder.InsertData(
                table: "ProductRate",
                columns: new[] { "Id", "AskingRate", "FabricId", "IsActive", "MaximumRate", "MinimumRate" },
                values: new object[,]
                {
                    { new Guid("43553771-eebd-458f-91bb-efc0f6f5ef3b"), 1111.0, new Guid("3d71bf60-ce6c-4c87-b271-6f0357c017fb"), true, 3333.0, 2222.0 },
                    { new Guid("8d9b8c04-756e-485d-8901-f6ee1dc98072"), 4444.0, new Guid("ccc3c1a0-4807-4486-b611-c20711b65f66"), true, 6666.0, 5555.0 },
                    { new Guid("76b58ec7-5e0d-4868-8c45-c61f4664cb14"), 7777.0, new Guid("ff9ba921-0b10-4e19-ba50-c54b48c6ef47"), true, 9999.0, 8888.0 },
                    { new Guid("3c498c68-ff89-4b83-994c-ca5e36faf9f4"), 0.0, new Guid("20653d3a-ffee-45e8-a346-ca034e43a752"), true, 3344.0, 1122.0 },
                    { new Guid("2c14dd42-e9fd-4f38-a7f5-d9b90e090567"), 4455.0, new Guid("b9134bc6-8456-400e-8457-f3aa75cbeba4"), true, 8899.0, 6677.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductRate",
                keyColumn: "Id",
                keyValue: new Guid("2c14dd42-e9fd-4f38-a7f5-d9b90e090567"));

            migrationBuilder.DeleteData(
                table: "ProductRate",
                keyColumn: "Id",
                keyValue: new Guid("3c498c68-ff89-4b83-994c-ca5e36faf9f4"));

            migrationBuilder.DeleteData(
                table: "ProductRate",
                keyColumn: "Id",
                keyValue: new Guid("43553771-eebd-458f-91bb-efc0f6f5ef3b"));

            migrationBuilder.DeleteData(
                table: "ProductRate",
                keyColumn: "Id",
                keyValue: new Guid("76b58ec7-5e0d-4868-8c45-c61f4664cb14"));

            migrationBuilder.DeleteData(
                table: "ProductRate",
                keyColumn: "Id",
                keyValue: new Guid("8d9b8c04-756e-485d-8901-f6ee1dc98072"));

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
        }
    }
}
