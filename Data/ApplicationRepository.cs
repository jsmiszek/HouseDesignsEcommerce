using HouseDesignsEcommerce.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseDesignsEcommerce.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ILogger<ApplicationRepository> _logger;

        public ApplicationDbContext _context { get; }
        public ApplicationRepository(ApplicationDbContext context, ILogger<ApplicationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<HouseDesign> GetAllHouseDesigns()
        {
            _logger.LogInformation("Get AllHouseDesigns was called");

            return _context.HouseDesigns
                    .OrderBy(h => h.HouseDesignId)
                    .ToList();
        }

        public HouseDesign GetHouseDesignById(int id)
        {
            return _context.HouseDesigns
                    .Where(h => h.HouseDesignId == id)
                    .FirstOrDefault();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByProjectName(string projectName)
        {
            return _context.HouseDesigns
                .Where(h => h.ProjectName == projectName)
                .ToList();
        }

       

        public IEnumerable<HouseDesign> GetHouseDesignsByUseableArea(double min, double max)
        {
            return _context.HouseDesigns
                .Where(h => h.UseableArea >= min && h.UseableArea <= max)
                .ToList();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByPlotDimensions(double width, double length)
        {
            return _context.HouseDesigns
                .Where(h => h.MinPlotDimensionWidth <= width && h.MinPlotDimensionLength <= length)
                .ToList();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByRoofAngle(double min, double max)
        {
            return _context.HouseDesigns
                .Where(h => h.RoofAngle >= min && h.RoofAngle <= max)
                .ToList();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByPrice(double min, double max)
        {
            return _context.HouseDesigns
                .Where(h => h.Price >= min && h.Price <= max)
                .ToList();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByNumberOfRooms(int min, int max)
        {
            return _context.HouseDesigns
                .Where(h => h.NumberOfRooms >= min && h.NumberOfRooms <= max)
                .ToList();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByNumberOfBathrooms(int min, int max)
        {
            return _context.HouseDesigns
                .Where(h => h.NumberOfBathrooms >= min && h.NumberOfBathrooms <= max)
                .ToList();
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByNumberOfGaragePositions(int min, int max)
        {
            return _context.HouseDesigns
                .Where(h => h.NumberOfGaragePositions >= min && h.NumberOfGaragePositions <= max)
                .ToList();
        }


        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                _logger.LogInformation("GetAllCategories was called");
                return _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all house designs: {ex}");
                return null;
            }

        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories
                    .Where(c => c.CategoryId == id)
                    .FirstOrDefault();
        }

        public Category GetCategoryByName(string catName)
        {
            return _context.Categories
                    .Where(c => c.CategoryName == catName)
                    .FirstOrDefault();
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
