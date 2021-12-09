using HouseDesignsEcommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseDesignsEcommerce.Data
{
    public static class ApplicatioanDbSeeder
    {

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(new Category() { CategoryId = 1, CategoryName = "Domy parterowe" });
            builder.Entity<HouseDesign>().HasData(new HouseDesign()
            {
                HouseDesignId = 1,
                ProjectName = "Dom w przebisniegach",
                UseableArea = 196.02,
                MinPlotDimensionWidth = 24.3,
                MinPlotDimensionLength = 28.7,
                RoofAngle = 30,
                Price = 2499,
                NumberOfRooms = 5,
                NumberOfBathrooms = 2,
                NumberOfGaragePositions = 2
            });

            builder.Entity<HouseDesignCategory>().HasData(new HouseDesignCategory() { HouseDesignCategoryId = 1, HouseDesignId = 1, CategoryId = 1 });
            builder.Entity<ImageCategory>().HasData(new ImageCategory() { ImageCategoryId = 1, ImageCategoryName = "Widok zewnatrz" });
            builder.Entity<Image>().HasData(new Image()
            {
                ImageId = 1,
                ImagePath = "HouseDesignEcommerce/Images/1.jpg",
                ImageCategoryId = 1,
                HouseDesignId = 1
            });
        }
    }
}
