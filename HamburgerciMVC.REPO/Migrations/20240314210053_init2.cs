using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerciMVC.REPO.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İçecekler",
                columns: table => new
                {
                    IcecekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İçecekAdı = table.Column<string>(name: "İçecek Adı", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    İçecekFiyatı = table.Column<decimal>(type: "decimal(38,17)", maxLength: 50, nullable: false),
                    SiparisBoyutu = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İçecekler", x => x.IcecekId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İçecekler");
        }
    }
}
