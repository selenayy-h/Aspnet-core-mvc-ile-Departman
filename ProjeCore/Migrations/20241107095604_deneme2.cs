using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeCore.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kullanıcı",
                table: "Admins",
                newName: "Kullanici");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kullanici",
                table: "Admins",
                newName: "Kullanıcı");
        }
    }
}
