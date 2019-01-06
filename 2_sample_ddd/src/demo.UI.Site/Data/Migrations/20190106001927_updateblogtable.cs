using Microsoft.EntityFrameworkCore.Migrations;

namespace demo.UI.Site.Data.Migrations
{
    public partial class updateblogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);
        }
    }
}
