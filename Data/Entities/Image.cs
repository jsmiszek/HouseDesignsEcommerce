using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HouseDesignsEcommerce.Data.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public ImageCategory ImageCategory { get; set; }
        public HouseDesign HouseDesign { get; set; }
        public int ImageCategoryId { get; set; }
        public int HouseDesignId { get; set; }

}
}
