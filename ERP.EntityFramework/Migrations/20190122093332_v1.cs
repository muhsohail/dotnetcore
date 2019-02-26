using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.EntityFramework.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyPhone",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "cc68047f-ebc3-499c-a906-25ade4d35a72", new DateTime(2019, 1, 22, 13, 33, 31, 353, DateTimeKind.Local).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "249c2c82-bd91-480b-b460-9b49cee9c2e7", new DateTime(2019, 1, 22, 13, 33, 31, 353, DateTimeKind.Local).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "41ae10ce-8e83-49ab-8283-cbf0080be4c0", new DateTime(2019, 1, 22, 13, 33, 31, 353, DateTimeKind.Local).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a286748-d827-4f74-b958-1e98527fdf46", "AQAAAAEAACcQAAAAEP/Olrz9vT/WdxIzvZ6b0Tbp/K3vgM4xyP8bxSV8vZO5LK16E5O4JTqTQVDuYRAX5A==", "978bd87d-1f86-46a7-9bd6-aa8d30d52fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6ca8dc2-2ed0-400a-9da3-8ac5d19be788", "AQAAAAEAACcQAAAAEEgcRel1D7iX0JNPjBvTYwyEqK78llgfPQd2geIYuF7f4uU8cEmxLVp1Rni/8GSuxQ==", "f7e8a2d4-3307-493c-8145-f198a76cd580" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c400dc6-6208-4c07-a554-9d3c68158ae2", "AQAAAAEAACcQAAAAEBlTa3rPWICBcAH8wemhHtTKpQGgdD2oOxDbKGn5x9DT/8wumyWqHNYhANnNVQudNg==", "44e23308-a725-416c-91cc-b3cc1eb492c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b28b3b0-3fbe-4795-baca-268b94b996ae", "AQAAAAEAACcQAAAAEC0wT/Wi4hl08JxlKKURu+J40mF9IsYeeEHCqY57ze+edK60AoN9MA8g9gRzKAmI/w==", "f89f53db-c9f6-4c48-a2ff-b1026915476e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhone",
                table: "Person",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"),
                column: "EmergencyPhone",
                value: "444444444");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("bbc84742-4bbf-44d6-bb17-911b82dbfc37"),
                column: "EmergencyPhone",
                value: "22222222");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("d2ee36c6-55a6-41e2-b773-4c3a0c18a915"),
                column: "EmergencyPhone",
                value: "1111111");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("e2c71c6b-f141-415b-9a5d-ccb7727aeaa4"),
                column: "EmergencyPhone",
                value: "333333333");
        }
    }
}
