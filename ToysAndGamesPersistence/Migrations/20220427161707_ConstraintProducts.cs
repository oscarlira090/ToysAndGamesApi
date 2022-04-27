using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToysAndGamesPersistence.Migrations
{
    public partial class ConstraintProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER Table dbo.Products ADD CONSTRAINT Chk_MinAndMax_Price CHECK (Price >= 1 AND Price <= 1000)");
            migrationBuilder.Sql(@"ALTER Table dbo.Products ADD CONSTRAINT Chk_MinAndMax_AgeRestriction CHECK (AgeRestriction >= 0 AND AgeRestriction <= 100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP CONSTRAINT Chk_MinAndMax_Price");
            migrationBuilder.Sql(@"DROP CONSTRAINT Chk_MinAndMax_AgeRestriction");
        }
    }
}
