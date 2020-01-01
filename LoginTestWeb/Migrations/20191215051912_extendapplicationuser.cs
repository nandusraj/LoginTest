using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginTestWeb.Migrations
{
    public partial class extendapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegisterUser",
                columns: table => new
                {
                    userid = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    contactno = table.Column<string>(maxLength: 10, nullable: false),
                    password = table.Column<string>(nullable: false),
                    confirmpassword = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterUser", x => x.userid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterUser");

            migrationBuilder.DropColumn(
                name: "city",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");
        }
    }
}
