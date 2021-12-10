using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseDesignsEcommerce.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Domy parterowe" });

            migrationBuilder.InsertData(
                table: "HouseDesigns",
                columns: new[] { "HouseDesignId", "MinPlotDimensionLength", "MinPlotDimensionWidth", "NumberOfBathrooms", "NumberOfGaragePositions", "NumberOfRooms", "Price", "ProjectName", "RoofAngle", "UseableArea" },
                values: new object[] { 1, 28.699999999999999, 24.300000000000001, 2, 2, 5, 2499.0, "Dom w przebisniegach", 30.0, 196.02000000000001 });

            migrationBuilder.InsertData(
                table: "ImageCategories",
                columns: new[] { "ImageCategoryId", "ImageCategoryName" },
                values: new object[] { 1, "Widok zewnatrz" });

            migrationBuilder.InsertData(
                table: "HouseDesignCategory",
                columns: new[] { "HouseDesignCategoryId", "CategoryId", "HouseDesignId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "HouseDesignId", "ImageCategoryId", "ImagePath" },
                values: new object[] { 1, 1, 1, "HouseDesignEcommerce/Images/1.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HouseDesignCategory",
                keyColumn: "HouseDesignCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HouseDesigns",
                keyColumn: "HouseDesignId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImageCategories",
                keyColumn: "ImageCategoryId",
                keyValue: 1);
        }
    }
}
