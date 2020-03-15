using Microsoft.EntityFrameworkCore.Migrations;

namespace ContentNegotiationInCore.Migrations
{
    public partial class StudentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Students",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "City",
                table: "Students",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
