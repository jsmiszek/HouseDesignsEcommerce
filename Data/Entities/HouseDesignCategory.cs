namespace HouseDesignsEcommerce.Data.Entities
{
    public class HouseDesignCategory
    {
        public int HouseDesignCategoryId { get; set; }
        public HouseDesign HouseDesign { get; set; }
        public Category Category { get; set; }
        public int HouseDesignId { get; set; }
        public int CategoryId { get; set; }
    }
}
