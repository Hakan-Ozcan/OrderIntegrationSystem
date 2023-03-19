using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initNewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialInformations",
                columns: table => new
                {
                    MalzemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeKodu = table.Column<int>(type: "int", nullable: false),
                    MalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialInformations", x => x.MalzemeID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDatas",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriSiparisNo = table.Column<int>(type: "int", nullable: false),
                    CikisAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarisAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    MiktarBirim = table.Column<int>(type: "int", nullable: false),
                    Agirlik = table.Column<int>(type: "int", nullable: false),
                    AgirlikBirim = table.Column<int>(type: "int", nullable: false),
                    MalzemeKodu = table.Column<int>(type: "int", nullable: false),
                    MalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Not = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDatas", x => x.SiparisID);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuss",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisAlindi = table.Column<bool>(type: "bit", nullable: false),
                    YolaCikti = table.Column<bool>(type: "bit", nullable: false),
                    DagitimMerkezinde = table.Column<bool>(type: "bit", nullable: false),
                    DagitimaCikti = table.Column<bool>(type: "bit", nullable: false),
                    TeslimEdildi = table.Column<bool>(type: "bit", nullable: false),
                    TeslimEdilemedi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuss", x => x.StatusID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialInformations");

            migrationBuilder.DropTable(
                name: "OrderDatas");

            migrationBuilder.DropTable(
                name: "OrderStatuss");
        }
    }
}
