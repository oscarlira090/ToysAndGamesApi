using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToysAndGamesPersistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            //Add Constrainsts
            migrationBuilder.Sql(@"ALTER Table dbo.Products ADD CONSTRAINT Chk_MinAndMax_Price CHECK (Price >= 1 AND Price <= 1000)");
            migrationBuilder.Sql(@"ALTER Table dbo.Products ADD CONSTRAINT Chk_MinAndMax_AgeRestriction CHECK (AgeRestriction >= 0 AND AgeRestriction <= 100)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 1, 4, "Marvel", "Iron Man Mega Power", "Iron Man", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 2, 4, "DC", "BatMan Luxury BatCar", "BatMan", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 3, 4, "Marvel", "all caracters", "Kit Avengers", 500m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Drop Constrainsts
            migrationBuilder.Sql(@"DROP CONSTRAINT Chk_MinAndMax_Price");
            migrationBuilder.Sql(@"DROP CONSTRAINT Chk_MinAndMax_AgeRestriction");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
