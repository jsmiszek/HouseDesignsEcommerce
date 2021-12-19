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
                    .OrderBy(h => h.ProjectName)
                    .ToList();

            /*try
            {
                _logger.LogInformation("Get AllHouseDesigns was called");

                return _context.HouseDesigns
                    .OrderBy(h => h.ProjectName)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all house designs: {ex}");
                return null;
            }*/
        }

        public IEnumerable<HouseDesign> GetHouseDesignsByProjectName(string projectName)
        {
            return _context.HouseDesigns
                .Where(h => h.ProjectName == projectName)
                .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
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
    }
}
