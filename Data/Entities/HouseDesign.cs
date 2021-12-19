namespace HouseDesignsEcommerce.Data.Entities
{
    public class HouseDesign
    {
        public int HouseDesignId { get; set; }
        public string ProjectName { get; set; }
        public double UseableArea { get; set; }
        public double MinPlotDimensionWidth { get; set; }
        public double MinPlotDimensionLength { get; set; }
        public double RoofAngle { get; set; }
        public double Price { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfGaragePositions { get; set; }
        // public ICollection<Category> Category { get; set; }

    }
}
