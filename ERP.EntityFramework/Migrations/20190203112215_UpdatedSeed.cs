using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.EntityFramework.Migrations
{
    public partial class UpdatedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "1d547518-3b58-4367-afae-bf107be1059c", new DateTime(2019, 2, 3, 15, 22, 14, 359, DateTimeKind.Local).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "82011347-6e45-491a-9252-a4810053eaa5", new DateTime(2019, 2, 3, 15, 22, 14, 359, DateTimeKind.Local).AddTicks(6398) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "56908c80-fd67-470d-a5ca-72d9ae93497f", new DateTime(2019, 2, 3, 15, 22, 14, 359, DateTimeKind.Local).AddTicks(6434) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1ce465a-6576-494f-ac02-2de5c3b5684a", "AQAAAAEAACcQAAAAEHYQoCaWSfqXibJ/vzMy/MRMsYCfalshByXsW/84YIOuaMXU97CHL5GxfMmonzUeTA==", "fc0e9268-a3a7-4f21-bd39-02d5b0827de3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "241300c3-11dd-4333-adbc-e7827f9e6e01", "AQAAAAEAACcQAAAAEKuaA73UFwrdvnemFB59LaSpRbQshw5nScMhnGfqWkZYg3qQWa8chrxjGmzJXISxBw==", "18c6e426-7794-44b0-82b6-63297d02b263" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52c6bcb0-dbf3-4cd6-8b1f-f27e9a417943", "AQAAAAEAACcQAAAAEMcbmZXsS76GEWtwSl5dj4Fafl0UeT2Gh252tDVeO+K6x7zszjdBC0V1URYsSN5jCA==", "b4c82d1c-1324-4dd3-a13e-63dcf844f47b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02ae0df1-6b5c-44e8-837a-f7fe0f067034", "AQAAAAEAACcQAAAAEKYwFk9j1qCFeaqr7emq7p8eY/FFqPyC8CKGs9nAt5x7ZGViYVR4wOh0KXfmjNMEsA==", "58832e4e-1d2c-49d3-a09c-7ec4651a1dca" });

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("20653d3a-ffee-45e8-a346-ca034e43a752"),
                column: "Code",
                value: "MG/SL");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("3d71bf60-ce6c-4c87-b271-6f0357c017fb"),
                column: "Code",
                value: "FW/DL");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("a35d3703-31eb-40a4-8473-17e4541ad3aa"),
                column: "Code",
                value: "PUF/SL");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("b9134bc6-8456-400e-8457-f3aa75cbeba4"),
                column: "Code",
                value: "DS/1.5L");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("ccc3c1a0-4807-4486-b611-c20711b65f66"),
                column: "Code",
                value: "FT/LS");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("ff9ba921-0b10-4e19-ba50-c54b48c6ef47"),
                column: "Code",
                value: "PF/SL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("20653d3a-ffee-45e8-a346-ca034e43a752"),
                column: "Code",
                value: "MG");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("3d71bf60-ce6c-4c87-b271-6f0357c017fb"),
                column: "Code",
                value: "FW");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("a35d3703-31eb-40a4-8473-17e4541ad3aa"),
                column: "Code",
                value: "PUF");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("b9134bc6-8456-400e-8457-f3aa75cbeba4"),
                column: "Code",
                value: "DS");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("ccc3c1a0-4807-4486-b611-c20711b65f66"),
                column: "Code",
                value: "FT");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "Id",
                keyValue: new Guid("ff9ba921-0b10-4e19-ba50-c54b48c6ef47"),
                column: "Code",
                value: "PF");
        }
    }
}
