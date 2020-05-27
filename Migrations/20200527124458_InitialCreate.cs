using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace EFCoreQueriesEspaciales.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurantes",
                columns: new[] { "Id", "Ciudad", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "Santo Domingo", "Agora", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)") },
                    { 2, "Santo Domingo", "Sambil", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9118804 18.4826214)") },
                    { 3, "Santo Domingo", "Adrian Tropical", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9334673 18.4718075)") },
                    { 4, "Ciudad de México", "Restaurante El Cardenal", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-99.1353659 19.4336164)") },
                    { 5, "London", "Tower Bridge", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-0.1453961 51.5055424)") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
